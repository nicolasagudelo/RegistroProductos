Imports MySql.Data.MySqlClient
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
            TabControl1.TabPages.Insert(2, TabPageProductosRevisados)
            TabControl1.TabPages.Insert(3, TabPageAdmin)
            CmbBxEsAdmin.Items.Clear()
            CmbBxEsAdmin.Items.Add("Si")
            CmbBxEsAdmin.Items.Add("No")
            CmbBxTablas.Items.Clear()
            CmbBxTablas.Items.Add("Usuarios")
            CmbBxTablas.Items.Add("Clientes")
            CmbBxTablas.Items.Add("Pruebas")
            CmbBxTablas.Items.Add("Categorias")
            CmbBxTablas.Items.Add("Pruebas por Categoria")
            CmbBxTablas.Items.Add("Tipo de Mercancia")
            CmbBxTablas.Items.Add("Productos Aprobados")
            CmbBxTablas.SelectedIndex = 0
            LlenarComboBoxPruebas()
            LlenarComboBoxCategorias()
        ElseIf LblEsAdmin.Text = "True" Then
            admin = 0
            Panel2.Visible = False
            TxtBxProductoID.Enabled = True
            BtnRegistrarProducto.Visible = True
            BtnGenerarReporte.Visible = True
            BtnGenerarReporte2.Visible = True
            TabControl1.TabPages.Remove(TabPageAdmin)
            TabControl1.TabPages.Remove(TabPageProductosRevisados)
            GrpBxTipoSesion.Visible = True
            RBAnalista.Checked = True
        Else
            admin = 0
            Panel2.Visible = False
            TxtBxProductoID.Enabled = True
            BtnRegistrarProducto.Visible = True
            BtnGenerarReporte.Visible = True
            BtnGenerarReporte2.Visible = True
            TabControl1.TabPages.Remove(TabPageAdmin)
            TabControl1.TabPages.Remove(TabPageProductosRevisados)
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
        CargarDGVProductosRevisados()
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
        Dim query As String = "SELECT ProductoID as 'Identificador', productos.ClienteID, productos.Tipo_Producto_ID, Clientes.Nombre as 'Cliente', tipo_productos.Nombre as 'Tipo de Mercancia', Numero_Serie as 'Numero de Serie', Observaciones, Fecha_Entrada, Hora_Entrada, Fecha_Limite, Estado
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

    Public Sub CargarDGVProductosRevisados()
        If admin = 1 Then
            Dim query As String = "SELECT distinct productos.ProductoID as 'ID Producto', clientes.ClienteID, clientes.Nombre as 'Cliente', clientes.Direccion as 'Direccion',tipo_productos.Tipo_Producto_ID, tipo_productos.Nombre as 'Producto', productos.Numero_Serie as 'Numero de Serie', productos.Observaciones as 'Observaciones', productos.Fecha_Entrada as 'Fecha de Entrada', Productos.Hora_Entrada as 'Hora de Entrada', reportes.Fecha_Reporte as 'Fecha Reporte', productos.Fecha_Limite as 'Fecha Limite', productos.Estado as 'Estado', productos.UsuarioID, usuarios.usuario as 'Revisado Por'
                                   from productos inner join clientes on productos.ClienteID = clientes.ClienteID inner join tipo_productos on productos.Tipo_Producto_ID = tipo_productos.Tipo_Producto_ID inner join usuarios on productos.UsuarioID = usuarios.UsuarioID inner join reportes on productos.ProductoID = reportes.ProductoID
                                   Where Estado = 'Revisado';"

            Dim cmd As New MySqlCommand(query, conn)
            Dim reader As MySqlDataReader

            Try
                conn.Open()
                Console.WriteLine("Cargando Productos Revisados")

                reader = cmd.ExecuteReader

                Dim table As New DataTable
                table.Load(reader)
                DGVProductosRevisados.DataSource = table
                DGVProductosRevisados.ReadOnly = True
                DGVProductosRevisados.AllowUserToResizeColumns = True
                DGVProductosRevisados.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                reader.Close()
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                conn.Close()
            End Try
            DGVProductosRevisados.Columns(1).Visible = False
            DGVProductosRevisados.Columns(4).Visible = False
            DGVProductosRevisados.Columns(13).Visible = False
        End If
    End Sub

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
                fecha_limite = DGVProductosSinRevisar(9, i).Value
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
                fecha_limite2 = DGVProductosLimite(9, i).Value
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
        Dim query As String = "SELECT ProductoID as 'Identificador', productos.ClienteID, productos.Tipo_Producto_ID, Clientes.Nombre as 'Cliente', tipo_productos.Nombre as 'Tipo de Mercancia', Numero_Serie as 'Numero de Serie', Observaciones, Fecha_Entrada, Hora_Entrada, Fecha_Limite, Estado
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

    Private Sub LlenarComboBoxPruebas()
        Dim query As String = " Select ID_Prueba from Pruebas"
        Dim cmd As New MySqlCommand(query, conn)
        Dim sqlAdap As New MySqlDataAdapter(cmd)
        Dim dtRecord As New DataTable
        sqlAdap.Fill(dtRecord)
        CmbBx1GrpBxAdmin2.DataSource = dtRecord
        CmbBx1GrpBxAdmin2.DisplayMember = "ID_Prueba"
        CmbBx1GrpBxAdmin2.ValueMember = "ID_Prueba"
    End Sub
    Private Sub LlenarComboBoxCategorias()
        Dim query As String = " Select ID_Categoria, Nombre from categorias"
        Dim cmd As New MySqlCommand(query, conn)
        Dim sqlAdap As New MySqlDataAdapter(cmd)
        Dim dtRecord As New DataTable
        sqlAdap.Fill(dtRecord)
        CmbBx2GrpBxAdmin2.DataSource = dtRecord
        CmbBx2GrpBxAdmin2.DisplayMember = "Nombre"
        CmbBx2GrpBxAdmin2.ValueMember = "ID_Categoria"
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
        Dim hora_registro As String

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
            Dim cmd As New MySqlCommand(String.Format("SELECT TIME(NOW())"), conn)
            hora_registro = cmd.ExecuteScalar.ToString
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
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
            Dim cmd As New MySqlCommand(String.Format("INSERT INTO productos (`ProductoID`, `ClienteID`, `Tipo_Producto_ID`, `Numero_Serie`, `Observaciones`, `Fecha_Entrada`, `Hora_Entrada`, `Fecha_Limite`, `Estado`) VALUES ('" & llave & "', '" & Cliente & "', '" & Producto & "', '" & NumeroSerie & "', '" & Observaciones & "', '" & fecha_registro & "','" & hora_registro & "','" & fecha_limite & "', 'Pendiente');"), conn)
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
        CargarDGVProductosRevisados()
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
        If MessageBox.Show("¿Esta seguro que desea modificar el registro seleccionado?", "Modificar", MessageBoxButtons.YesNo) = DialogResult.Yes Then
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
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                conn.Close()
            End Try
            CargarDGVProductosSinRevisar()
            CargarDGVProductosLimite()
            CargarDGVProductosRevisados()
            ProductosFechaLimiteCerca()
            DGVProductosSinRevisar.Rows(fila_actual).Selected = True
        End If
    End Sub

    Private Sub BtnModificarRegistroLimite_Click(sender As Object, e As EventArgs) Handles BtnModificarRegistroLimite.Click
        If MessageBox.Show("¿Esta seguro que desea modificar el registro seleccionado?", "Modificar", MessageBoxButtons.YesNo) = DialogResult.Yes Then
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
            CargarDGVProductosRevisados()
            ProductosFechaLimiteCerca()
            DGVProductosSinRevisar.Rows(fila_actual).Selected = True
        End If
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
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
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
        Dim hora_entrada As String = DGVProductosSinRevisar(8, fila_actual).Value.ToString
        Form3.TxtBxHoraEntrada.Text = hora_entrada
        Dim fecha_registro As Date

        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("Select Direccion from Clientes where ClienteID = '" & DGVProductosSinRevisar(1, fila_actual).Value & "';"), conn)
            Form3.TxtBxDireccion.Text = cmd.ExecuteScalar
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
            conn.Close()
            Exit Sub
        End Try

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
        Dim hora_entrada As String = DGVProductosLimite(8, fila_actual).Value
        Form3.TxtBxHoraEntrada.Text = hora_entrada
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

        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("Select Direccion from Clientes where ClienteID = '" & DGVProductosLimite(1, fila_actual).Value & "';"), conn)
            Form3.TxtBxDireccion.Text = cmd.ExecuteScalar
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
            conn.Close()
            Exit Sub
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
            DGVAdmin.Columns(2).Visible = False
        ElseIf CmbBxTablas.SelectedItem = "Clientes" Then
            Dim query As String = "SELECT * From Clientes;"

            Dim cmd As New MySqlCommand(query, conn)
            Dim reader As MySqlDataReader

            Try
                conn.Open()
                Console.WriteLine("Cargando Clientes")

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
        ElseIf CmbBxTablas.SelectedItem = "Pruebas" Then
            Dim query As String = "SELECT * From Pruebas;"

            Dim cmd As New MySqlCommand(query, conn)
            Dim reader As MySqlDataReader

            Try
                conn.Open()
                Console.WriteLine("Cargando Pruebas")

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
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                conn.Close()
            End Try
        ElseIf CmbBxTablas.SelectedItem = "Categorias" Then
            Dim query As String = "SELECT * From Categorias;"

            Dim cmd As New MySqlCommand(query, conn)
            Dim reader As MySqlDataReader

            Try
                conn.Open()
                Console.WriteLine("Cargando Categorias")

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
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                conn.Close()
            End Try
        ElseIf CmbBxTablas.SelectedItem = "Pruebas por Categoria" Then
            Dim query As String = "select pruebasxcategoria.ID_Prueba, categorias.Nombre 
                                   from pruebasxcategoria inner join categorias on pruebasxcategoria.ID_Categoria = categorias.ID_Categoria
                                   order by ID_Prueba;;"

            Dim cmd As New MySqlCommand(query, conn)
            Dim reader As MySqlDataReader

            Try
                conn.Open()
                Console.WriteLine("Cargando Pruebas por Categoria")

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
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                conn.Close()
            End Try

        ElseIf CmbBxTablas.SelectedItem = "Tipo de Mercancia" Then
            Dim query As String = "SELECT * From tipo_productos;"

            Dim cmd As New MySqlCommand(query, conn)
            Dim reader As MySqlDataReader

            Try
                conn.Open()
                Console.WriteLine("Cargando tipo de productos")

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
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                conn.Close()
            End Try
        ElseIf CmbBxTablas.SelectedItem = "Productos Aprobados" Then
            Dim query As String = "SELECT distinct productos.ProductoID as 'ID Producto', clientes.ClienteID, clientes.Nombre as 'Cliente', clientes.Direccion as 'Direccion',tipo_productos.Tipo_Producto_ID, tipo_productos.Nombre as 'Producto', productos.Numero_Serie as 'Numero de Serie', productos.Observaciones as 'Observaciones', productos.Fecha_Entrada as 'Fecha de Entrada', Productos.Hora_Entrada as 'Hora de Entrada', reportes.Fecha_Reporte as 'Fecha Reporte', productos.Fecha_Limite as 'Fecha Limite', productos.Estado as 'Estado', productos.ID_Muestra, productos.Tanque,productos.Lote,productos.ATN,productos.TipodePrueba, productos.UsuarioID, usuarios.usuario as 'Revisado Por'
                                   from productos inner join clientes on productos.ClienteID = clientes.ClienteID inner join tipo_productos on productos.Tipo_Producto_ID = tipo_productos.Tipo_Producto_ID inner join usuarios on productos.UsuarioID = usuarios.UsuarioID inner join reportes on productos.ProductoID = reportes.ProductoID
                                   Where Estado = 'Aprobado';"

            Dim cmd As New MySqlCommand(query, conn)
            Dim reader As MySqlDataReader

            Try
                conn.Open()
                Console.WriteLine("Cargando productos aprobados")

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
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                conn.Close()
            End Try

            DGVAdmin.Columns(1).Visible = False
            DGVAdmin.Columns(4).Visible = False
            DGVAdmin.Columns(12).Visible = False
            DGVAdmin.Columns(13).Visible = False
            DGVAdmin.Columns(14).Visible = False
            DGVAdmin.Columns(15).Visible = False
            DGVAdmin.Columns(16).Visible = False
            DGVAdmin.Columns(17).Visible = False
            DGVAdmin.Columns(18).Visible = False

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
            BtnEliminarRegistro.Visible = True
            BtnNuevoRegistro.Visible = True
            GrpBxAdmin.Visible = True
            LblValorAdmin.Visible = True
            CmbBxEsAdmin.Visible = True
            CargarDGVAdmin()
        ElseIf CmbBxTablas.SelectedItem = "Clientes" Then
            BtnNuevoRegistro.Enabled = True
            BtnEliminarRegistro.Enabled = True
            BtnNuevoRegistro.Text = "Agregar Cliente"
            BtnModificarRegistroAdmin.Visible = False
            BtnEliminarRegistro.Text = "Eliminar Cliente"
            BtnEliminarRegistro.Visible = True
            BtnNuevoRegistro.Visible = True
            GrpBxAdmin.Visible = True
            LblValorAdmin.Visible = False
            CmbBxEsAdmin.Visible = False
            CargarDGVAdmin()
        ElseIf CmbBxTablas.SelectedItem = "Pruebas" Then
            BtnNuevoRegistro.Enabled = True
            BtnEliminarRegistro.Visible = False
            BtnNuevoRegistro.Text = "Agregar Prueba"
            BtnNuevoRegistro.Visible = True
            BtnModificarRegistroAdmin.Visible = False
            GrpBxAdmin.Visible = True
            LblValorAdmin.Visible = False
            CmbBxEsAdmin.Visible = False
            CargarDGVAdmin()
        ElseIf CmbBxTablas.SelectedItem = "Categorias" Then
            BtnNuevoRegistro.Enabled = True
            BtnEliminarRegistro.Visible = False
            BtnNuevoRegistro.Text = "Agregar Categoria"
            BtnModificarRegistroAdmin.Visible = False
            BtnNuevoRegistro.Visible = True
            GrpBxAdmin.Visible = True
            LblValorAdmin.Visible = False
            CmbBxEsAdmin.Visible = False
            CargarDGVAdmin()
        ElseIf CmbBxTablas.SelectedItem = "Pruebas por Categoria" Then
            BtnNuevoRegistro.Enabled = True
            BtnEliminarRegistro.Enabled = True
            BtnNuevoRegistro.Text = "Nuevo Registro"
            BtnModificarRegistroAdmin.Visible = False
            BtnEliminarRegistro.Text = "Eliminar Registro"
            BtnEliminarRegistro.Visible = True
            GrpBxAdmin.Visible = True
            LblValorAdmin.Visible = False
            CmbBxEsAdmin.Visible = False
            CargarDGVAdmin()
        ElseIf CmbBxTablas.SelectedItem = "Tipo de Mercancia" Then
            BtnNuevoRegistro.Enabled = True
            BtnEliminarRegistro.Visible = False
            BtnNuevoRegistro.Text = "Agregar Tipo de Mercancia"
            BtnModificarRegistroAdmin.Visible = False
            BtnNuevoRegistro.Visible = True
            GrpBxAdmin.Visible = True
            LblValorAdmin.Visible = False
            CmbBxEsAdmin.Visible = False
            CargarDGVAdmin()
        ElseIf CmbBxTablas.SelectedItem = "Productos Aprobados" Then
            GrpBxAdmin.Visible = True
            BtnNuevoRegistro.Enabled = True
            BtnNuevoRegistro.Visible = True
            BtnNuevoRegistro.Text = "Re-Proceso"
            BtnModificarRegistro.Visible = False
            BtnEliminarRegistro.Visible = False
            GrpBxAdmin2.Visible = False
            CargarDGVAdmin()
        End If
    End Sub

    Private Sub BtnNuevoRegistro_Click(sender As Object, e As EventArgs) Handles BtnNuevoRegistro.Click
        If CmbBxTablas.SelectedItem = "Usuarios" Then
            Lbl1GrpBxAdmin2.Visible = True
            Lbl2GrpBxAdmin2.Visible = True
            Lbl3GrpBxAdmin2.Visible = True
            Intervalo.Visible = False
            TxtBx1GrpBxAdmin2.Visible = True
            TxtBx2GrpBxAdmin2.Visible = True
            TxtBx3GrpBxAdmin2.Visible = True
            CmbBx1GrpBxAdmin2.Visible = False
            CmbBx2GrpBxAdmin2.Visible = False
            Lbl1GrpBxAdmin2.Text = "Nombre de Usuario"
            Lbl2GrpBxAdmin2.Text = "Contraseña"
            Lbl3GrpBxAdmin2.Text = "Confirmar Contraseña"
            TxtBx2GrpBxAdmin2.PasswordChar = "*"
            TxtBx3GrpBxAdmin2.PasswordChar = "*"
            GrpBxAdmin2.Visible = True
        ElseIf CmbBxTablas.SelectedItem = "Clientes" Then
            Lbl1GrpBxAdmin2.Text = "Nombre del Cliente"
            Lbl1GrpBxAdmin2.Visible = True
            Lbl2GrpBxAdmin2.Visible = False
            Lbl3GrpBxAdmin2.Visible = False
            Intervalo.Visible = False
            TxtBx1GrpBxAdmin2.Visible = True
            TxtBx2GrpBxAdmin2.Visible = False
            TxtBx3GrpBxAdmin2.Visible = False
            CmbBx1GrpBxAdmin2.Visible = False
            CmbBx2GrpBxAdmin2.Visible = False
            GrpBxAdmin2.Visible = True
        ElseIf CmbBxTablas.SelectedItem = "Pruebas" Then
            Lbl1GrpBxAdmin2.Text = "Codigo de la Prueba"
            Lbl2GrpBxAdmin2.Text = "Nombre de la Prueba"
            Lbl1GrpBxAdmin2.Visible = True
            Lbl2GrpBxAdmin2.Visible = True
            Lbl3GrpBxAdmin2.Visible = False
            Intervalo.Visible = False
            TxtBx1GrpBxAdmin2.Visible = True
            TxtBx2GrpBxAdmin2.Visible = True
            TxtBx3GrpBxAdmin2.Visible = False
            CmbBx1GrpBxAdmin2.Visible = False
            CmbBx2GrpBxAdmin2.Visible = False
            GrpBxAdmin2.Visible = True
        ElseIf CmbBxTablas.SelectedItem = "Categorias" Then
            Lbl1GrpBxAdmin2.Text = "Nombre de la Categoria"
            Lbl1GrpBxAdmin2.Visible = True
            Lbl2GrpBxAdmin2.Visible = False
            Lbl3GrpBxAdmin2.Visible = False
            Intervalo.Visible = False
            TxtBx1GrpBxAdmin2.Visible = True
            TxtBx2GrpBxAdmin2.Visible = False
            TxtBx3GrpBxAdmin2.Visible = False
            CmbBx1GrpBxAdmin2.Visible = False
            CmbBx2GrpBxAdmin2.Visible = False
            GrpBxAdmin2.Visible = True
        ElseIf CmbBxTablas.SelectedItem = "Pruebas por Categoria" Then
            Lbl1GrpBxAdmin2.Text = "Codigo de la Prueba"
            Lbl2GrpBxAdmin2.Text = "Categoria de la Prueba"
            Lbl1GrpBxAdmin2.Visible = True
            Lbl2GrpBxAdmin2.Visible = True
            Lbl3GrpBxAdmin2.Visible = False
            Intervalo.Visible = False
            TxtBx1GrpBxAdmin2.Visible = False
            TxtBx2GrpBxAdmin2.Visible = False
            TxtBx3GrpBxAdmin2.Visible = False
            CmbBx1GrpBxAdmin2.Visible = True
            CmbBx2GrpBxAdmin2.Visible = True
            GrpBxAdmin2.Visible = True
        ElseIf CmbBxTablas.SelectedItem = "Tipo de Mercancia" Then
            Lbl1GrpBxAdmin2.Text = "Nombre"
            Lbl2GrpBxAdmin2.Text = "Intervalo (en dias)"
            Lbl1GrpBxAdmin2.Visible = True
            Lbl2GrpBxAdmin2.Visible = True
            Lbl3GrpBxAdmin2.Visible = False
            TxtBx1GrpBxAdmin2.Visible = True
            Intervalo.Visible = True
            TxtBx2GrpBxAdmin2.Visible = False
            TxtBx3GrpBxAdmin2.Visible = False
            CmbBx1GrpBxAdmin2.Visible = False
            CmbBx2GrpBxAdmin2.Visible = False
            GrpBxAdmin2.Visible = True
        ElseIf CmbBxTablas.SelectedItem = "Productos Aprobados" Then
            GenerarReproceso()
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
                    Dim es_admin As Integer
                    If CmbBxEsAdmin.SelectedItem = "Si" Then
                        es_admin = 1
                    Else
                        es_admin = 0
                    End If
                    Try
                        conn.Open()
                        Dim cmd As New MySqlCommand(String.Format("select max(UsuarioID) + 1 FROM usuarios;"), conn)
                        Dim llave As String = cmd.ExecuteScalar.ToString
                        Dim cmd2 As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`usuarios` (`UsuarioID`, `usuario`, `Contraseña`,`Admin`) VALUES ('" & llave & "', '" & TxtBx1GrpBxAdmin2.Text & "', '" & TxtBx2GrpBxAdmin2.Text & "', '" & es_admin & "');"), conn)
                        cmd2.ExecuteNonQuery()
                        conn.Close()
                        MsgBox("Usuario Agregado", MsgBoxStyle.Information, "Usuario Agregado")
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                        conn.Close()
                        Exit Sub
                    End Try
                    CargarDGVAdmin()
                End If
            End If
        ElseIf CmbBxTablas.SelectedItem = "Clientes" Then
            Try
                conn.Open()
                Dim cmd As New MySqlCommand(String.Format("select max(ClienteID) + 1 FROM clientes;"), conn)
                Dim llave As String = cmd.ExecuteScalar.ToString
                Dim cmd2 As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`clientes` (`ClienteID`, `Nombre`) VALUES ('" & llave & "', '" & TxtBx1GrpBxAdmin2.Text & "');"), conn)
                cmd2.ExecuteNonQuery()
                conn.Close()
                MsgBox("Cliente Agregado", MsgBoxStyle.Information, "Cliente Agregado")
            Catch ex As Exception
                MsgBox(ex.Message, False, "Error")
                conn.Close()
                Exit Sub
            End Try
            CargarDGVAdmin()
        ElseIf CmbBxTablas.SelectedItem = "Pruebas" Then
            Dim llave As String = TxtBx1GrpBxAdmin2.Text
            Dim nombre As String = TxtBx2GrpBxAdmin2.Text
            Try
                conn.Open()
                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`pruebas` (`ID_Prueba`, `Nombre`) VALUES ('" & llave & "', '" & nombre & "');"), conn)
                cmd.ExecuteNonQuery()
                conn.Close()
                MsgBox("Prueba Agregada", MsgBoxStyle.Information, "Prueba Agregada")
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                conn.Close()
                Exit Sub
            End Try
            CargarDGVAdmin()
        ElseIf CmbBxTablas.SelectedItem = "Categorias" Then
            Try
                conn.Open()
                Dim cmd As New MySqlCommand(String.Format("select max(ID_Categoria) + 1 FROM categorias;"), conn)
                Dim llave As String = cmd.ExecuteScalar.ToString
                Dim cmd2 As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`categorias` (`ID_Categoria`, `Nombre`) VALUES ('" & llave & "', '" & TxtBx1GrpBxAdmin2.Text & "');"), conn)
                cmd2.ExecuteNonQuery()
                conn.Close()
                MsgBox("Categoria Agregada", MsgBoxStyle.Information, "Categoria Agregada")
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                conn.Close()
                Exit Sub
            End Try
            CargarDGVAdmin()

        ElseIf CmbBxTablas.SelectedItem = "Pruebas por Categoria" Then
            Try
                conn.Open()
                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`pruebasxcategoria` (`ID_Prueba`, `ID_Categoria`) VALUES ('" & CmbBx1GrpBxAdmin2.SelectedValue & "', '" & CmbBx2GrpBxAdmin2.SelectedValue & "');"), conn)
                cmd.ExecuteNonQuery()
                conn.Close()
                MsgBox("Registro Agregado", MsgBoxStyle.Information, "Registro Agregado")
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                conn.Close()
                Exit Sub
            End Try
            CargarDGVAdmin()

        ElseIf CmbBxTablas.SelectedItem = "Tipo de Mercancia" Then
            Try
                conn.Open()
                Dim cmd As New MySqlCommand(String.Format("select max(Tipo_Producto_ID) + 1 FROM tipo_productos;"), conn)
                Dim llave As String = cmd.ExecuteScalar.ToString
                Dim cmd2 As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`tipo_productos` (`Tipo_Producto_ID`, `Nombre`, `Intervalo`) VALUES ('" & llave & "', '" & TxtBx1GrpBxAdmin2.Text & "', '" & Intervalo.Value.ToString & " DAY');"), conn)
                cmd2.ExecuteNonQuery()
                conn.Close()
                MsgBox("Tipo de Mercancia Agregada", MsgBoxStyle.Information, "Tipo de Mercancia Agregada")
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                conn.Close()
                Exit Sub
            End Try
            CargarDGVAdmin()

        End If
        TxtBx1GrpBxAdmin2.Text = ""
        TxtBx2GrpBxAdmin2.Text = ""
        TxtBx3GrpBxAdmin2.Text = ""

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

            ElseIf CmbBxTablas.SelectedItem = "Clientes" Then
                Dim fila_actual As Integer = DGVAdmin.CurrentRow.Index
                Dim llave As Integer = DGVAdmin(0, fila_actual).Value
                Try
                    conn.Open()
                    Dim query As String = "Delete from clientes where ClienteID = " & llave & ""
                    Dim cmd As New MySqlCommand(query, conn)
                    reader = cmd.ExecuteReader
                    MsgBox("Cliente Eliminado", MsgBoxStyle.Information, "Cliente Eliminado")
                    conn.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                    conn.Close()
                    Exit Sub
                End Try
            ElseIf CmbBxTablas.SelectedItem = "Pruebas por Categoria" Then
                Dim fila_actual As Integer = DGVAdmin.CurrentRow.Index
                Dim llave As String = DGVAdmin(0, fila_actual).Value.ToString
                Dim var As String = DGVAdmin(1, fila_actual).Value.ToString
                Try
                    conn.Open()
                    Dim query As String = "select id_categoria from categorias where nombre ='" & var & "';"
                    Dim cmd As New MySqlCommand(query, conn)
                    Dim llave2 As String = cmd.ExecuteScalar
                    Dim query2 As String = "Delete from pruebasxcategoria where ID_Prueba = '" & llave & "' and ID_Categoria = '" & llave2 & "';"
                    Dim cmd2 As New MySqlCommand(query2, conn)
                    reader = cmd2.ExecuteReader
                    MsgBox("Registro Eliminado", MsgBoxStyle.Information, "Registro Eliminado")
                    conn.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                    conn.Close()
                    Exit Sub
                End Try
            End If
            CargarDGVAdmin()
        End If

    End Sub

    Private Sub RBAnalista_CheckedChanged(sender As Object, e As EventArgs) Handles RBAnalista.CheckedChanged
        If RBAnalista.Checked = True Then
            admin = 0
            Panel2.Visible = False
            TxtBxProductoID.Enabled = True
            BtnRegistrarProducto.Visible = True
            BtnModificarRegistro.Visible = False
            BtnModificarRegistroLimite.Visible = False
            LblFechaLimite.Visible = False
            LblFechaLimite2.Visible = False
            DTPFechaLimite.Visible = False
            DTPFechaLimite2.Visible = False
            BtnGenerarReporte.Visible = True
            BtnGenerarReporte2.Visible = True
            TabControl1.TabPages.Remove(TabPageAdmin)
            TabControl1.TabPages.Remove(TabPageProductosRevisados)
            GrpBxTipoSesion.Visible = True
            RBAnalista.Checked = True
        ElseIf RBAdmin.Checked = True Then
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
            TabControl1.TabPages.Insert(2, TabPageProductosRevisados)
            TabControl1.TabPages.Insert(3, TabPageAdmin)
            CargarDGVProductosRevisados()
            CmbBxEsAdmin.Items.Clear()
            CmbBxEsAdmin.Items.Add("Si")
            CmbBxEsAdmin.Items.Add("No")
            CmbBxTablas.Items.Clear()
            CmbBxTablas.Items.Add("Usuarios")
            CmbBxTablas.Items.Add("Clientes")
            CmbBxTablas.Items.Add("Pruebas")
            CmbBxTablas.Items.Add("Categorias")
            CmbBxTablas.Items.Add("Pruebas por Categoria")
            CmbBxTablas.Items.Add("Tipo de Mercancia")
            CmbBxTablas.Items.Add("Productos Aprobados")
            CmbBxTablas.SelectedIndex = 0
            LlenarComboBoxPruebas()
            LlenarComboBoxCategorias()
        End If

    End Sub

    Private Sub DGVProductosRevisados_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVProductosRevisados.CellDoubleClick
        Form5.BtnGenerarPDF.Visible = False
        Form5.BtnAceptarReporte.Visible = True
        Form5.BtnRechazarReporte.Visible = True
        Form5.RchTxtBxObservaciones.ReadOnly = False
        Form5.RBCompleta.Enabled = True
        Form5.RBCompleta.Checked = False
        Form5.RBBasica.Enabled = True
        Form5.RBBasica.Checked = False
        Form5.RBEspecifica.Enabled = True
        Form5.RBEspecifica.Checked = False
        Form5.TxtBxOrigen.ReadOnly = False
        Form5.TxtBxOrigen.Clear()
        Form5.TxtBxLote.ReadOnly = False
        Form5.TxtBxLote.Clear()
        Form5.TxtBxIDMuestra.ReadOnly = False
        Form5.TxtBxIDMuestra.Clear()
        Form5.TxtBxATN.ReadOnly = False
        Form5.TxtBxATN.Clear()
        Dim fila_actual As Integer = (DGVProductosRevisados.CurrentRow.Index)
        If nombre_usuario = DGVProductosRevisados(14, fila_actual).Value.ToString Then
            MsgBox("No puede realizar un reporte sobre una muestra que usted mismo reviso", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        If fila_actual + 1 = DGVProductosRevisados.Rows.Count Then
            Exit Sub
        End If
        Form5.TxtBxUsuario.Text = DGVProductosRevisados(14, fila_actual).Value
        Dim usu_id As String
        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("select UsuarioID from usuarios where usuario = '" & DGVProductosRevisados(14, fila_actual).Value & "';"), conn)
            usu_id = cmd.ExecuteScalar
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
            conn.Close()
            Exit Sub
        End Try
        Form5.TxtBxIdUsuario.Text = usu_id
        Form5.TxtBxIDProducto.Text = DGVProductosRevisados(0, fila_actual).Value
        Form5.TxtBxClienteID.Text = DGVProductosRevisados(1, fila_actual).Value
        Form5.TxtBxCliente.Text = DGVProductosRevisados(2, fila_actual).Value
        Form5.TxtBxTipoProductoID.Text = DGVProductosRevisados(4, fila_actual).Value
        Form5.TxtBxProducto.Text = DGVProductosRevisados(5, fila_actual).Value
        Form5.TxtBxNumeroSerie.Text = DGVProductosRevisados(6, fila_actual).Value
        Form5.RchTxtBxObservaciones.Text = DGVProductosRevisados(7, fila_actual).Value
        Dim fecha_entrada As Date = DGVProductosRevisados(8, fila_actual).Value
        Form5.TxtBxFechaEntrada.Text = fecha_entrada.ToString("yyyy-MM-dd")
        Dim hora_entrada As String = DGVProductosRevisados(9, fila_actual).Value.ToString
        Form5.TxtBxHoraEntrada.Text = hora_entrada
        Dim fecha_registro As Date = DGVProductosRevisados(10, fila_actual).Value
        Dim PeriodoAnalisis As String = DateDiff("d", fecha_entrada, fecha_registro)
        Form5.TxtBxPeriodoAnalisis.Text = PeriodoAnalisis + " dias"


        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("Select Direccion from Clientes where ClienteID = '" & DGVProductosRevisados(1, fila_actual).Value & "';"), conn)
            Form5.TxtBxDireccion.Text = cmd.ExecuteScalar
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
            conn.Close()
            Exit Sub
        End Try

        Form5.TxtBxFechaRegistro.Text = fecha_registro.ToString("yyyy-MM-dd")

        Form5.ShowDialog()

    End Sub

    Private Sub DGVAdmin_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVAdmin.CellDoubleClick
        If CmbBxTablas.SelectedItem = "Productos Aprobados" Then

            Dim fila_actual As Integer = (DGVAdmin.CurrentRow.Index)

            If fila_actual + 1 = DGVAdmin.Rows.Count Then
                Exit Sub
            End If



            Form5.TxtBxUsuario.Text = DGVAdmin(19, fila_actual).Value

            Form5.TxtBxIdUsuario.Text = DGVAdmin(18, fila_actual).Value
            Form5.TxtBxIDProducto.Text = DGVAdmin(0, fila_actual).Value
            Form5.TxtBxClienteID.Text = DGVAdmin(1, fila_actual).Value
            Form5.TxtBxCliente.Text = DGVAdmin(2, fila_actual).Value
            Form5.TxtBxDireccion.Text = DGVAdmin(3, fila_actual).Value
            Form5.TxtBxTipoProductoID.Text = DGVAdmin(4, fila_actual).Value
            Form5.TxtBxProducto.Text = DGVAdmin(5, fila_actual).Value
            Form5.TxtBxNumeroSerie.Text = DGVAdmin(6, fila_actual).Value
            Form5.RchTxtBxObservaciones.Text = DGVAdmin(7, fila_actual).Value
            Dim fecha_entrada As Date = DGVAdmin(8, fila_actual).Value
            Form5.TxtBxFechaEntrada.Text = fecha_entrada.ToString("yyyy-MM-dd")
            Dim hora_entrada As String = DGVAdmin(9, fila_actual).Value.ToString
            Form5.TxtBxHoraEntrada.Text = hora_entrada
            Dim fecha_registro As Date = DGVAdmin(10, fila_actual).Value
            Dim PeriodoAnalisis As String = DateDiff("d", fecha_entrada, fecha_registro)
            Form5.TxtBxPeriodoAnalisis.Text = PeriodoAnalisis + " dias"
            Form5.TxtBxFechaRegistro.Text = fecha_registro.ToString("yyyy-MM-dd")
            Form5.TxtBxIDMuestra.Text = DGVAdmin(13, fila_actual).Value
            Form5.TxtBxOrigen.Text = DGVAdmin(14, fila_actual).Value
            Form5.TxtBxLote.Text = DGVAdmin(15, fila_actual).Value
            Form5.TxtBxATN.Text = DGVAdmin(16, fila_actual).Value
            Dim tipo_prueba As String = DGVAdmin(17, fila_actual).Value
            If tipo_prueba = 1 Then
                Form5.RBBasica.Checked = True
            ElseIf tipo_prueba = 2 Then
                Form5.RBCompleta.Checked = True
            ElseIf tipo_prueba = 3 Then
                Form5.RBEspecifica.Checked = True
            End If

            Form5.BtnGenerarPDF.Visible = True
            Form5.BtnAceptarReporte.Visible = False
            Form5.BtnRechazarReporte.Visible = False
            Form5.RchTxtBxObservaciones.ReadOnly = True
            Form5.RBCompleta.Enabled = False
            Form5.RBBasica.Enabled = False
            Form5.RBEspecifica.Enabled = False
            Form5.TxtBxOrigen.ReadOnly = True
            Form5.TxtBxLote.ReadOnly = True
            Form5.TxtBxIDMuestra.ReadOnly = True
            Form5.TxtBxATN.ReadOnly = True


            Form5.ShowDialog()


        End If
    End Sub

    Private Sub GenerarReproceso()
        Dim fila_actual As Integer
        Try
            fila_actual = (DGVAdmin.CurrentRow.Index)
        Catch ex As Exception
            MsgBox("Seleccione una fila para continuar", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End Try

        If fila_actual + 1 = DGVAdmin.Rows.Count Then
            Exit Sub
        End If

        Dim id_producto As String = DGVAdmin(0, fila_actual).Value.ToString
        Dim sub_id As Char
        sub_id = id_producto(id_producto.Length - 1)

        If Char.IsNumber(sub_id) Then
            sub_id = "a"
        ElseIf Char.IsLetter(sub_id) Then
            Inc(sub_id)
        End If

        id_producto = id_producto + sub_id
        Dim clienteID As String = DGVAdmin(1, fila_actual).Value
        Dim tipoProducto As String = DGVAdmin(4, fila_actual).Value
        Dim numeroSerie As String = DGVAdmin(6, fila_actual).Value
        Dim observaciones As String = "Re-Proceso"
        Dim estado As String = "Pendiente"
        Dim intervalo As String

        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("SELECT Intervalo from tipo_productos WHERE Tipo_Producto_ID = '" & tipoProducto & "'"), conn)
            intervalo = cmd.ExecuteScalar.ToString
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, False, "Error")
            conn.Close()
            Exit Sub
        End Try

        Dim fecha_registro As String
        Dim fecha_limite As String
        Dim hora_registro As String

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
            Dim cmd As New MySqlCommand(String.Format("SELECT TIME(NOW())"), conn)
            hora_registro = cmd.ExecuteScalar.ToString
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
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

        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("INSERT INTO productos (`ProductoID`, `ClienteID`, `Tipo_Producto_ID`, `Numero_Serie`, `Observaciones`, `Fecha_Entrada`, `Hora_Entrada`, `Fecha_Limite`, `Estado`) VALUES ('" & id_producto & "', '" & clienteID & "', '" & tipoProducto & "', '" & numeroSerie & "', '" & observaciones & "', '" & fecha_registro & "','" & hora_registro & "','" & fecha_limite & "', '" & estado & "');"), conn)
            cmd.ExecuteNonQuery()
            Console.WriteLine("Re-Proceso Registrado")
            MsgBox("Re-proceso Registrado", MsgBoxStyle.Information, "Error")
            conn.Close()
        Catch ex As MySqlException
            MsgBox(ex.Message, False, "Error")
            conn.Close()
            Exit Sub
        End Try
        CargarDGVProductosSinRevisar()
        CargarDGVProductosLimite()
        CargarDGVProductosRevisados()
        ProductosFechaLimiteCerca()
        TxtBxNumeroSerie.Clear()
        TxtBxProductoID.Clear()
        RchTxtBxObservaciones.Clear()
        TxtBxProductoID.Select()



    End Sub

    Public Sub Inc(ByRef c As Char)

        'Remember if input is uppercase for later
        Dim isUpper = Char.IsUpper(c)

        'Work in lower case for ease
        c = Char.ToLower(c)

        'Check input range
        If c < "a" Or c > "z" Then Throw New ArgumentOutOfRangeException

        'Do the increment
        c = Chr(Asc(c) + 1)

        'Check not left alphabet
        If c > "z" Then c = "a"

        'Check if input was upper case
        If isUpper Then c = Char.ToUpper(c)

    End Sub

End Class
