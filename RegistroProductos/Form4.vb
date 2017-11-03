Imports System.Configuration
Imports MySql.Data.MySqlClient

Public Class FormCambiarContraseña
    Dim clienteousuario As Integer
    Dim conn As New MySqlConnection
    Dim nombre_usuario As String

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

    Private Sub FormCambiarContraseña_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect()
        TxBxContraseñaAnterior.Text = ""
        TxBxNuevaContraseña.Text = ""
        TxBxNuevaContraseña2.Text = ""
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        If clienteousuario = 0 Then
            If TxBxContraseñaAnterior.TextLength < 3 Or TxBxNuevaContraseña.TextLength < 3 Or TxBxNuevaContraseña2.TextLength < 3 Then
                MsgBox("Las contraseñas deben tener minimo 3 caracteres", MsgBoxStyle.Exclamation, "Error")
            Else
                Dim reader As MySqlDataReader
                Dim id_usu As String
                Try
                    conn.Open()
                    Dim cmd As New MySqlCommand(String.Format("SELECT UsuarioID from usuarios where usuario = '" & nombre_usuario & "';"), conn)
                    id_usu = cmd.ExecuteScalar.ToString
                    conn.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                    conn.Close()
                    Exit Sub
                End Try
                Dim contraseña_anterior As String = TxBxContraseñaAnterior.Text
                Dim bd_password As String
                Try
                    conn.Open()
                    Dim cmd As New MySqlCommand(String.Format("Select contraseña FROM usuarios
                                                          Where UsuarioID = " & id_usu & ";"), conn)
                    bd_password = Convert.ToString(cmd.ExecuteScalar())
                    conn.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                    conn.Close()
                    Exit Sub
                End Try
                If contraseña_anterior = bd_password Then
                    Dim contraseña_nueva As String = TxBxNuevaContraseña.Text
                    Dim contraseña_nueva2 As String = TxBxNuevaContraseña2.Text
                    If contraseña_nueva = contraseña_nueva2 Then
                        Try
                            conn.Open()
                            Dim query As String = "Update Usuarios set contraseña = '" & contraseña_nueva & "' where UsuarioID = " & id_usu
                            Dim cmd As New MySqlCommand(query, conn)
                            reader = cmd.ExecuteReader
                            MsgBox("Contraseña Actualizada", False, "Contraseña Actualizada")
                            conn.Close()
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                            conn.Close()
                            Exit Sub
                        End Try
                        Me.Close()
                    Else
                        MsgBox("La constraseña nueva no coincide en los dos campos", MsgBoxStyle.Exclamation, "Error")
                    End If
                Else
                    MsgBox("La contraseña ingresada es erronea", MsgBoxStyle.Exclamation, "Error")
                End If
            End If
        ElseIf clienteousuario = 1 Then
            If TxBxContraseñaAnterior.TextLength < 3 Or TxBxNuevaContraseña.TextLength < 3 Or TxBxNuevaContraseña2.TextLength < 3 Then
                MsgBox("Las contraseñas deben tener minimo 3 caracteres", MsgBoxStyle.Exclamation, "Error")
            Else
                Dim reader As MySqlDataReader
                Dim id_usu As String
                Try
                    conn.Open()
                    Dim cmd As New MySqlCommand(String.Format("SELECT ClienteID from clientes where Nombre = '" & nombre_usuario & "';"), conn)
                    id_usu = cmd.ExecuteScalar.ToString
                    conn.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                    conn.Close()
                    Exit Sub
                End Try
                Dim contraseña_anterior As String = TxBxContraseñaAnterior.Text
                Dim bd_password As String
                Try
                    conn.Open()
                    Dim cmd As New MySqlCommand(String.Format("Select contraseña FROM clientes
                                                          Where ClienteID = " & id_usu & ";"), conn)
                    bd_password = Convert.ToString(cmd.ExecuteScalar())
                    conn.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                    conn.Close()
                    Exit Sub
                End Try
                If contraseña_anterior = bd_password Then
                    Dim contraseña_nueva As String = TxBxNuevaContraseña.Text
                    Dim contraseña_nueva2 As String = TxBxNuevaContraseña2.Text
                    If contraseña_nueva = contraseña_nueva2 Then
                        Try
                            conn.Open()
                            Dim query As String = "Update clientes set contraseña = '" & contraseña_nueva & "' where ClienteID = " & id_usu
                            Dim cmd As New MySqlCommand(query, conn)
                            reader = cmd.ExecuteReader
                            MsgBox("Contraseña Actualizada", False, "Contraseña Actualizada")
                            conn.Close()
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                            conn.Close()
                            Exit Sub
                        End Try
                        Me.Close()
                    Else
                        MsgBox("La constraseña nueva no coincide en los dos campos", MsgBoxStyle.Exclamation, "Error")
                    End If
                Else
                    MsgBox("La contraseña ingresada es erronea", MsgBoxStyle.Exclamation, "Error")
                End If
            End If
        End If
    End Sub

    Public Sub RecibirVariablesForm1(usuario As String, Escliente As Integer)
        nombre_usuario = usuario
        clienteousuario = Escliente
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub
End Class