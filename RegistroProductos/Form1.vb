﻿Imports MySql.Data.MySqlClient
Imports System.Configuration

Public Class Form1

    Dim conn As New MySqlConnection
    Dim admin As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect()
        TabControl1.TabPages.Remove(TabPageAdmin)
        If LblUsuario.Text = "Sesion actual: Administrador" Then
            admin = 1
            Panel2.Visible = True
            TxtBxProductoID.Enabled = False
            TxtBxNumeroProducto2.Enabled = False
            BtnRegistrarProducto.Visible = False
            BtnModificarRegistro.Visible = True
            BtnModificarRegistro.Enabled = True
            BtnModificarRegistroLimite.Enabled = True
            BtnModificarRegistroLimite.Visible = True
            LblFechaLimite2.Enabled = True
            LblFechaLimite2.Visible = True
            DTPFechaLimite2.Enabled = True
            DTPFechaLimite2.Visible = True
            DTPFechaLimite2.Format = DateTimePickerFormat.Custom
            DTPFechaLimite2.CustomFormat = "yyy-MM-dd"
            LblFechaLimite.Visible = True
            LblFechaLimite.Enabled = True
            DTPFechaLimite.Enabled = True
            DTPFechaLimite.Visible = True
            DTPFechaLimite.Format = DateTimePickerFormat.Custom
            DTPFechaLimite.CustomFormat = "yyyy-MM-dd"
            BtnGenerarReporte.Visible = False
            BtnGenerarReporte2.Visible = False
            TabControl1.TabPages.Insert(2, TabPageAdmin)
            CmbBxTablas.Items.Clear()
            CmbBxTablas.Items.Add("Usuarios")
            CmbBxTablas.Items.Add("Clientes")
            CmbBxTablas.Items.Add("Pruebas")
            CmbBxTablas.Items.Add("Categorias")
            CmbBxTablas.Items.Add("Pruebas por Categoria")
            CmbBxTablas.Items.Add("Tipo de Mercancia")
            CmbBxTablas.Items.Add("Historial de Productos revisados")
            CmbBxTablas.Items.Add("Historial de Pruebas")
            CmbBxTablas.SelectedIndex = 0
        Else
            admin = 0
            Panel2.Visible = False
            TxtBxProductoID.Enabled = True
            BtnRegistrarProducto.Visible = True
            BtnGenerarReporte.Visible = True
            BtnGenerarReporte2.Visible = True
            TabControl1.TabPages.Remove(TabPageAdmin)
        End If
        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("SELECT NOW()"), conn)
            DTPFechaLimite.MinDate = cmd.ExecuteScalar
            DTPFechaLimite2.MinDate = cmd.ExecuteScalar
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, False, "Error")
            conn.Close()
        End Try
        CargarDGVProductosSinRevisar()
        CargarDGVProductosLimite()
        ProductosFechaLimiteCerca()
        LlenarComboBoxClientes()
        LlenarComboBoxTipoProducto()
    End Sub

    Private Sub Connect()
        conn.ConnectionString = ConfigurationManager.ConnectionStrings("cs").ConnectionString
        Try
            conn.Open()
            Console.WriteLine("conectandose a la base de datos")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub

    Public Sub CargarDGVProductosSinRevisar()
        Dim query As String = "SELECT ProductoID as 'Identificador', productos.ClienteID, productos.Tipo_Producto_ID, Clientes.Nombre as 'Cliente', tipo_productos.Nombre as 'Tipo de Mercancia', Numero_Serie as 'Numero de Serie', Observaciones, Fecha_Entrada, Fecha_Limite, Estado
                               from productos inner join clientes on productos.ClienteID = clientes.ClienteID inner join tipo_productos on productos.Tipo_Producto_ID = tipo_productos.Tipo_Producto_ID
                               Where Estado = 'Pendiente'; "

        Dim cmd As New MySqlCommand(query, conn)
        Dim reader As MySqlDataReader

        Try
            conn.Open()
            Console.WriteLine("Cargando Productos por revisar")

            reader = cmd.ExecuteReader

            Dim table As New DataTable
            table.Load(reader)
            DGVProductosSinRevisar.DataSource = table
            DGVProductosSinRevisar.ReadOnly = True
            DGVProductosSinRevisar.AllowUserToResizeColumns = True
            DGVProductosSinRevisar.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            reader.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, False, "Error")
            conn.Close()
        End Try
        DGVProductosSinRevisar.Columns(1).Visible = False
        DGVProductosSinRevisar.Columns(2).Visible = False
    End Sub

    Dim controlmensaje As Integer = 0

    Public Sub ProductosFechaLimiteCerca()
        Dim filas_total As Integer = DGVProductosSinRevisar.RowCount
        Dim fecha_servidor As Date
        Dim hoy As String
        Dim filas_total2 As Integer = DGVProductosLimite.RowCount

        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("Select date(NOW());"), conn)
            fecha_servidor = cmd.ExecuteScalar
            hoy = fecha_servidor.ToString("yyyy-MM-dd")
            conn.Close()
        Catch ex As Exception
            MsgBox("No se puede obtener la fecha de la base de datos", False, "Error")
            conn.Close()
            Exit Sub
        End Try

        If TabControl1.SelectedIndex = 0 Then
            Dim fecha_limite As Date
            Dim fecha_limite_string As String
            For i = 0 To filas_total - 2
                fecha_limite = DGVProductosSinRevisar(8, i).Value
                fecha_limite_string = fecha_limite.ToString("yyyy-MM-dd")
                Dim diferencia As Integer = DateDiff("d", fecha_servidor, fecha_limite)
                If diferencia <= 5 Then
                    DGVProductosSinRevisar.Rows(i).DefaultCellStyle.ForeColor = Color.Orange
                    If diferencia < 0 Then
                        DGVProductosSinRevisar.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                        If controlmensaje = 0 Then
                            MsgBox("El producto con identificacion " & DGVProductosSinRevisar(0, i).Value & " ya paso la fecha limite.")
                        End If
                    End If
                End If

            Next
            controlmensaje = 1

        ElseIf TabControl1.SelectedIndex = 1 Then

            Dim fecha_limite2 As Date
            Dim fecha_limite_string2 As String
            For i = 0 To filas_total2 - 2
                fecha_limite2 = DGVProductosLimite(8, i).Value
                fecha_limite_string2 = fecha_limite2.ToString("yyyy-MM-dd")
                Dim diferencia2 As Integer = DateDiff("d", fecha_servidor, fecha_limite2)
                If diferencia2 <= 5 Then
                    DGVProductosLimite.Rows(i).DefaultCellStyle.ForeColor = Color.Orange
                    If diferencia2 < 0 Then
                        DGVProductosLimite.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                    End If
                End If

            Next
        End If
    End Sub

    Public Sub CargarDGVProductosLimite()
        Dim query As String = "SELECT ProductoID as 'Identificador', productos.ClienteID, productos.Tipo_Producto_ID, Clientes.Nombre as 'Cliente', tipo_productos.Nombre as 'Tipo de Mercancia', Numero_Serie as 'Numero de Serie', Observaciones, Fecha_Entrada, Fecha_Limite, Estado
                               from productos inner join clientes on productos.ClienteID = clientes.ClienteID inner join tipo_productos on productos.Tipo_Producto_ID = tipo_productos.Tipo_Producto_ID
                               Where Estado = 'Pendiente' and datediff(Fecha_limite,(select date(now()))) <= 10;"

        Dim cmd As New MySqlCommand(query, conn)
        Dim reader As MySqlDataReader

        Try
            conn.Open()
            Console.WriteLine("Cargando Productos cerca de la fecha limite por revisar")

            reader = cmd.ExecuteReader

            Dim table As New DataTable
            table.Load(reader)
            DGVProductosLimite.DataSource = table
            DGVProductosLimite.ReadOnly = True
            DGVProductosLimite.AllowUserToResizeColumns = True
            DGVProductosLimite.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            reader.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, "Error")
            conn.Close()
        End Try
        DGVProductosLimite.Columns(1).Visible = False
        DGVProductosLimite.Columns(2).Visible = False
    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Form2.Close()
    End Sub

    Private Sub BtnDesconectar_Click(sender As Object, e As EventArgs) Handles BtnDesconectar.Click
        TxtBxProductoID.Clear()
        TxtBxNumeroSerie.Clear()
        RchTxtBxObservaciones.Clear()
        CmbBxClientes.SelectedIndex = 0
        CmbBxTipoProducto.SelectedIndex = 0
        BtnModificarRegistro.Enabled = False
        BtnModificarRegistro.Visible = False
        LblFechaLimite.Visible = False
        LblFechaLimite.Enabled = False
        DTPFechaLimite.Enabled = False
        DTPFechaLimite.Visible = False
        MsgBox("Desconectado!")
        Form2.TxBxContraseña.Text = ""
        Form2.TxtBxUsuario.Text = ""
        Form2.TxtBxUsuario.Select()
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RchTxtBxObservaciones.TextChanged
        Dim i As Integer = RchTxtBxObservaciones.TextLength
        LblContadorCaracteres.Text = i.ToString + "/150"
        If i >= 130 Then
            LblContadorCaracteres.ForeColor = Color.Red
        Else
            LblContadorCaracteres.ForeColor = Color.Black
        End If
    End Sub

    Private Sub RichTextBox2_TextChanged(sender As Object, e As EventArgs) Handles RchTxBxObservaciones2.TextChanged
        Dim i As Integer = RchTxBxObservaciones2.TextLength
        LblContadorCaracteres2.Text = i.ToString + "/150"
        If i >= 130 Then
            LblContadorCaracteres2.ForeColor = Color.Red
        Else
            LblContadorCaracteres2.ForeColor = Color.Black
        End If
    End Sub

    Public Sub LlenarComboBoxClientes()
        Dim query As String = " Select ClienteID, Nombre from clientes"
        Dim cmd As New MySqlCommand(query, conn)
        Dim sqlAdap As New MySqlDataAdapter(cmd)
        Dim dtRecord As New DataTable
        sqlAdap.Fill(dtRecord)
        CmbBxClientes.DataSource = dtRecord
        CmbBxClientes.DisplayMember = "Nombre"
        CmbBxClientes.ValueMember = "ClienteID"
        CmbBxCliente2.DataSource = dtRecord
        CmbBxCliente2.DisplayMember = "Nombre"
        CmbBxCliente2.ValueMember = "ClienteID"
    End Sub

    Public Sub LlenarComboBoxTipoProducto()
        Dim query As String = " Select Tipo_Producto_ID, Nombre from tipo_productos
                                Order by Nombre"
        Dim cmd As New MySqlCommand(query, conn)
        Dim sqlAdap As New MySqlDataAdapter(cmd)
        Dim dtRecord As New DataTable
        sqlAdap.Fill(dtRecord)
        CmbBxTipoProducto.DataSource = dtRecord
        CmbBxTipoProducto.DisplayMember = "Nombre"
        CmbBxTipoProducto.ValueMember = "Tipo_Producto_ID"
        CmbBxProducto2.DataSource = dtRecord
        CmbBxProducto2.DisplayMember = "Nombre"
        CmbBxProducto2.ValueMember = "Tipo_Producto_ID"
    End Sub

    Private Sub BtnRegistrarProducto_Click(sender As Object, e As EventArgs) Handles BtnRegistrarProducto.Click
        Dim año_actual As String
        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("SELECT YEAR (NOW());"), conn)
            año_actual = (cmd.ExecuteScalar).ToString
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, False, "Error")
            conn.Close()
            Exit Sub
        End Try

        Dim llave As String = año_actual & "-" & TxtBxProductoID.Text
        Dim Cliente As Integer = CmbBxClientes.SelectedValue
        Dim NumeroSerie As String = TxtBxNumeroSerie.Text
        Dim Producto As Integer = CmbBxTipoProducto.SelectedValue
        Dim intervalo As String

        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("SELECT Intervalo from tipo_productos WHERE Tipo_Producto_ID = '" & Producto & "'"), conn)
            intervalo = cmd.ExecuteScalar.ToString
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, False, "Error")
            conn.Close()
            Exit Sub
        End Try

        Dim fecha_registro As String
        Dim fecha_limite As String

        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("SELECT DATE(NOW())"), conn)
            Dim fecha_registro_datetime As DateTime = cmd.ExecuteScalar
            fecha_registro = fecha_registro_datetime.ToString("yyyy-MM-dd")
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, False, "Error")
            conn.Close()
            Exit Sub
        End Try

        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("SELECT DATE_ADD('" & fecha_registro & "', interval " & intervalo & ");"), conn)
            Dim fecha_limite_datetime As DateTime = cmd.ExecuteScalar
            fecha_limite = fecha_limite_datetime.ToString("yyyy-MM-dd")
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, False, "Error")
            conn.Close()
            Exit Sub
        End Try

        Dim Observaciones As String = RchTxtBxObservaciones.Text

        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("INSERT INTO productos VALUES ('" & llave & "', '" & Cliente & "', '" & Producto & "', '" & NumeroSerie & "', '" & Observaciones & "', '" & fecha_registro & "','" & fecha_limite & "', 'Pendiente');"), conn)
            cmd.ExecuteNonQuery()
            Console.WriteLine("Producto Registrado")
            conn.Close()
        Catch ex As MySqlException
            MsgBox(ex.Message, False, "Error")
            conn.Close()
            Exit Sub
        End Try
        CargarDGVProductosSinRevisar()
        CargarDGVProductosLimite()
        ProductosFechaLimiteCerca()
        TxtBxNumeroSerie.Clear()
        TxtBxProductoID.Clear()
        RchTxtBxObservaciones.Clear()
        TxtBxProductoID.Select()
    End Sub

    Private Sub DGVProductosSinRevisar_Sorted(sender As Object, e As EventArgs) Handles DGVProductosSinRevisar.Sorted
        ProductosFechaLimiteCerca()
    End Sub

    Private Sub DGVProductosSinRevisar_SelectionChanged(ByVal sender As Object, e As EventArgs) Handles DGVProductosSinRevisar.SelectionChanged
        Try
            If admin = 1 Then
                Dim fila_actual As Integer = (DGVProductosSinRevisar.CurrentRow.Index)

                TxtBxProductoID.Text = DGVProductosSinRevisar(0, (fila_actual)).Value
                CmbBxClientes.SelectedValue = DGVProductosSinRevisar(1, (fila_actual)).Value
                CmbBxTipoProducto.SelectedValue = DGVProductosSinRevisar(2, (fila_actual)).Value
                TxtBxNumeroSerie.Text = DGVProductosSinRevisar(5, (fila_actual)).Value
                RchTxtBxObservaciones.Text = DGVProductosSinRevisar(6, (fila_actual)).Value
                DTPFechaLimite.Value = DGVProductosSinRevisar(8, (fila_actual)).Value
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub DGVProductosLimite_SelectionChanged(sender As Object, e As EventArgs) Handles DGVProductosLimite.SelectionChanged
        Try
            If admin = 1 Then
                Dim fila_actual As Integer = (DGVProductosLimite.CurrentRow.Index)

                TxtBxNumeroProducto2.Text = DGVProductosLimite(0, (fila_actual)).Value
                CmbBxCliente2.SelectedValue = DGVProductosLimite(1, (fila_actual)).Value
                CmbBxProducto2.SelectedValue = DGVProductosLimite(2, (fila_actual)).Value
                TxtBxNumeroSerie2.Text = DGVProductosLimite(5, (fila_actual)).Value
                RchTxBxObservaciones2.Text = DGVProductosLimite(6, (fila_actual)).Value
                DTPFechaLimite2.Value = DGVProductosLimite(8, (fila_actual)).Value
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub



    Private Sub BtnModificarRegistro_Click(sender As Object, e As EventArgs) Handles BtnModificarRegistro.Click
        Dim fila_actual As Integer = (DGVProductosSinRevisar.CurrentRow.Index)
        Dim Cliente As Integer = CmbBxClientes.SelectedValue
        Dim producto As Integer = CmbBxTipoProducto.SelectedValue
        Dim numero_serie As String = TxtBxNumeroSerie.Text
        Dim observaciones As String = RchTxtBxObservaciones.Text
        Dim fecha As String = DTPFechaLimite.Value.ToString("yyyy-MM-dd")
        Dim id As String = TxtBxProductoID.Text

        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("UPDATE productos SET ClienteID = '" & Cliente & "', Tipo_Producto_ID ='" & producto & "', Numero_Serie ='" & numero_serie & "', Observaciones ='" & observaciones & "', Fecha_Limite = '" & fecha & "' WHERE ProductoID ='" & id & "';"), conn)
            cmd.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, False, "Error")
            conn.Close()
        End Try
        CargarDGVProductosSinRevisar()
        CargarDGVProductosLimite()
        ProductosFechaLimiteCerca()
        DGVProductosSinRevisar.Rows(fila_actual).Selected = True
    End Sub

    Private Sub BtnModificarRegistroLimite_Click(sender As Object, e As EventArgs) Handles BtnModificarRegistroLimite.Click
        Dim fila_actual As Integer = (DGVProductosLimite.CurrentRow.Index)
        Dim Cliente As Integer = CmbBxCliente2.SelectedValue
        Dim producto As Integer = CmbBxProducto2.SelectedValue
        Dim numero_serie As String = TxtBxNumeroSerie2.Text
        Dim observaciones As String = RchTxBxObservaciones2.Text
        Dim fecha As String = DTPFechaLimite2.Value.ToString("yyyy-MM-dd")
        Dim id As String = TxtBxNumeroProducto2.Text

        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("UPDATE productos SET ClienteID = '" & Cliente & "', Tipo_Producto_ID ='" & producto & "', Numero_Serie ='" & numero_serie & "', Observaciones ='" & observaciones & "', Fecha_Limite = '" & fecha & "' WHERE ProductoID ='" & id & "';"), conn)
            cmd.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, False, "Error")
            conn.Close()
        End Try
        CargarDGVProductosSinRevisar()
        CargarDGVProductosLimite()
        ProductosFechaLimiteCerca()
        DGVProductosSinRevisar.Rows(fila_actual).Selected = True
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        ProductosFechaLimiteCerca()
    End Sub

    Dim nombre_usuario As String

    Public Sub RecibirVariablesForm2(usuario As String)
        nombre_usuario = usuario
    End Sub

    Private Sub BtnGenerarReporte_Click(sender As Object, e As EventArgs) Handles BtnGenerarReporte.Click
        Dim fila_actual As Integer = (DGVProductosSinRevisar.CurrentRow.Index)
        Form3.TxtBxUsuario.Text = nombre_usuario
        Dim usu_id As String
        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("select UsuarioID from usuarios where usuario = '" & nombre_usuario & "';"), conn)
            usu_id = cmd.ExecuteScalar
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, False, "Error")
            conn.Close()
            Exit Sub
        End Try
        Form3.TxtBxIdUsuario.Text = usu_id
        Form3.TxtBxIDProducto.Text = DGVProductosSinRevisar(0, (fila_actual)).Value
        Form3.TxtBxCliente.Text = DGVProductosSinRevisar(3, fila_actual).Value
        Form3.TxtBxProducto.Text = DGVProductosSinRevisar(4, fila_actual).Value
        Form3.TxtBxNumeroSerie.Text = DGVProductosSinRevisar(5, fila_actual).Value
        Form3.RchTxtBxObservaciones.Text = DGVProductosSinRevisar(6, fila_actual).Value
        Form3.TxtBxTipoProductoID.Text = DGVProductosSinRevisar(2, fila_actual).Value
        Form3.TxtBxClienteID.Text = DGVProductosSinRevisar(1, fila_actual).Value
        Dim fecha_entrada As Date = DGVProductosSinRevisar(7, fila_actual).Value
        Form3.TxtBxFechaEntrada.Text = fecha_entrada.ToString("yyyy-MM-dd")
        Dim fecha_registro As Date
        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("select date(now())"), conn)
            fecha_registro = cmd.ExecuteScalar
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, False, "Error")
            conn.Close()
        End Try
        Form3.TxtBxFechaRegistro.Text = fecha_registro.ToString("yyyy-MM-dd")

        Form3.ShowDialog()
    End Sub

    Private Sub BtnGenerarReporte2_Click(sender As Object, e As EventArgs) Handles BtnGenerarReporte2.Click
        Dim fila_actual As Integer = (DGVProductosLimite.CurrentRow.Index)
        Form3.TxtBxUsuario.Text = nombre_usuario
        Dim usu_id As String
        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("select UsuarioID from usuarios where usuario = '" & nombre_usuario & "';"), conn)
            usu_id = cmd.ExecuteScalar
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, False, "Error")
            conn.Close()
            Exit Sub
        End Try
        Form3.TxtBxIdUsuario.Text = usu_id
        Form3.TxtBxIDProducto.Text = DGVProductosLimite(0, (fila_actual)).Value
        Form3.TxtBxCliente.Text = DGVProductosLimite(3, fila_actual).Value
        Form3.TxtBxProducto.Text = DGVProductosLimite(4, fila_actual).Value
        Form3.TxtBxNumeroSerie.Text = DGVProductosLimite(5, fila_actual).Value
        Form3.RchTxtBxObservaciones.Text = DGVProductosLimite(6, fila_actual).Value
        Form3.TxtBxTipoProductoID.Text = DGVProductosLimite(2, fila_actual).Value
        Form3.TxtBxClienteID.Text = DGVProductosLimite(1, fila_actual).Value
        Dim fecha_entrada As Date = DGVProductosLimite(7, fila_actual).Value
        Form3.TxtBxFechaEntrada.Text = fecha_entrada.ToString("yyyy-MM-dd")
        Dim fecha_registro As Date
        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("select date(now())"), conn)
            fecha_registro = cmd.ExecuteScalar
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, False, "Error")
            conn.Close()
        End Try
        Form3.TxtBxFechaRegistro.Text = fecha_registro.ToString("yyyy-MM-dd")

        Form3.ShowDialog()
    End Sub

    Private Sub LblCambiarContraseña_Click(sender As Object, e As EventArgs) Handles LblCambiarContraseña.Click
        FormCambiarContraseña.RecibirVariablesForm1(nombre_usuario)
        FormCambiarContraseña.ShowDialog()
    End Sub

    Private Sub CargarDGVAdmin()
        If CmbBxTablas.SelectedItem = "Usuarios" Then
            Dim query As String = "SELECT * From usuarios;"

            Dim cmd As New MySqlCommand(query, conn)
            Dim reader As MySqlDataReader

            Try
                conn.Open()
                Console.WriteLine("Cargando Usuarios")

                reader = cmd.ExecuteReader

                Dim table As New DataTable
                table.Load(reader)
                DGVAdmin.DataSource = table
                DGVAdmin.ReadOnly = True
                DGVAdmin.AllowUserToResizeColumns = True
                DGVAdmin.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                reader.Close()
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message, False, "Error")
                conn.Close()
            End Try
        End If
    End Sub

    Private Sub CmbBxTablas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbBxTablas.SelectedIndexChanged
        GrpBxAdmin2.Visible = False
        If CmbBxTablas.SelectedItem = "Usuarios" Then
            BtnNuevoRegistro.Enabled = True
            BtnEliminarRegistro.Enabled = True
            BtnNuevoRegistro.Text = "Agregar Usuario"
            BtnModificarRegistroAdmin.Visible = False
            BtnEliminarRegistro.Text = "Eliminar Usuario"
            GrpBxAdmin.Visible = True
            CargarDGVAdmin()
        End If
    End Sub

    Private Sub BtnNuevoRegistro_Click(sender As Object, e As EventArgs) Handles BtnNuevoRegistro.Click
        If CmbBxTablas.SelectedItem = "Usuarios" Then
            Lbl1GrpBxAdmin2.Text = "Nombre de Usuario"
            Lbl2GrpBxAdmin2.Text = "Contraseña"
            Lbl3GrpBxAdmin2.Text = "Confirmar Contraseña"
            TxtBx2GrpBxAdmin2.PasswordChar = "*"
            TxtBx3GrpBxAdmin2.PasswordChar = "*"
            GrpBxAdmin2.Visible = True
        End If
    End Sub

    Private Sub BtnAceptarGrpBxAdmin2_Click(sender As Object, e As EventArgs) Handles BtnAceptarGrpBxAdmin2.Click
        If CmbBxTablas.SelectedItem = "Usuarios" Then
            If TxtBx2GrpBxAdmin2.TextLength < 3 Or TxtBx3GrpBxAdmin2.TextLength < 3 Then
                MsgBox("La contraseña debe ser de al menos 3 caracteres", False, "Error")
                Exit Sub
            Else
                If TxtBx2GrpBxAdmin2.Text <> TxtBx3GrpBxAdmin2.Text Then
                    MsgBox("Las contraseñas ingresadas no coinciden", False, "Error")
                    Exit Sub
                Else
                    Try
                        conn.Open()
                        Dim cmd As New MySqlCommand(String.Format("select max(UsuarioID) + 1 FROM usuarios;"), conn)
                        Dim llave As String = cmd.ExecuteScalar.ToString
                        Dim cmd2 As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`usuarios` (`UsuarioID`, `usuario`, `Contraseña`) VALUES ('" & llave & "', '" & TxtBx1GrpBxAdmin2.Text & "', '" & TxtBx2GrpBxAdmin2.Text & "');"), conn)
                        cmd2.ExecuteNonQuery()
                        conn.Close()
                        MsgBox("Usuario Agregado", False, "Usuario Agregado")
                    Catch ex As Exception
                        MsgBox(ex.Message, False, "Error")
                        conn.Close()
                        Exit Sub
                    End Try
                    CargarDGVAdmin()
                End If
            End If
        End If
    End Sub

    Private Sub BtnEliminarRegistro_Click(sender As Object, e As EventArgs) Handles BtnEliminarRegistro.Click
        If MessageBox.Show("¿Esta seguro que desea eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim reader As MySqlDataReader
            Dim fila_actual_obj As Object = DGVAdmin.CurrentRow
            If IsNothing(fila_actual_obj) Then
                MsgBox("Seleccione un registro a eliminar", MsgBoxStyle.Information, "Info.")
                Exit Sub
            End If

            If CmbBxTablas.SelectedItem = "Usuarios" Then
                Dim fila_actual As Integer = DGVAdmin.CurrentRow.Index
                Dim llave As Integer = DGVAdmin(0, fila_actual).Value
                Try
                    conn.Open()
                    Dim query As String = "Delete from usuarios where usuarioID = " & llave & ""
                    Dim cmd As New MySqlCommand(query, conn)
                    reader = cmd.ExecuteReader
                    MsgBox("Usuario Eliminado", MsgBoxStyle.Information, "Usuario Eliminado")
                    conn.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                    conn.Close()
                    Exit Sub
                End Try
                CargarDGVAdmin()
            End If

        End If

    End Sub



End Class