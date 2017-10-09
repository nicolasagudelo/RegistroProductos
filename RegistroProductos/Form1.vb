Imports MySql.Data.MySqlClient
Imports System.Configuration

Public Class Form1

    Dim conn As New MySqlConnection

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect()
        CargarDGVProductosSinRevisar()
        CargarDGVProductosLimite()
        ProductosFechaLimiteCerca()
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
        Dim query As String = "SELECT ProductoID, Clientes.Nombre as 'Cliente', tipo_productos.Nombre as 'Tipo de Mercancia', Numero_Serie as 'Numero de Serie', Observaciones, Fecha_Entrada, Fecha_Limite, Estado
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
            MsgBox(ex.Message, "Error")
            conn.Close()
        End Try
    End Sub

    Public Sub ProductosFechaLimiteCerca()
        Dim filas_total As Integer = DGVProductosSinRevisar.RowCount
        Dim fecha_servidor As Date
        Dim hoy As String
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

        Dim fecha_limite As Date
        Dim fecha_limite_string As String
        For i = 0 To filas_total - 2
            fecha_limite = DGVProductosSinRevisar(6, i).Value
            fecha_limite_string = fecha_limite.ToString("yyyy-MM-dd")

            If DateDiff("d", fecha_servidor, fecha_limite) <= 10 Then
                DGVProductosSinRevisar.Rows(i).DefaultCellStyle.ForeColor = Color.Red
            End If

        Next
    End Sub

    Public Sub CargarDGVProductosLimite()
        Dim query As String = "SELECT ProductoID, Clientes.Nombre as 'Cliente', tipo_productos.Nombre as 'Tipo de Mercancia', Numero_Serie as 'Numero de Serie', Observaciones, Fecha_Entrada, Fecha_Limite, Estado
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
            DGVProductosLimite.DefaultCellStyle.ForeColor = Color.Red
            reader.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, "Error")
            conn.Close()
        End Try
    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Form2.Close()
    End Sub

    Private Sub BtnDesconectar_Click(sender As Object, e As EventArgs) Handles BtnDesconectar.Click
        MsgBox("Desconectado!")
        Form2.TxBxContraseña.Text = ""
        Form2.TxtBxUsuario.Text = ""
        Form2.TxtBxUsuario.Select()
        Me.Hide()
        Form2.Show()
    End Sub
End Class
