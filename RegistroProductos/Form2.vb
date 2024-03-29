﻿Imports MySql.Data.MySqlClient
Imports System.Configuration

Public Class Form2
    Dim conn As New MySqlConnection
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Form1.ShowDialog()
        Connect()
        CargarClientes()
        CmbBxCliente.SelectedIndex = 0
        TxBxContraseña.Text = ""
        TxtBxContraseñaCliente.Text = ""
        TxtBxUsuario.Text = ""
        Me.TabControl1.TabIndex = 0
        Me.AcceptButton = Me.BtnAceptar
    End Sub

    Public Sub Connect()

        conn.ConnectionString = ConfigurationManager.ConnectionStrings("cs").ConnectionString
        Try
            conn.Open()
            Console.WriteLine("conectandose a la base de datos")
        Catch ex As Exception
            MsgBox(ex.Message)
            End
        End Try
        conn.Close()

    End Sub

    Private Sub CargarClientes()
        Dim query As String = " Select ClienteID, Nombre from Clientes"
        Dim cmd As New MySqlCommand(query, conn)
        Dim sqlAdap As New MySqlDataAdapter(cmd)
        Dim dtRecord As New DataTable
        sqlAdap.Fill(dtRecord)
        CmbBxCliente.DataSource = dtRecord
        CmbBxCliente.DisplayMember = "Nombre"
        CmbBxCliente.ValueMember = "ClienteID"
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        'Form1.TextBoxContraseña.Text = TxBxContraseña.Text
        'Form1.TextBoxRespuestaForm2.Text = "1"
        Form1.Close()
        Dim usuario As String = TxtBxUsuario.Text.Trim
        Dim contraseña As String = TxBxContraseña.Text
        Dim bd_password As String
        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("Select contraseña from usuarios where usuario = '" & usuario & "';"), conn)
            bd_password = Convert.ToString(cmd.ExecuteScalar())
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, False, "Error")
            conn.Close()
            Exit Sub
        End Try

        If bd_password = Nothing Then
            MsgBox("Credenciales de inicio de sesion no validas")
            Exit Sub
        End If

        If contraseña = bd_password Then
            MsgBox("Bienvenido " & usuario & "", False, "Log-In")
            Dim usuario_id As String
            Dim esadmin As String
            Try
                conn.Open()
                Dim cmd As New MySqlCommand(String.Format("Select UsuarioID from usuarios where usuario = '" & usuario & "';"), conn)
                Dim cmd2 As New MySqlCommand(String.Format("Select Admin from usuarios where usuario ='" & usuario & "';"), conn)
                usuario_id = Convert.ToString(cmd.ExecuteScalar())
                esadmin = Convert.ToString(cmd2.ExecuteScalar())
                'Form1.TxBxUsuario.Text = usuario_id
                Form1.RecibirVariablesForm2(usuario)
                Form1.LblUsuario.Text = "Sesion actual: " + usuario
                Form1.LblEsAdmin.Text = esadmin
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message, False, "Error")
                conn.Close()
                Exit Sub
            End Try
            Me.Hide()
            Form1.ShowDialog()
        Else
            MsgBox("Credenciales de inicio de sesion no validas")
            TxBxContraseña.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Form1.Close()
        Me.Close()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Select Case Me.TabControl1.SelectedIndex
            Case Is = 0
                Me.AcceptButton = Me.BtnAceptar
                Me.CancelButton = Me.BtnCancelar
            Case Is = 1
                Me.AcceptButton = Me.BtnAceptarCliente
                Me.CancelButton = Me.BtnCancelarCliente
        End Select
    End Sub

    Private Sub BtnAceptarCliente_Click(sender As Object, e As EventArgs) Handles BtnAceptarCliente.Click
        Dim cliente As Integer = CmbBxCliente.SelectedValue
        Dim contraseña As String = TxtBxContraseñaCliente.Text
        Dim bd_password As String
        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("Select contraseña from clientes where ClienteID = '" & cliente & "';"), conn)
            bd_password = Convert.ToString(cmd.ExecuteScalar())
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, False, "Error")
            conn.Close()
            Exit Sub
        End Try

        If bd_password = Nothing Then
            MsgBox("Credenciales de inicio de sesion no validas")
            Exit Sub
        End If

        If contraseña = bd_password Then
            MsgBox("Conectado como: " & CmbBxCliente.Text & "", False, "Log-In")
            Form6.RecibirClienteId(cliente)
            Me.Hide()
            Form6.AnalistaOCliente(0)
            Form6.ShowDialog()
        Else
            MsgBox("Credenciales de inicio de sesion no validas")
            TxBxContraseña.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub BtnCancelarCliente_Click(sender As Object, e As EventArgs) Handles BtnCancelarCliente.Click
        Me.Close()
    End Sub
End Class