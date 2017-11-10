Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.IO
Imports System.Decimal

Public Class Form3
    Dim conn As New MySqlConnection

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        control = 0
        Connect()
        CargarPruebasProducto()
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

    Dim CheckBoxButtonArray() As CheckBox
    Dim TextBoxArray() As TextBox
    Dim cod_prue As New List(Of String)()
    Dim pruebasproducto As Integer
    Dim nombre_prueba As New List(Of String)()

    Private Sub CargarPruebasProducto()
        cod_prue.Clear()
        nombre_prueba.Clear()
        Dim ProductoID As String = TxtBxIDProducto.Text

        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("select count(*) from pruebasxproducto where ProductoID = '" & ProductoID & "';"), conn)
            pruebasproducto = cmd.ExecuteScalar
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, False, "Error")
            conn.Close()
        End Try

        ReDim CheckBoxButtonArray(pruebasproducto)
        ReDim TextBoxArray(pruebasproducto)

        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("select ID_Prueba from pruebasxproducto where ProductoID = '" & ProductoID & "';"), conn)
            Dim dr = cmd.ExecuteReader
            While dr.Read
                cod_prue.Add(dr("ID_Prueba").ToString())
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, False, "Error")
            conn.Close()
        End Try

        For Each item As String In cod_prue
            Try
                conn.Open()
                Dim cmd As New MySqlCommand(String.Format("select Nombre from pruebas where ID_Prueba = '" & item & "';"), conn)
                Dim dr = cmd.ExecuteReader
                While dr.Read
                    nombre_prueba.Add(dr("nombre").ToString())
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message, False, "Error")
                conn.Close()
            End Try
        Next

        For Each item As String In cod_prue
            Console.WriteLine(item)
        Next

        Panel1.Controls.Clear()

        Dim X1, Y1, Y2 As Integer
        Dim deltay As Integer = 70
        For i = 0 To pruebasproducto - 1
            X1 = 7
            If i = 0 Then
                Y1 = 15
                Y2 = 40
            Else
                Y1 = Y1 + deltay
                Y2 = Y2 + deltay
            End If
            CheckBoxButtonArray(i) = New CheckBox With {
                .Location = New Point(X1, Y1),
                .Text = cod_prue(i).ToString + " " + nombre_prueba(i) + ":",
                .AutoEllipsis = True,
                .AutoSize = True, '.Width = 300,'.Height = 20,
                .ForeColor = Color.Black,
                .Visible = True,
                .Parent = Me.Panel1,
                .Name = i.ToString,
                .Checked = True
            }
            TextBoxArray(i) = New TextBox With {
                .Location = New Point(X1, Y2),
                .Size = New Size(300, 40),
                .Enabled = True,
                .Visible = True,
                .Parent = Me.Panel1,
                .Name = "TxtBx" + cod_prue(i).ToString
            }

            'If cod_prue(i).ToString = "D-130-2" Or cod_prue(i).ToString = "D-86-9" Then
            '    ButtonArray(tamaniobuttonarray) = New Button With {
            '    .Location = New Point(332, Y2),
            '    .Size = New Size(66, 40),
            '    .Enabled = True,
            '    .Visible = True,
            '    .Parent = Me.Panel1,
            '    .Text = "Calculo",
            '    .Name = "Button" + cod_prue(i).ToString
            '    }
            '    AddHandler ButtonArray(tamaniobuttonarray).Click, AddressOf Button_Clicked
            '    tamaniobuttonarray += 1
            'End If

            AddHandler CheckBoxButtonArray(i).Click, AddressOf CheckBox_Clicked
        Next
    End Sub

    Private Sub RBSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles RBSeleccionarTodo.CheckedChanged
        If RBSeleccionarTodo.Checked = True Then
            For i As Integer = 0 To pruebasproducto - 1
                CheckBoxButtonArray(i).Checked = True
                TextBoxArray(i).Enabled = True
            Next
        End If
    End Sub

    Private Sub RBQuitarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles RBQuitarTodo.CheckedChanged
        If RBQuitarTodo.Checked = True Then
            For i As Integer = 0 To pruebasproducto - 1
                CheckBoxButtonArray(i).Checked = False
                TextBoxArray(i).Enabled = False
            Next
        End If
    End Sub

    Private Sub CheckBox_Clicked(sender As Object, e As EventArgs)
        Dim Cb As CheckBox = CType(sender, CheckBox)
        If Cb.Checked = True Then
            TextBoxArray(Cb.Name).Enabled = True
        Else
            TextBoxArray(Cb.Name).Enabled = False
            TextBoxArray(Cb.Name).Text = ""
        End If
    End Sub

    'Private Sub Button_Clicked(sender As Object, e As EventArgs)
    '    Dim bt As Button = CType(sender, Button)
    '    Console.WriteLine(bt.Name.ToString)
    '    If bt.Name = "ButtonD-130-2" Then
    '        Dim prueba As String = bt.Name.ToString.Substring(6)
    '        For i As Integer = 0 To pruebasproducto - 1
    '            If TextBoxArray(i).Name = "TxtBx" + prueba Then
    '                TextBoxArray(i).Text = "Calculo!"
    '            End If
    '        Next
    '    End If
    'End Sub

    Private Sub ButtonRegistrarReporte_Click(sender As Object, e As EventArgs) Handles BtnRegistrarReporte.Click
        Dim ProductoID As String = TxtBxIDProducto.Text
        Dim Fecha_Ingreso As String = TxtBxFechaEntrada.Text
        Dim Hora_Ingreso As String = TxtBxHoraEntrada.Text
        Dim Fecha_Reporte As String = TxtBxFechaRegistro.Text
        Dim ClienteID As String = TxtBxClienteID.Text
        Dim TipoProducto As String = TxtBxTipoProductoID.Text
        Dim Observaciones As String = RchTxtBxObservaciones.Text
        Dim UsuarioID As String = TxtBxIdUsuario.Text
        Dim ObservacionesAnalista As String = RchTxtBxObservaciones.Text

        Dim checks As Integer = 0

        For i = 0 To pruebasproducto - 1
            If TextBoxArray(i).Enabled = True Then
                checks += 1
                If TextBoxArray(i).Text.Trim = "" Then
                    MsgBox("El valor para la prueba" & cod_prue(i) & " esta vacio, Asignele un valor o desmarquelo antes de continuar", False, "Error")
                    Exit Sub
                End If
            End If
        Next
        If checks = 0 Then
            MsgBox("Eliga alguna prueba para reportar", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        Dim steps As Integer = 100 / checks
        Dim max = (steps * pruebasproducto) - steps
        ProgressBar1.Maximum = max

        For i = 0 To pruebasproducto - 1
            If TextBoxArray(i).Enabled = True Then
                'MsgBox(cod_prue(i) & "-" & nombre_prueba(i) & "-" & TextBoxArray(i).Text)
                Dim ID_Prueba As String = cod_prue(i)
                Dim valor As String = TextBoxArray(i).Text
                Dim existevalor As Boolean
                Dim existevalor2 As Boolean
                Dim existevalor3 As Boolean
                Dim existevalor4 As Boolean
                Dim existevalor5 As Boolean

                Try
                    conn.Open()
                    Dim cmd As New MySqlCommand(String.Format("Select Valor from reportes where ProductoID  ='" & ProductoID & "' and ID_Prueba = '" & cod_prue(i) & "';"), conn)
                    Dim var = cmd.ExecuteScalar
                    If var Is Nothing Then
                        existevalor = False
                    Else
                        existevalor = True
                    End If
                    conn.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                    conn.Close()
                    Exit Sub
                End Try

                Try
                    conn.Open()
                    Dim cmd As New MySqlCommand(String.Format("Select Valor_2 from reportes where ProductoID  ='" & ProductoID & "' and ID_Prueba = '" & cod_prue(i) & "';"), conn)
                    Dim reader As MySqlDataReader
                    reader = cmd.ExecuteReader
                    If reader.Read() Then

                        If reader.IsDBNull(0) Then
                            existevalor2 = False
                        Else
                            existevalor2 = True
                        End If
                    End If
                    conn.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                    conn.Close()
                    Exit Sub
                End Try

                Try
                    conn.Open()
                    Dim cmd As New MySqlCommand(String.Format("Select Valor_3 from reportes where ProductoID  ='" & ProductoID & "' and ID_Prueba = '" & cod_prue(i) & "';"), conn)
                    Dim reader As MySqlDataReader
                    reader = cmd.ExecuteReader
                    If reader.Read() Then

                        If reader.IsDBNull(0) Then
                            existevalor3 = False
                        Else
                            existevalor3 = True
                        End If
                    End If
                    conn.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                    conn.Close()
                    Exit Sub
                End Try

                Try
                    conn.Open()
                    Dim cmd As New MySqlCommand(String.Format("Select Valor_4 from reportes where ProductoID  ='" & ProductoID & "' and ID_Prueba = '" & cod_prue(i) & "';"), conn)
                    Dim reader As MySqlDataReader
                    reader = cmd.ExecuteReader
                    If reader.Read() Then

                        If reader.IsDBNull(0) Then
                            existevalor4 = False
                        Else
                            existevalor4 = True
                        End If
                    End If
                    conn.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                    conn.Close()
                    Exit Sub
                End Try

                Try
                    conn.Open()
                    Dim cmd As New MySqlCommand(String.Format("Select Valor_5 from reportes where ProductoID  ='" & ProductoID & "' and ID_Prueba = '" & cod_prue(i) & "';"), conn)
                    Dim reader As MySqlDataReader
                    reader = cmd.ExecuteReader
                    If reader.Read() Then

                        If reader.IsDBNull(0) Then
                            existevalor5 = False
                        Else
                            existevalor5 = True
                        End If
                    End If
                    conn.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                    conn.Close()
                    Exit Sub
                End Try

                Dim rutavacia As Integer = 0

                If TxtBxRuta.Text.Trim = "" Then
                    rutavacia = 1
                    If MessageBox.Show("¿Esta seguro de que desea dejar la ruta de datos en blanco?", "Advertencia", MessageBoxButtons.YesNo) = DialogResult.No Then
                        Exit Sub
                    End If
                End If

                If rutavacia = 0 Then

                    Dim filepath As String = TxtBxRuta.Text

                    Dim numero_de_lineas = File.ReadAllLines(filepath).Length

                    Dim sData() As String
                    Dim IDPrueba, Valor1, Valor2, Valor3, Valor4, Valor5, Valor6, Valor7, Valor8, Valor9, Valor10 As New List(Of String)()

                    Using sr As New StreamReader(filepath)
                        While Not sr.EndOfStream
                            sData = sr.ReadLine().Split(";"c)

                            IDPrueba.Add(sData(0).Trim())
                            Try
                                Valor1.Add(sData(1).Trim())
                                Valor2.Add(sData(2).Trim())
                                Valor3.Add(sData(3).Trim())
                                Valor4.Add(sData(4).Trim())
                                Valor5.Add(sData(5).Trim())
                                Valor6.Add(sData(6).Trim())
                                Valor7.Add(sData(7).Trim())
                                Valor8.Add(sData(8).Trim())
                                Valor9.Add(sData(9).Trim())
                                Valor10.Add(sData(10).Trim())
                            Catch ex As Exception

                            End Try

                        End While
                    End Using

                    For j As Integer = 0 To numero_de_lineas - 1

                        If ID_Prueba = "D-3242" And IDPrueba(j) = "D-3242" Then

                            Dim WP As Double
                            Dim V As Double
                            Dim Vb As Double
                            Double.TryParse(Valor1(j), WP)
                            Double.TryParse(Valor2(j), V)
                            Double.TryParse(Valor3(j), Vb)
                            Dim Normalidad As Decimal

                            Normalidad = (WP / 204.23) * (1000 / (V - Vb))
                            Normalidad = Round(Normalidad, 4)

                            Dim W As Double
                            Dim A As Double
                            Dim B As Double
                            Dim Tm As Double
                            Double.TryParse(Valor4(j), W)
                            Double.TryParse(Valor5(j), A)
                            Double.TryParse(Valor6(j), B)
                            Double.TryParse(Valor7(j), Tm)

                            Dim Acidez As Decimal

                            Acidez = ((A - B) * Normalidad * 56.1) / W
                            Acidez = Round(Acidez, 3)

                            Dim llave As String

                            Try
                                conn.Open()
                                Dim cmd As New MySqlCommand(String.Format("SELECT MAX(DatoID)+1 FROM datosproducto;"), conn)
                                llave = Convert.ToString(cmd.ExecuteScalar())
                                conn.Close()
                                If llave = Nothing Then
                                    llave = "1"
                                End If
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                            Try
                                conn.Open()
                                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`, `Dato_4`, `Dato_5`, `Dato_6`, `Dato_7`, `Dato_8`, `Dato_9`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', 'D-3242', '" & WP & "', '" & V & "', '" & Vb & "', '" & Normalidad & "', '" & W & "', '" & A & "', '" & B & "', '" & Tm & "', '" & Acidez & "');"), conn)
                                cmd.ExecuteNonQuery()
                                Console.WriteLine("Datos Registrados")
                                conn.Close()
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                        ElseIf ID_Prueba = "D-1319-01" And IDPrueba(j) = "D-1319-01" Then

                            Dim Lt1 As Double
                            Dim Lt2 As Double
                            Dim Lt3 As Double
                            Dim Lt4 As Double
                            Dim La1 As Double
                            Dim La2 As Double
                            Dim La3 As Double
                            Dim La4 As Double
                            Double.TryParse(Valor1(j), Lt1)
                            Double.TryParse(Valor2(j), Lt2)
                            Double.TryParse(Valor3(j), Lt3)
                            Double.TryParse(Valor4(j), Lt4)
                            Double.TryParse(Valor5(j), La1)
                            Double.TryParse(Valor6(j), La2)
                            Double.TryParse(Valor7(j), La3)
                            Double.TryParse(Valor8(j), La4)

                            Dim calc1 As Decimal = (La1 / Lt1) * 100
                            Dim calc2 As Decimal = (La2 / Lt2) * 100
                            Dim calc3 As Decimal = (La3 / Lt3) * 100
                            Dim calc4 As Decimal = (La4 / Lt4) * 100

                            calc1 = Round(calc1, 1)
                            calc2 = Round(calc2, 1)
                            calc3 = Round(calc3, 1)
                            calc4 = Round(calc4, 1)

                            Dim prom As Decimal = (calc1 + calc2 + calc3 + calc4) / 4

                            prom = Round(prom, 1)

                            Dim llave As String

                            Try
                                conn.Open()
                                Dim cmd As New MySqlCommand(String.Format("SELECT MAX(DatoID)+1 FROM datosproducto;"), conn)
                                llave = Convert.ToString(cmd.ExecuteScalar())
                                conn.Close()
                                If llave = Nothing Then
                                    llave = "1"
                                End If
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                            Try
                                conn.Open()
                                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`, `Dato_4`, `Dato_5`, `Dato_6`, `Dato_7`, `Dato_8`, `Dato_9`, `Dato_10`, `Dato_11`, `Dato_12`, `Dato_13`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', 'D-1319-01', '" & Lt1 & "', '" & Lt2 & "', '" & Lt3 & "', '" & Lt4 & "', '" & La1 & "', '" & La2 & "', '" & La3 & "', '" & La4 & "', '" & calc1 & "', '" & calc2 & "', '" & calc3 & "', '" & calc4 & "', '" & prom & "');"), conn)
                                cmd.ExecuteNonQuery()
                                Console.WriteLine("Datos Registrados")
                                conn.Close()
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                        ElseIf ID_Prueba = "D-1319-02" And IDPrueba(j) = "D-1319-02" Then

                            Dim Lt1 As Double
                            Dim Lt2 As Double
                            Dim Lt3 As Double
                            Dim Lt4 As Double
                            Dim Lo1 As Double
                            Dim Lo2 As Double
                            Dim Lo3 As Double
                            Dim Lo4 As Double
                            Double.TryParse(Valor1(j), Lt1)
                            Double.TryParse(Valor2(j), Lt2)
                            Double.TryParse(Valor3(j), Lt3)
                            Double.TryParse(Valor4(j), Lt4)
                            Double.TryParse(Valor5(j), Lo1)
                            Double.TryParse(Valor6(j), Lo2)
                            Double.TryParse(Valor7(j), Lo3)
                            Double.TryParse(Valor8(j), Lo4)

                            Dim calc1 As Decimal = (Lo1 / Lt1) * 100
                            Dim calc2 As Decimal = (Lo2 / Lt2) * 100
                            Dim calc3 As Decimal = (Lo3 / Lt3) * 100
                            Dim calc4 As Decimal = (Lo4 / Lt4) * 100

                            calc1 = Round(calc1, 1)
                            calc2 = Round(calc2, 1)
                            calc3 = Round(calc3, 1)
                            calc4 = Round(calc4, 1)

                            Dim prom As Decimal = (calc1 + calc2 + calc3 + calc4) / 4

                            prom = Round(prom, 1)

                            Dim llave As String

                            Try
                                conn.Open()
                                Dim cmd As New MySqlCommand(String.Format("SELECT MAX(DatoID)+1 FROM datosproducto;"), conn)
                                llave = Convert.ToString(cmd.ExecuteScalar())
                                conn.Close()
                                If llave = Nothing Then
                                    llave = "1"
                                End If
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                            Try
                                conn.Open()
                                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`, `Dato_4`, `Dato_5`, `Dato_6`, `Dato_7`, `Dato_8`, `Dato_9`, `Dato_10`, `Dato_11`, `Dato_12`, `Dato_13`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', 'D-1319-02', '" & Lt1 & "', '" & Lt2 & "', '" & Lt3 & "', '" & Lt4 & "', '" & Lo1 & "', '" & Lo2 & "', '" & Lo3 & "', '" & Lo4 & "', '" & calc1 & "', '" & calc2 & "', '" & calc3 & "', '" & calc4 & "', '" & prom & "');"), conn)
                                cmd.ExecuteNonQuery()
                                Console.WriteLine("Datos Registrados")
                                conn.Close()
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                        ElseIf ID_Prueba = "D-1319-03" And IDPrueba(j) = "D-1319-03" Then

                            Dim Lt1 As Double
                            Dim Lt2 As Double
                            Dim Lt3 As Double
                            Dim Lt4 As Double
                            Dim Li1 As Double
                            Dim Li2 As Double
                            Dim Li3 As Double
                            Dim Li4 As Double
                            Double.TryParse(Valor1(j), Lt1)
                            Double.TryParse(Valor2(j), Lt2)
                            Double.TryParse(Valor3(j), Lt3)
                            Double.TryParse(Valor4(j), Lt4)
                            Double.TryParse(Valor5(j), Li1)
                            Double.TryParse(Valor6(j), Li2)
                            Double.TryParse(Valor7(j), Li3)
                            Double.TryParse(Valor8(j), Li4)

                            Dim calc1 As Decimal = (Li1 / Lt1) * 100
                            Dim calc2 As Decimal = (Li2 / Lt2) * 100
                            Dim calc3 As Decimal = (Li3 / Lt3) * 100
                            Dim calc4 As Decimal = (Li4 / Lt4) * 100

                            calc1 = Round(calc1, 1)
                            calc2 = Round(calc2, 1)
                            calc3 = Round(calc3, 1)
                            calc4 = Round(calc4, 1)

                            Dim prom As Decimal = (calc1 + calc2 + calc3 + calc4) / 4

                            prom = Round(prom, 1)

                            Dim llave As String

                            Try
                                conn.Open()
                                Dim cmd As New MySqlCommand(String.Format("SELECT MAX(DatoID)+1 FROM datosproducto;"), conn)
                                llave = Convert.ToString(cmd.ExecuteScalar())
                                conn.Close()
                                If llave = Nothing Then
                                    llave = "1"
                                End If
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                            Try
                                conn.Open()
                                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`, `Dato_4`, `Dato_5`, `Dato_6`, `Dato_7`, `Dato_8`, `Dato_9`, `Dato_10`, `Dato_11`, `Dato_12`, `Dato_13`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', 'D-1319-03', '" & Lt1 & "', '" & Lt2 & "', '" & Lt3 & "', '" & Lt4 & "', '" & Li1 & "', '" & Li2 & "', '" & Li3 & "', '" & Li4 & "', '" & calc1 & "', '" & calc2 & "', '" & calc3 & "', '" & calc4 & "', '" & prom & "');"), conn)
                                cmd.ExecuteNonQuery()
                                Console.WriteLine("Datos Registrados")
                                conn.Close()
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                        ElseIf ID_Prueba = "D-1840" And IDPrueba(j) = "D-1840" Then

                            Dim A As Double
                            Dim W As Double
                            Dim K As Double
                            Dim PromAbsor As Double
                            Dim B As Double
                            Dim C As Double

                            Double.TryParse(Valor1(j), A)
                            Double.TryParse(Valor2(j), W)
                            Double.TryParse(Valor3(j), K)
                            Double.TryParse(Valor4(j), PromAbsor)
                            Double.TryParse(Valor5(j), B)
                            Double.TryParse(Valor6(j), C)

                            Dim M As Decimal = ((A * K) / (33.7 * W)) * 100
                            Dim BC As Decimal = B / C
                            Dim Vol As Decimal = M * BC

                            Vol = Round(Vol, 2)

                            Dim llave As String

                            Try
                                conn.Open()
                                Dim cmd As New MySqlCommand(String.Format("SELECT MAX(DatoID)+1 FROM datosproducto;"), conn)
                                llave = Convert.ToString(cmd.ExecuteScalar())
                                conn.Close()
                                If llave = Nothing Then
                                    llave = "1"
                                End If
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                            Try
                                conn.Open()
                                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`, `Dato_4`, `Dato_5`, `Dato_6`, `Dato_7`, `Dato_8`, `Dato_9`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', 'D-1840', '" & A & "', '" & W & "', '" & K & "', '" & PromAbsor & "', '" & B & "', '" & C & "', '" & M & "', '" & BC & "', '" & Vol & "');"), conn)
                                cmd.ExecuteNonQuery()
                                Console.WriteLine("Datos Registrados")
                                conn.Close()
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                        ElseIf ID_Prueba = "D-1322" And IDPrueba(j) = "D-1322" Then

                            Dim FactorCorreccion As Double
                            Dim PresionBar As Double
                            Dim TempMues As Double
                            Dim Lec1 As Double
                            Dim Lec2 As Double
                            Dim Lec3 As Double
                            Dim Turbidez As String
                            Dim Filtracion As String

                            Double.TryParse(Valor1(j), FactorCorreccion)
                            Double.TryParse(Valor2(j), PresionBar)
                            Double.TryParse(Valor3(j), TempMues)
                            Double.TryParse(Valor4(j), Lec1)
                            Double.TryParse(Valor5(j), Lec2)
                            Double.TryParse(Valor6(j), Lec3)
                            Turbidez = Valor7(j)
                            Filtracion = Valor8(j)

                            Dim prom As Decimal = (Lec1 + Lec2 + Lec3) / 3

                            Dim Val As Decimal = prom * FactorCorreccion

                            Val = Math.Round((valor * 2)) / 2

                            Dim llave As String


                            Try
                                conn.Open()
                                Dim cmd As New MySqlCommand(String.Format("SELECT MAX(DatoID)+1 FROM datosproducto;"), conn)
                                llave = Convert.ToString(cmd.ExecuteScalar())
                                conn.Close()
                                If llave = Nothing Then
                                    llave = "1"
                                End If
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                            Try
                                conn.Open()
                                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`, `Dato_4`, `Dato_5`, `Dato_6`, `Dato_7`, `Dato_8`, `Dato_9`, `Dato_10`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', 'D-1322', '" & Turbidez & "', '" & Filtracion & "', '" & PresionBar & "', '" & TempMues & "', '" & Lec1 & "', '" & Lec2 & "', '" & Lec3 & "', '" & prom & "', '" & FactorCorreccion & "', '" & Val & "');"), conn)
                                cmd.ExecuteNonQuery()
                                Console.WriteLine("Datos Registrados")
                                conn.Close()
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                        ElseIf ID_Prueba = "D-56" And IDPrueba(j) = "D-56" Then

                            Dim TempMues As Double
                            Dim PresionBar As Double
                            Dim PuntoChispa As Double

                            Double.TryParse(Valor1(j), TempMues)
                            Double.TryParse(Valor2(j), PresionBar)
                            Double.TryParse(Valor3(j), PuntoChispa)

                            Dim PuntoChispaCorregido As Decimal = PuntoChispa + 0.25 * (101.3 - PresionBar)

                            PuntoChispaCorregido = Math.Round((PuntoChispaCorregido * 2)) / 2

                            Dim llave As String


                            Try
                                conn.Open()
                                Dim cmd As New MySqlCommand(String.Format("SELECT MAX(DatoID)+1 FROM datosproducto;"), conn)
                                llave = Convert.ToString(cmd.ExecuteScalar())
                                conn.Close()
                                If llave = Nothing Then
                                    llave = "1"
                                End If
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                            Try
                                conn.Open()
                                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`, `Dato_4`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', 'D-56', '" & TempMues & "', '" & PresionBar & "', '" & PuntoChispa & "', '" & PuntoChispaCorregido & "');"), conn)
                                cmd.ExecuteNonQuery()
                                Console.WriteLine("Datos Registrados")
                                conn.Close()
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                        ElseIf ID_Prueba = "D-93" And IDPrueba(j) = "D-93" Then

                            Dim TempMues As Double
                            Dim PresionBar As Double
                            Dim PuntoChispa As Double

                            Double.TryParse(Valor1(j), TempMues)
                            Double.TryParse(Valor2(j), PresionBar)
                            Double.TryParse(Valor3(j), PuntoChispa)

                            Dim PuntoChispaCorregido As Decimal = PuntoChispa + 0.25 * (101.3 - PresionBar)

                            PuntoChispaCorregido = Math.Round((PuntoChispaCorregido * 2)) / 2

                            Dim llave As String


                            Try
                                conn.Open()
                                Dim cmd As New MySqlCommand(String.Format("SELECT MAX(DatoID)+1 FROM datosproducto;"), conn)
                                llave = Convert.ToString(cmd.ExecuteScalar())
                                conn.Close()
                                If llave = Nothing Then
                                    llave = "1"
                                End If
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                            Try
                                conn.Open()
                                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`, `Dato_4`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', 'D-93', '" & TempMues & "', '" & PresionBar & "', '" & PuntoChispa & "', '" & PuntoChispaCorregido & "');"), conn)
                                cmd.ExecuteNonQuery()
                                Console.WriteLine("Datos Registrados")
                                conn.Close()
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                        ElseIf ID_Prueba = "D-4294-01" And IDPrueba(j) = "D-4294-01" Then

                            Dim AguaSuspendida As String
                            Dim Homogeniziacion As String
                            Dim muestra1 As Double
                            Dim muestra2 As Double

                            AguaSuspendida = Valor1(j)
                            Homogeniziacion = Valor2(j)
                            Double.TryParse(Valor3(j), muestra1)
                            Double.TryParse(Valor4(j), muestra2)

                            Dim prom As Decimal

                            If muestra2 = 0 Then
                                prom = muestra1
                                prom = Round(prom, 4)

                                Dim llave As String


                                Try
                                    conn.Open()
                                    Dim cmd As New MySqlCommand(String.Format("SELECT MAX(DatoID)+1 FROM datosproducto;"), conn)
                                    llave = Convert.ToString(cmd.ExecuteScalar())
                                    conn.Close()
                                    If llave = Nothing Then
                                        llave = "1"
                                    End If
                                Catch ex As Exception
                                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                    conn.Close()
                                    Exit Sub
                                End Try

                                Try
                                    conn.Open()
                                    Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`, `Dato_5`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', 'D-4294-01', '" & AguaSuspendida & "', '" & Homogeniziacion & "', '" & muestra1 & "', '" & prom & "');"), conn)
                                    cmd.ExecuteNonQuery()
                                    Console.WriteLine("Datos Registrados")
                                    conn.Close()
                                Catch ex As Exception
                                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                    conn.Close()
                                    Exit Sub
                                End Try

                            Else
                                prom = (muestra1 + muestra2) / 2

                                prom = Round(prom, 4)

                                Dim llave As String


                                Try
                                    conn.Open()
                                    Dim cmd As New MySqlCommand(String.Format("SELECT MAX(DatoID)+1 FROM datosproducto;"), conn)
                                    llave = Convert.ToString(cmd.ExecuteScalar())
                                    conn.Close()
                                    If llave = Nothing Then
                                        llave = "1"
                                    End If
                                Catch ex As Exception
                                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                    conn.Close()
                                    Exit Sub
                                End Try

                                Try
                                    conn.Open()
                                    Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`, `Dato_4`, `Dato_5`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', 'D-4294-01', '" & AguaSuspendida & "', '" & Homogeniziacion & "', '" & muestra1 & "', '" & muestra2 & "', '" & prom & "');"), conn)
                                    cmd.ExecuteNonQuery()
                                    Console.WriteLine("Datos Registrados")
                                    conn.Close()
                                Catch ex As Exception
                                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                    conn.Close()
                                    Exit Sub
                                End Try

                            End If



                        ElseIf ID_Prueba = "D-4294-02" And IDPrueba(j) = "D-4294-02" Then

                            Dim AguaSuspendida As String
                            Dim Homogeniziacion As String
                            Dim muestra1 As Double
                            Dim muestra2 As Double

                            AguaSuspendida = Valor1(j)
                            Homogeniziacion = Valor2(j)
                            Double.TryParse(Valor3(j), muestra1)
                            Double.TryParse(Valor4(j), muestra2)

                            Dim prom As Decimal

                            If muestra2 = 0 Then
                                prom = muestra1
                                prom = Round(prom, 4)

                                Dim llave As String


                                Try
                                    conn.Open()
                                    Dim cmd As New MySqlCommand(String.Format("SELECT MAX(DatoID)+1 FROM datosproducto;"), conn)
                                    llave = Convert.ToString(cmd.ExecuteScalar())
                                    conn.Close()
                                    If llave = Nothing Then
                                        llave = "1"
                                    End If
                                Catch ex As Exception
                                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                    conn.Close()
                                    Exit Sub
                                End Try

                                Try
                                    conn.Open()
                                    Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`, `Dato_5`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', 'D-4294-02', '" & AguaSuspendida & "', '" & Homogeniziacion & "', '" & muestra1 & "', '" & prom & "');"), conn)
                                    cmd.ExecuteNonQuery()
                                    Console.WriteLine("Datos Registrados")
                                    conn.Close()
                                Catch ex As Exception
                                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                    conn.Close()
                                    Exit Sub
                                End Try

                            Else
                                prom = (muestra1 + muestra2) / 2

                                prom = Round(prom, 4)

                                Dim llave As String


                                Try
                                    conn.Open()
                                    Dim cmd As New MySqlCommand(String.Format("SELECT MAX(DatoID)+1 FROM datosproducto;"), conn)
                                    llave = Convert.ToString(cmd.ExecuteScalar())
                                    conn.Close()
                                    If llave = Nothing Then
                                        llave = "1"
                                    End If
                                Catch ex As Exception
                                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                    conn.Close()
                                    Exit Sub
                                End Try

                                Try
                                    conn.Open()
                                    Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`, `Dato_4`, `Dato_5`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', 'D-4294-02', '" & AguaSuspendida & "', '" & Homogeniziacion & "', '" & muestra1 & "', '" & muestra2 & "', '" & prom & "');"), conn)
                                    cmd.ExecuteNonQuery()
                                    Console.WriteLine("Datos Registrados")
                                    conn.Close()
                                Catch ex As Exception
                                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                    conn.Close()
                                    Exit Sub
                                End Try

                            End If

                        End If

                    Next

                End If

                If existevalor = False Then

                        Try
                            conn.Open()
                            Dim cmd As New MySqlCommand(String.Format("INSERT INTO reportes (`ProductoID`, `ClienteID`, `Tipo_Producto_ID`, `Fecha_Ingreso`, `Hora_Ingreso`, `Fecha_Reporte`, `ID_Prueba`, `Valor`, `UsuarioID`) VALUES ('" & ProductoID & "', '" & ClienteID & "', '" & TipoProducto & "', '" & Fecha_Ingreso & "', '" & Hora_Ingreso & "', '" & Fecha_Reporte & "', '" & ID_Prueba & "', '" & valor & "', '" & UsuarioID & "');"), conn)
                            cmd.ExecuteNonQuery()
                            Console.WriteLine("Reporte Registrado")
                            'MsgBox("Reporte Registrado", False, "Reporte Registrado")
                            conn.Close()
                        Catch ex As Exception
                            MsgBox(ex.Message, False, "Error")
                            conn.Close()
                            Exit Sub
                        End Try
                    Else
                        If existevalor2 = False Then
                            Try
                                conn.Open()
                                Dim cmd As New MySqlCommand(String.Format("UPDATE `bd_productos`.`reportes` SET `Valor_2`='" & valor & "' WHERE `ProductoID`='" & ProductoID & "' and`ID_Prueba`='" & ID_Prueba & "';"), conn)
                                cmd.ExecuteNonQuery()
                                Console.WriteLine("Reporte Registrado")
                                'MsgBox("Reporte Registrado", False, "Reporte Registrado")
                                conn.Close()
                            Catch ex As Exception
                                MsgBox(ex.Message, False, "Error")
                                conn.Close()
                                Exit Sub
                            End Try
                        Else
                            If existevalor3 = False Then
                                Try
                                    conn.Open()
                                    Dim cmd As New MySqlCommand(String.Format("UPDATE `bd_productos`.`reportes` SET `Valor_3`='" & valor & "' WHERE `ProductoID`='" & ProductoID & "' and`ID_Prueba`='" & ID_Prueba & "';"), conn)
                                    cmd.ExecuteNonQuery()
                                    Console.WriteLine("Reporte Registrado")
                                    'MsgBox("Reporte Registrado", False, "Reporte Registrado")
                                    conn.Close()
                                Catch ex As Exception
                                    MsgBox(ex.Message, False, "Error")
                                    conn.Close()
                                    Exit Sub
                                End Try
                            Else
                                If existevalor4 = False Then
                                    Try
                                        conn.Open()
                                        Dim cmd As New MySqlCommand(String.Format("UPDATE `bd_productos`.`reportes` SET `Valor_4`='" & valor & "' WHERE `ProductoID`='" & ProductoID & "' and`ID_Prueba`='" & ID_Prueba & "';"), conn)
                                        cmd.ExecuteNonQuery()
                                        Console.WriteLine("Reporte Registrado")
                                        'MsgBox("Reporte Registrado", False, "Reporte Registrado")
                                        conn.Close()
                                    Catch ex As Exception
                                        MsgBox(ex.Message, False, "Error")
                                        conn.Close()
                                        Exit Sub
                                    End Try
                                Else
                                    If existevalor5 = False Then
                                        Try
                                            conn.Open()
                                            Dim cmd As New MySqlCommand(String.Format("UPDATE `bd_productos`.`reportes` SET `Valor_5`='" & valor & "' WHERE `ProductoID`='" & ProductoID & "' and`ID_Prueba`='" & ID_Prueba & "';"), conn)
                                            cmd.ExecuteNonQuery()
                                            Console.WriteLine("Reporte Registrado")
                                            'MsgBox("Reporte Registrado", False, "Reporte Registrado")
                                            conn.Close()
                                        Catch ex As Exception
                                            MsgBox(ex.Message, False, "Error")
                                            conn.Close()
                                            Exit Sub
                                        End Try
                                    End If
                                End If
                            End If
                        End If
                    End If
                    ProgressBar1.Increment(steps)
                End If
        Next

        Try
            conn.Open()
            Dim cmd As New MySqlCommand(String.Format("Update productos SET Estado = 'Revisado', Fecha_Reporte = '" & Fecha_Reporte & "', UsuarioID = '" & UsuarioID & "', Observaciones_Analista = '" & ObservacionesAnalista & "' WHERE ProductoID = '" & ProductoID & "' ;"), conn)
            cmd.ExecuteNonQuery()
            Console.Write("Producto Reportado")
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
            conn.Close()
        End Try

        Form1.CargarDGVProductosLimite()
        Form1.CargarDGVProductosSinRevisar()
        Form1.ProductosFechaLimiteCerca()
        MsgBox("Reporte Registrado", False, "Reporte Registrado")
        ProgressBar1.Value = 0
        Me.Close()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Dim control As Integer = 0
    Private Sub Form3_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        control = 1
    End Sub

    Private Sub BtnEncontrarRuta_Click(sender As Object, e As EventArgs) Handles BtnEncontrarRuta.Click
        Dim getruta As New OpenFileDialog
        getruta.InitialDirectory = "C:\"
        getruta.RestoreDirectory = False
        getruta.Filter = "CSV Files(*.csv)|*.csv"
        getruta.ShowDialog()

        Dim filepath As String

        Try
            filepath = Path.GetFullPath(getruta.FileName)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End Try

        TxtBxRuta.Text = filepath

        Dim numero_de_lineas = File.ReadAllLines(filepath).Length

        Dim sData() As String
        Dim IDPrueba, Valor1, Valor2, Valor3, Valor4, Valor5, Valor6, Valor7, Valor8, Valor9, Valor10 As New List(Of String)()

        Using sr As New StreamReader(filepath)
            While Not sr.EndOfStream
                sData = sr.ReadLine().Split(";"c)

                IDPrueba.Add(sData(0).Trim())
                Try
                    Valor1.Add(sData(1).Trim())
                    Valor2.Add(sData(2).Trim())
                    Valor3.Add(sData(3).Trim())
                    Valor4.Add(sData(4).Trim())
                    Valor5.Add(sData(5).Trim())
                    Valor6.Add(sData(6).Trim())
                    Valor7.Add(sData(7).Trim())
                    Valor8.Add(sData(8).Trim())
                    Valor9.Add(sData(9).Trim())
                    Valor10.Add(sData(10).Trim())
                Catch ex As Exception

                End Try

            End While
        End Using

        For j = 0 To pruebasproducto - 1
            If TextBoxArray(j).Enabled = True Then

                For i As Integer = 0 To numero_de_lineas - 1

                    If IDPrueba(i) = "D-3242" Then

                        Dim WP As Double
                        Dim V As Double
                        Dim Vb As Double
                        Double.TryParse(Valor1(i), WP)
                        Double.TryParse(Valor2(i), V)
                        Double.TryParse(Valor3(i), Vb)
                        Dim Normalidad As Decimal

                        Normalidad = (WP / 204.23) * (1000 / (V - Vb))
                        Normalidad = Round(Normalidad, 4)

                        Dim W As Double
                        Dim A As Double
                        Dim B As Double
                        Dim Tm As Double
                        Double.TryParse(Valor4(i), W)
                        Double.TryParse(Valor5(i), A)
                        Double.TryParse(Valor6(i), B)
                        Double.TryParse(Valor7(i), Tm)

                        Dim Acidez As Decimal

                        Acidez = ((A - B) * Normalidad * 56.1) / W
                        Acidez = Round(Acidez, 3)

                        For k As Integer = 0 To pruebasproducto - 1
                            If TextBoxArray(k).Name = "TxtBxD-3242" Then
                                TextBoxArray(k).Text = Acidez.ToString
                            End If
                        Next

                    ElseIf IDPrueba(i) = "D-1319-01" Then

                        Dim Lt1 As Double
                        Dim Lt2 As Double
                        Dim Lt3 As Double
                        Dim Lt4 As Double
                        Dim La1 As Double
                        Dim La2 As Double
                        Dim La3 As Double
                        Dim La4 As Double
                        Double.TryParse(Valor1(i), Lt1)
                        Double.TryParse(Valor2(i), Lt2)
                        Double.TryParse(Valor3(i), Lt3)
                        Double.TryParse(Valor4(i), Lt4)
                        Double.TryParse(Valor5(i), La1)
                        Double.TryParse(Valor6(i), La2)
                        Double.TryParse(Valor7(i), La3)
                        Double.TryParse(Valor8(i), La4)

                        Dim calc1 As Decimal = (La1 / Lt1) * 100
                        Dim calc2 As Decimal = (La2 / Lt2) * 100
                        Dim calc3 As Decimal = (La3 / Lt3) * 100
                        Dim calc4 As Decimal = (La4 / Lt4) * 100

                        calc1 = Round(calc1, 1)
                        calc2 = Round(calc2, 1)
                        calc3 = Round(calc3, 1)
                        calc4 = Round(calc4, 1)

                        Dim prom As Decimal = (calc1 + calc2 + calc3 + calc4) / 4

                        prom = Round(prom, 1)

                        For k As Integer = 0 To pruebasproducto - 1
                            If TextBoxArray(k).Name = "TxtBxD-1319-01" Then
                                TextBoxArray(k).Text = prom.ToString
                            End If
                        Next

                    ElseIf IDPrueba(i) = "D-1319-02" Then

                        Dim Lt1 As Double
                        Dim Lt2 As Double
                        Dim Lt3 As Double
                        Dim Lt4 As Double
                        Dim Lo1 As Double
                        Dim Lo2 As Double
                        Dim Lo3 As Double
                        Dim Lo4 As Double
                        Double.TryParse(Valor1(i), Lt1)
                        Double.TryParse(Valor2(i), Lt2)
                        Double.TryParse(Valor3(i), Lt3)
                        Double.TryParse(Valor4(i), Lt4)
                        Double.TryParse(Valor5(i), Lo1)
                        Double.TryParse(Valor6(i), Lo2)
                        Double.TryParse(Valor7(i), Lo3)
                        Double.TryParse(Valor8(i), Lo4)

                        Dim calc1 As Decimal = (Lo1 / Lt1) * 100
                        Dim calc2 As Decimal = (Lo2 / Lt2) * 100
                        Dim calc3 As Decimal = (Lo3 / Lt3) * 100
                        Dim calc4 As Decimal = (Lo4 / Lt4) * 100

                        calc1 = Round(calc1, 1)
                        calc2 = Round(calc2, 1)
                        calc3 = Round(calc3, 1)
                        calc4 = Round(calc4, 1)

                        Dim prom As Decimal = (calc1 + calc2 + calc3 + calc4) / 4

                        prom = Round(prom, 1)

                        For k As Integer = 0 To pruebasproducto - 1
                            If TextBoxArray(k).Name = "TxtBxD-1319-02" Then
                                TextBoxArray(k).Text = prom.ToString
                            End If
                        Next

                    ElseIf IDPrueba(i) = "D-1319-03" Then

                        Dim Lt1 As Double
                        Dim Lt2 As Double
                        Dim Lt3 As Double
                        Dim Lt4 As Double
                        Dim Li1 As Double
                        Dim Li2 As Double
                        Dim Li3 As Double
                        Dim Li4 As Double
                        Double.TryParse(Valor1(i), Lt1)
                        Double.TryParse(Valor2(i), Lt2)
                        Double.TryParse(Valor3(i), Lt3)
                        Double.TryParse(Valor4(i), Lt4)
                        Double.TryParse(Valor5(i), Li1)
                        Double.TryParse(Valor6(i), Li2)
                        Double.TryParse(Valor7(i), Li3)
                        Double.TryParse(Valor8(i), Li4)

                        Dim calc1 As Decimal = (Li1 / Lt1) * 100
                        Dim calc2 As Decimal = (Li2 / Lt2) * 100
                        Dim calc3 As Decimal = (Li3 / Lt3) * 100
                        Dim calc4 As Decimal = (Li4 / Lt4) * 100

                        calc1 = Round(calc1, 1)
                        calc2 = Round(calc2, 1)
                        calc3 = Round(calc3, 1)
                        calc4 = Round(calc4, 1)

                        Dim prom As Decimal = (calc1 + calc2 + calc3 + calc4) / 4

                        prom = Round(prom, 1)

                        For k As Integer = 0 To pruebasproducto - 1
                            If TextBoxArray(k).Name = "TxtBxD-1319-03" Then
                                TextBoxArray(k).Text = prom.ToString
                            End If
                        Next

                    ElseIf IDPrueba(i) = "D-1840" Then

                        Dim A As Double
                        Dim W As Double
                        Dim K As Double
                        Dim PromAbsor As Double
                        Dim B As Double
                        Dim C As Double

                        Double.TryParse(Valor1(i), A)
                        Double.TryParse(Valor2(i), W)
                        Double.TryParse(Valor3(i), K)
                        Double.TryParse(Valor4(i), PromAbsor)
                        Double.TryParse(Valor5(i), B)
                        Double.TryParse(Valor6(i), C)

                        Dim M As Decimal = ((A * K) / (33.7 * W)) * 100
                        Dim BC As Decimal = B / C
                        Dim Vol As Decimal = M * BC

                        Vol = Round(Vol, 2)

                        For l As Integer = 0 To pruebasproducto - 1
                            If TextBoxArray(l).Name = "TxtBxD-1840" Then
                                TextBoxArray(l).Text = Vol.ToString
                            End If
                        Next

                    ElseIf IDPrueba(i) = "D-1322" Then

                        Dim FactorCorreccion As Double
                        Dim PresionBar As Double
                        Dim TempMues As Double
                        Dim Lec1 As Double
                        Dim Lec2 As Double
                        Dim Lec3 As Double
                        Dim Turbidez As String
                        Dim Filtracion As String

                        Double.TryParse(Valor1(i), FactorCorreccion)
                        Double.TryParse(Valor2(i), PresionBar)
                        Double.TryParse(Valor3(i), TempMues)
                        Double.TryParse(Valor4(i), Lec1)
                        Double.TryParse(Valor5(i), Lec2)
                        Double.TryParse(Valor6(i), Lec3)
                        Turbidez = Valor7(i)
                        Filtracion = Valor8(i)

                        Dim prom As Decimal = (Lec1 + Lec2 + Lec3) / 3

                        Dim valor As Decimal = prom * FactorCorreccion

                        valor = Math.Round((valor * 2)) / 2

                        For k As Integer = 0 To pruebasproducto - 1
                            If TextBoxArray(k).Name = "TxtBxD-1322" Then
                                TextBoxArray(k).Text = valor.ToString
                            End If
                        Next

                    ElseIf IDPrueba(i) = "D-56" Then

                        Dim TempMues As Double
                        Dim PresionBar As Double
                        Dim PuntoChispa As Double

                        Double.TryParse(Valor1(i), TempMues)
                        Double.TryParse(Valor2(i), PresionBar)
                        Double.TryParse(Valor3(i), PuntoChispa)

                        Dim PuntoChispaCorregido As Decimal = PuntoChispa + 0.25 * (101.3 - PresionBar)

                        PuntoChispaCorregido = Math.Round((PuntoChispaCorregido * 2)) / 2

                        For k As Integer = 0 To pruebasproducto - 1
                            If TextBoxArray(k).Name = "TxtBxD-56" Then
                                TextBoxArray(k).Text = PuntoChispaCorregido.ToString
                            End If
                        Next

                    ElseIf IDPrueba(i) = "D-93" Then

                        Dim TempMues As Double
                        Dim PresionBar As Double
                        Dim PuntoChispa As Double

                        Double.TryParse(Valor1(i), TempMues)
                        Double.TryParse(Valor2(i), PresionBar)
                        Double.TryParse(Valor3(i), PuntoChispa)

                        Dim PuntoChispaCorregido As Decimal = PuntoChispa + 0.25 * (101.3 - PresionBar)

                        PuntoChispaCorregido = Math.Round((PuntoChispaCorregido * 2)) / 2

                        For k As Integer = 0 To pruebasproducto - 1
                            If TextBoxArray(k).Name = "TxtBxD-93" Then
                                TextBoxArray(k).Text = PuntoChispaCorregido.ToString
                            End If
                        Next

                    ElseIf IDPrueba(i) = "D-4294-01" Then

                        Dim AguaSuspendida As String
                        Dim Homogeniziacion As String
                        Dim muestra1 As Double
                        Dim muestra2 As Double

                        AguaSuspendida = Valor1(i)
                        Homogeniziacion = Valor2(i)
                        Double.TryParse(Valor3(i), muestra1)
                        Double.TryParse(Valor4(i), muestra2)

                        Dim prom As Decimal

                        If muestra2 = 0 Then
                            prom = muestra1
                            prom = Round(prom, 4)
                        Else
                            prom = (muestra1 + muestra2) / 2

                            prom = Round(prom, 4)
                        End If

                        For k As Integer = 0 To pruebasproducto - 1
                            If TextBoxArray(k).Name = "TxtBxD-4294-01" Then
                                TextBoxArray(k).Text = prom.ToString
                            End If
                        Next

                    ElseIf IDPrueba(i) = "D-4294-02" Then

                        Dim AguaSuspendida As String
                        Dim Homogeniziacion As String
                        Dim muestra1 As Double
                        Dim muestra2 As Double

                        AguaSuspendida = Valor1(i)
                        Homogeniziacion = Valor2(i)
                        Double.TryParse(Valor3(i), muestra1)
                        Double.TryParse(Valor4(i), muestra2)

                        Dim prom As Decimal

                        If muestra2 = 0 Then
                            prom = muestra1
                            prom = Round(prom, 4)
                        Else
                            prom = (muestra1 + muestra2) / 2

                            prom = Round(prom, 4)
                        End If

                        For k As Integer = 0 To pruebasproducto - 1
                            If TextBoxArray(k).Name = "TxtBxD-4294-02" Then
                                TextBoxArray(k).Text = prom.ToString
                            End If
                        Next

                    ElseIf IDPrueba(i) = "D-3241-01" Then

                        Dim NoSerie As String
                        Dim observaciones As String
                        Dim resultado As String
                        Dim horafinalizacionfuel As String
                        Dim tempfuel As String
                        Dim Tcaidafuelinicio As String
                        Dim Tcaidafuelfinal As String
                        Dim horainicioh As String
                        Dim horafinalizacionprueba As String
                        Dim volumenpasado As String

                        NoSerie = Valor1(i)
                        observaciones = Valor2(i)
                        resultado = Valor3(i)
                        horafinalizacionfuel = Valor4(i)
                        tempfuel = Valor5(i)
                        Tcaidafuelinicio = Valor6(i)
                        Tcaidafuelfinal = Valor7(i)
                        horainicioh = Valor8(i)
                        horafinalizacionprueba = Valor9(i)
                        volumenpasado = Valor10(i)

                        For k As Integer = 0 To pruebasproducto - 1
                            If TextBoxArray(k).Name = "TxtBxD-3241-01" Then
                                TextBoxArray(k).Text = resultado
                            End If
                        Next

                    ElseIf IDPrueba(i) = "D-3241-02" Then

                        Dim NoSerie As String
                        Dim observaciones As String
                        Dim resultado As String
                        Dim horafinalizacionfuel As String
                        Dim tempfuel As String
                        Dim Tcaidafuelinicio As String
                        Dim Tcaidafuelfinal As String
                        Dim horainicioh As String
                        Dim horafinalizacionprueba As String
                        Dim volumenpasado As String

                        NoSerie = Valor1(i)
                        observaciones = Valor2(i)
                        resultado = Valor3(i)
                        horafinalizacionfuel = Valor4(i)
                        tempfuel = Valor5(i)
                        Tcaidafuelinicio = Valor6(i)
                        Tcaidafuelfinal = Valor7(i)
                        horainicioh = Valor8(i)
                        horafinalizacionprueba = Valor9(i)
                        volumenpasado = Valor10(i)

                        For k As Integer = 0 To pruebasproducto - 1
                            If TextBoxArray(k).Name = "TxtBxD-3241-02" Then
                                TextBoxArray(k).Text = resultado
                            End If
                        Next

                    End If

                Next
            End If
        Next

    End Sub

    Private Sub BtnAbrirDatos_Click(sender As Object, e As EventArgs) Handles BtnAbrirDatos.Click
        If TxtBxRuta.Text.Trim = "" Then
            MsgBox("Seleccione la ruta del archivo antes de continuar", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        Try
            Process.Start(TxtBxRuta.Text)
        Catch ex As Exception
            MsgBox("No se encontro archivo en la ruta seleccionada", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub
End Class