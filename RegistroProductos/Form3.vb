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
                    Dim IDPrueba, Valor1, Valor2, Valor3, Valor4, Valor5, Valor6, Valor7, Valor8, Valor9, Valor10, Valor11, Valor12, Valor13, Valor14 As New List(Of String)()

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
                                Valor11.Add(sData(11).Trim())
                                Valor12.Add(sData(12).Trim())
                                Valor13.Add(sData(13).Trim())
                                Valor14.Add(sData(14).Trim())
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
                            Normalidad = Round(Normalidad, 4, MidpointRounding.ToEven)

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
                            Acidez = Round(Acidez, 3, MidpointRounding.ToEven)

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

                            calc1 = Round(calc1, 1, MidpointRounding.ToEven)
                            calc2 = Round(calc2, 1, MidpointRounding.ToEven)
                            calc3 = Round(calc3, 1, MidpointRounding.ToEven)
                            calc4 = Round(calc4, 1, MidpointRounding.ToEven)

                            Dim prom As Decimal = (calc1 + calc2 + calc3 + calc4) / 4

                            prom = Round(prom, 1, MidpointRounding.ToEven)

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

                            calc1 = Round(calc1, 1, MidpointRounding.ToEven)
                            calc2 = Round(calc2, 1, MidpointRounding.ToEven)
                            calc3 = Round(calc3, 1, MidpointRounding.ToEven)
                            calc4 = Round(calc4, 1, MidpointRounding.ToEven)

                            Dim prom As Decimal = (calc1 + calc2 + calc3 + calc4) / 4

                            prom = Round(prom, 1, MidpointRounding.ToEven)

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

                            calc1 = Round(calc1, 1, MidpointRounding.ToEven)
                            calc2 = Round(calc2, 1, MidpointRounding.ToEven)
                            calc3 = Round(calc3, 1, MidpointRounding.ToEven)
                            calc4 = Round(calc4, 1, MidpointRounding.ToEven)

                            Dim prom As Decimal = (calc1 + calc2 + calc3 + calc4) / 4

                            prom = Round(prom, 1, MidpointRounding.ToEven)

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

                            Vol = Round(Vol, 2, MidpointRounding.ToEven)

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
                                prom = Round(prom, 4, MidpointRounding.ToEven)

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

                                prom = Round(prom, 4, MidpointRounding.ToEven)

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
                                prom = Round(prom, 4, MidpointRounding.ToEven)

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

                                prom = Round(prom, 4, MidpointRounding.ToEven)

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

                        ElseIf ID_Prueba = "D-3241-01" And IDPrueba(j) = "D-3241-01" Then

                            Dim NoSerie As String
                            Dim obs As String
                            Dim resultado As String
                            Dim horafinalizacionfuel As String
                            Dim tempfuel As String
                            Dim Tcaidafuelinicio As String
                            Dim Tcaidafuelfinal As String
                            Dim horainicioh As String
                            Dim horafinalizacionprueba As String
                            Dim volumenpasado As String

                            NoSerie = Valor1(j)
                            obs = Valor2(j)
                            resultado = Valor3(j)
                            horafinalizacionfuel = Valor4(j)
                            tempfuel = Valor5(j)
                            Tcaidafuelinicio = Valor6(j)
                            Tcaidafuelfinal = Valor7(j)
                            horainicioh = Valor8(j)
                            horafinalizacionprueba = Valor9(j)
                            volumenpasado = Valor10(j)

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
                                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`, `Dato_4`, `Dato_5`,`Dato_6`,`Dato_7`,`Dato_8`,`Dato_9`,`Dato_10`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', 'D-3241-01', '" & NoSerie & "', '" & obs & "', '" & tempfuel & "', '" & horainicioh & "', '" & horafinalizacionfuel & "', '" & Tcaidafuelinicio & "', '" & Tcaidafuelfinal & "', '" & volumenpasado & "', '" & resultado & "', '" & horafinalizacionprueba & "');"), conn)
                                cmd.ExecuteNonQuery()
                                Console.WriteLine("Datos Registrados")
                                conn.Close()
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                        ElseIf ID_Prueba = "D-3241-02" And IDPrueba(j) = "D-3241-02" Then

                            Dim NoSerie As String
                            Dim obs As String
                            Dim resultado As String
                            Dim horafinalizacionfuel As String
                            Dim tempfuel As String
                            Dim Tcaidafuelinicio As String
                            Dim Tcaidafuelfinal As String
                            Dim horainicioh As String
                            Dim horafinalizacionprueba As String
                            Dim volumenpasado As String

                            NoSerie = Valor1(j)
                            obs = Valor2(j)
                            resultado = Valor3(j)
                            horafinalizacionfuel = Valor4(j)
                            tempfuel = Valor5(j)
                            Tcaidafuelinicio = Valor6(j)
                            Tcaidafuelfinal = Valor7(j)
                            horainicioh = Valor8(j)
                            horafinalizacionprueba = Valor9(j)
                            volumenpasado = Valor10(j)

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
                                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`, `Dato_4`, `Dato_5`,`Dato_6`,`Dato_7`,`Dato_8`,`Dato_9`,`Dato_10`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', 'D-3241-02', '" & NoSerie & "', '" & obs & "', '" & tempfuel & "', '" & horainicioh & "', '" & horafinalizacionfuel & "', '" & Tcaidafuelinicio & "', '" & Tcaidafuelfinal & "', '" & volumenpasado & "', '" & resultado & "', '" & horafinalizacionprueba & "');"), conn)
                                cmd.ExecuteNonQuery()
                                Console.WriteLine("Datos Registrados")
                                conn.Close()
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                        ElseIf (ID_prueba = "D-86-01" And IDPrueba(j) = "D-86-01") Or (ID_prueba = "D-86-03" And IDPrueba(j) = "D-86-03") Or (ID_prueba = "D-86-07" And IDPrueba(j) = "D-86-07") Or (ID_prueba = "D-86-11" And IDPrueba(j) = "D-86-11") Or (ID_prueba = "D-86-12" And IDPrueba(j) = "D-86-12") Or (ID_prueba = "D-86-24" And IDPrueba(j) = "D-86-24") Or (ID_prueba = "D-86-25" And IDPrueba(j) = "D-86-25") Or (ID_prueba = "D-86-26" And IDPrueba(j) = "D-86-26") Or (ID_prueba = "D-86-14" And IDPrueba(j) = "D-86-14") Or (ID_prueba = "D-86-17" And IDPrueba(j) = "D-86-17") Or (ID_prueba = "D-86-18" And IDPrueba(j) = "D-86-18") Or (ID_prueba = "D-86-22" And IDPrueba(j) = "D-86-22") Or (ID_prueba = "D-86-27" And IDPrueba(j) = "D-86-27") Or (ID_prueba = "D-86-28" And IDPrueba(j) = "D-86-28") Then

                            Dim prueba As String = IDPrueba(j)

                            Dim TempM As String
                            Dim PresionB As String
                            Dim Obs As String
                            Dim AguaL As String
                            Dim Turbidez As String
                            Dim Secado As String
                            Dim Resultado As String

                            TempM = Valor1(j)
                            PresionB = Valor2(j)
                            Obs = Valor3(j)
                            AguaL = Valor4(j)
                            Turbidez = Valor5(j)
                            Secado = Valor6(j)
                            Resultado = Valor7(j)

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
                                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`, `Dato_4`, `Dato_5`,`Dato_6`,`Dato_7`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', '" & prueba & "', '" & TempM & "', '" & PresionB & "', '" & Obs & "', '" & AguaL & "', '" & Turbidez & "', '" & Secado & "', '" & Resultado & "');"), conn)
                                cmd.ExecuteNonQuery()
                                Console.WriteLine("Datos Registrados")
                                conn.Close()
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                        ElseIf ID_Prueba = "D-2386" And IDPrueba(j) = "D-2386" Then

                            Dim TFormCrist As String
                            Dim TCFormCrist As String
                            Dim TDesapCrist As String
                            Dim TCDesapCrist As Double
                            Dim Resultado As Decimal

                            TFormCrist = Valor1(j)
                            TCFormCrist = Valor2(j)
                            TDesapCrist = Valor3(j)
                            TCDesapCrist = Valor4(j)
                            Resultado = Math.Round((TCDesapCrist * 2)) / 2

                            Dim ResultadoString As String = Format(Resultado, ("0.0"))

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
                                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`, `Dato_4`, `Dato_5`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', 'D-2386', '" & TFormCrist & "', '" & TCFormCrist & "', '" & TDesapCrist & "', '" & TCDesapCrist & "', '" & ResultadoString & "');"), conn)
                                cmd.ExecuteNonQuery()
                                Console.WriteLine("Datos Registrados")
                                conn.Close()
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                        ElseIf ID_Prueba = "D-4176" And IDPrueba(j) = "D-4176" Then

                            Dim TempM As String
                            Dim ClaraBrillante As String
                            Dim LibreAgua As String
                            Dim PenSuspension As String
                            Dim resultado As String
                            Dim Obs As String

                            TempM = Valor1(j)
                            ClaraBrillante = Valor2(j)
                            LibreAgua = Valor3(j)
                            PenSuspension = Valor4(j)
                            resultado = Valor5(j)
                            Obs = Valor6(j)

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
                                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`, `Dato_4`, `Dato_5`, `Dato_6`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', 'D-4176', '" & TempM & "', '" & ClaraBrillante & "', '" & LibreAgua & "', '" & PenSuspension & "', '" & resultado & "', '" & Obs & "');"), conn)
                                cmd.ExecuteNonQuery()
                                Console.WriteLine("Datos Registrados")
                                conn.Close()
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                        ElseIf ID_Prueba = "D-3948" And IDPrueba(j) = "D-3948" Then

                            Dim MaterialS As String
                            Dim Decantacion As String
                            Dim T1 As Double
                            Dim T2 As Double
                            Dim Var As Decimal
                            Dim Tmues As String
                            Dim resultado As String

                            MaterialS = Valor1(j)
                            Decantacion = Valor2(j)
                            T1 = Valor3(j)
                            T2 = Valor4(j)
                            Var = T2 - T1
                            Tmues = Valor5(j)
                            resultado = Valor6(j)

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
                                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`, `Dato_4`, `Dato_5`, `Dato_6`, `Dato_7`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', 'D-3948', '" & MaterialS & "', '" & Decantacion & "', '" & T1 & "', '" & T2 & "', '" & Var & "', '" & Tmues & "', '" & resultado & "');"), conn)
                                cmd.ExecuteNonQuery()
                                Console.WriteLine("Datos Registrados")
                                conn.Close()
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                        ElseIf (ID_Prueba = "D-1094-01" And IDPrueba(j) = "D-1094-01") Or (ID_Prueba = "D-1094-02" And IDPrueba(j) = "D-1094-02") Or (ID_Prueba = "D-1094-03" And IDPrueba(j) = "D-1094-03") Then

                            Dim prueba As String = IDPrueba(j)

                            Dim Tmues As String
                            Dim VolBuff As String
                            Dim Obs As String
                            Dim Resultado As String

                            Tmues = Valor1(j)
                            VolBuff = Valor2(j)
                            Obs = Valor3(j)
                            Resultado = Valor4(j)

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
                                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`, `Dato_4`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', '" & prueba & "', '" & Tmues & "', '" & VolBuff & "', '" & Obs & "', '" & Resultado & "');"), conn)
                                cmd.ExecuteNonQuery()
                                Console.WriteLine("Datos Registrados")
                                conn.Close()
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                        ElseIf (ID_Prueba = "D-130-01" And IDPrueba(j) = "D-130-01") Or (ID_Prueba = "D-130-02" And IDPrueba(j) = "D-130-02") Then

                            Dim prueba As String = IDPrueba(j)

                            Dim Turbidez As String = Valor1(j)
                            Dim Filtracion As String = Valor2(j)
                            Dim Resultado As String = Valor3(j)

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
                                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', '" & prueba & "', '" & Turbidez & "', '" & Filtracion & "', '" & Resultado & "');"), conn)
                                cmd.ExecuteNonQuery()
                                Console.WriteLine("Datos Registrados")
                                conn.Close()
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                        ElseIf ID_Prueba = "D-4953" And IDPrueba(j) = "D-4953" Then

                            Dim VolMuestra As String = Valor1(j)
                            Dim MuestraDescartada1 As String = Valor2(j)
                            Dim AguaLibre As String = Valor3(j)
                            Dim MuestraDescartada2 As String = Valor4(j)
                            Dim LecturaPatronAntes As Double = Valor5(j)
                            Dim LecturaNMTAntes As Double = Valor6(j)
                            Dim CorreccionAntes As Double = Valor7(j)
                            Dim LecturaPatronDesp As Double = Valor8(j)
                            Dim LecturaNMTDesp As Double = Valor9(j)
                            Dim CorreccionDesp As Double = Valor10(j)

                            Dim ValorAntes = LecturaNMTAntes + CorreccionAntes
                            Dim ValorDespues = LecturaNMTDesp + CorreccionDesp
                            Dim ValorAntes2 = ValorAntes * 6.895
                            Dim ValorDespues2 = ValorDespues * 6.895

                            ValorAntes2 = Math.Round(ValorAntes2 * 4) / 4
                            ValorDespues2 = Math.Round(ValorDespues2 * 4) / 4

                            Dim ValorAntes2String As String = Format(ValorAntes2, "0.00")
                            Dim ValorDespues2String As String = Format(ValorDespues2, "0.00")

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
                                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`, `Dato_4`, `Dato_5`, `Dato_6`, `Dato_7`, `Dato_8`, `Dato_9`, `Dato_10`, `Dato_11`, `Dato_12`, `Dato_13`, `Dato_14`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', 'D-4953', '" & VolMuestra & "', '" & MuestraDescartada1 & "', '" & AguaLibre & "', '" & MuestraDescartada2 & "', '" & LecturaPatronAntes & "', '" & LecturaNMTAntes & "', '" & CorreccionAntes & "', '" & ValorAntes & "', '" & ValorAntes2String & "', '" & LecturaPatronDesp & "', '" & LecturaNMTDesp & "', '" & CorreccionDesp & "', '" & ValorDespues & "', '" & ValorDespues2String & "');"), conn)
                                cmd.ExecuteNonQuery()
                                Console.WriteLine("Datos Registrados")
                                conn.Close()
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                        ElseIf ID_Prueba = "D-4815" And IDPrueba(j) = "D-4815" Then

                            Dim PesoEstandar As String = Valor1(j)
                            Dim PesoGasOx As String = Valor2(j)
                            Dim TempMue As String = Valor3(j)
                            Dim Resultado As String = Valor4(j)

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
                                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`, `Dato_4`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', 'D-4815', '" & PesoEstandar & "', '" & PesoGasOx & "', '" & TempMue & "', '" & Resultado & "');"), conn)
                                cmd.ExecuteNonQuery()
                                Console.WriteLine("Datos Registrados")
                                conn.Close()
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                        ElseIf ID_Prueba = "D-1298" And IDPrueba(j) = "D-1298" Then

                            Dim T1 As Double = Valor1(j)
                            Dim Api As String = Valor2(j)
                            Dim T2 As Double = Valor3(j)
                            Dim TP As Double = (T1 + T2) / 2
                            Dim PresionB As String = Valor4(j)
                            Dim Densidad As String = Valor5(j)
                            Dim Resultado As String = Valor6(j)

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
                                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`, `Dato_4`, `Dato_5`, `Dato_6`, `Dato_7`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', 'D-1298', '" & T1 & "', '" & Api & "', '" & T2 & "', '" & TP & "', '" & PresionB & "', '" & Densidad & "', '" & Resultado & "');"), conn)
                                cmd.ExecuteNonQuery()
                                Console.WriteLine("Datos Registrados")
                                conn.Close()
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                        ElseIf ID_Prueba = "D-445" And IDPrueba(j) = "D-445" Then

                            Dim Particulas As String = Valor1(j)
                            Dim Filtracion As String = Valor2(j)
                            Dim Resultado As String = Valor3(j)

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
                                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', 'D-445', '" & Particulas & "', '" & Filtracion & "', '" & Resultado & "');"), conn)
                                cmd.ExecuteNonQuery()
                                Console.WriteLine("Datos Registrados")
                                conn.Close()
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                        ElseIf ID_Prueba = "MMIN" And IDPrueba(j) = "MMIN" Then

                            Dim LecturaNMTDesp As Double = Valor1(j)
                            Dim CorreccionDesp As Double = Valor2(j)
                            Dim REID As Double = LecturaNMTDesp + CorreccionDesp

                            REID = REID * 6.895
                            REID = Math.Round(REID * 4) / 4

                            Dim A As Double = Valor3(j)

                            Dim ICV As Double = REID + (1.13 * A)

                            ICV = Round(ICV, 1, MidpointRounding.ToEven)

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
                                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', 'MMIN', '" & REID & "', '" & A & "', '" & ICV & "');"), conn)
                                cmd.ExecuteNonQuery()
                                Console.WriteLine("Datos Registrados")
                                conn.Close()
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                        ElseIf ID_Prueba = "EN14078" And IDPrueba(j) = "EN14078" Then

                            Dim RelacionDilucion As String = Valor1(j)
                            Dim DatoCurva As String = Valor2(j)
                            Dim DensidadBioD As String = Valor3(j)
                            Dim Obs As String = Valor4(j)
                            Dim Resultado As String = Valor5(j)

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
                                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`, `Dato_4`, `Dato_5`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', 'EN14078', '" & RelacionDilucion & "', '" & DatoCurva & "', '" & DensidadBioD & "', '" & Obs & "', '" & Resultado & "');"), conn)
                                cmd.ExecuteNonQuery()
                                Console.WriteLine("Datos Registrados")
                                conn.Close()
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                        ElseIf ID_Prueba = "EN12937" And IDPrueba(j) = "EN12937" Then

                            Dim PesoMuestra As String = Valor1(j)
                            Dim Concentracion As Decimal = Valor2(j)
                            Dim Obs As String = Valor3(j)

                            Concentracion = Round(Concentracion, 3, MidpointRounding.ToEven)

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
                                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', 'EN12937', '" & PesoMuestra & "', '" & Obs & "', '" & Concentracion & "');"), conn)
                                cmd.ExecuteNonQuery()
                                Console.WriteLine("Datos Registrados")
                                conn.Close()
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                        ElseIf ID_Prueba = "D-7321" And IDPrueba(j) = "D-7321" Then

                            Dim Wi1 As Double = Valor1(j)
                            Dim Wf1 As Double = Valor2(j)
                            Dim Wi2 As Double = Valor3(j)
                            Dim Wf2 As Double = Valor4(j)
                            Dim Wi3 As Double = Valor5(j)
                            Dim Wf3 As Double = Valor6(j)
                            Dim Vol1 As Double = Valor7(j)
                            Dim Vol2 As Double = Valor8(j)
                            Dim Vol3 As Double = Valor9(j)

                            Dim Diff1 As Double = Wi1 - Wf1
                            Dim Diff2 As Double = Wi2 - Wf2
                            Dim Diff3 As Double = Wi3 - Wf3

                            Dim SumW As Double = Diff1 + Diff2 + Diff3
                            Dim SumVol As Double = Vol1 + Vol2 + Vol3

                            Dim Resultado As Double = (SumW / SumVol) * 1000000

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
                                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`, `Dato_4`, `Dato_5`, `Dato_6`, `Dato_7`, `Dato_8`, `Dato_9`, `Dato_10`, `Dato_11`, `Dato_12`, `Dato_13`, `Dato_14`, `Dato_15`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', 'D-7321', '" & Wi1 & "', '" & Wf1 & "', '" & Diff1 & "', '" & Wi2 & "', '" & Wf2 & "', '" & Diff2 & "', '" & Wi3 & "', '" & Wf3 & "', '" & Diff3 & "', '" & Vol1 & "', '" & Vol2 & "', '" & Vol3 & "', '" & SumW & "', '" & SumVol & "', '" & Resultado & "');"), conn)
                                cmd.ExecuteNonQuery()
                                Console.WriteLine("Datos Registrados")
                                conn.Close()
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                        ElseIf ID_Prueba = "D-525" And IDPrueba(j) = "D-525" Then

                            Dim HoraInicio As String = Valor1(j)
                            Dim CaidaPresion As String = Valor2(j)
                            Dim PromedioTemp As Double = Valor3(j)
                            Dim IPT As Double = Valor4(j)
                            Dim Resultado As Decimal

                            If PromedioTemp > 100 Then
                                Resultado = IPT * ((1 + (0.101 * (PromedioTemp - 100))))
                            ElseIf PromedioTemp < 100 Then
                                Resultado = IPT * ((1 + (0.101 * (100 - PromedioTemp))))
                            ElseIf PromedioTemp = 100 Then
                                Resultado = IPT
                            End If

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
                                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`, `Dato_4`, `Dato_5`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', 'D-525', '" & HoraInicio & "', '" & CaidaPresion & "', '" & PromedioTemp & "', '" & IPT & "', '" & Resultado & "');"), conn)
                                cmd.ExecuteNonQuery()
                                Console.WriteLine("Datos Registrados")
                                conn.Close()
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

                        ElseIf ID_Prueba = "D-381" And IDPrueba(j) = "D-381" Then

                            If TxtBxTipoProductoID.Text = "4" Then
                                Dim B As Double = Valor1(j)
                                Dim D As Double = Valor2(j)
                                Dim X As Double = Valor3(j)
                                Dim Y As Double = Valor4(j)
                                Dim MaterialSuspendido As String = Valor7(j)
                                Dim Filtracion As String = Valor8(j)
                                Dim Resultado As String

                                Dim A As Decimal = 2000 * (B - D + X - Y)

                                If A < 1 Then

                                    Resultado = "<1"

                                Else

                                    Dim temp As Decimal = Round(A)
                                    Resultado = temp.ToString

                                End If

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
                                    Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`, `Dato_4`, `Dato_5`, `Dato_6`, `Dato_7`, `Dato_8`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', 'D-381', '" & B & "', '" & D & "', '" & X & "', '" & Y & "', '" & MaterialSuspendido & "', '" & Filtracion & "','" & A & "', '" & Resultado & "');"), conn)
                                    cmd.ExecuteNonQuery()
                                    Console.WriteLine("Datos Registrados")
                                    conn.Close()
                                Catch ex As Exception
                                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                    conn.Close()
                                    Exit Sub
                                End Try

                            ElseIf TxtBxTipoProductoID.Text = "6" Or TxtBxTipoProductoID.Text = "7" Or TxtBxTipoProductoID.Text = "8" Or TxtBxTipoProductoID.Text = "9" Then

                                Dim B As Double = Valor1(j)
                                Dim D As Double = Valor2(j)
                                Dim X As Double = Valor3(j)
                                Dim Y As Double = Valor4(j)
                                Dim C As Double = Valor5(j)
                                Dim Z As Double = Valor6(j)
                                Dim MaterialSuspendido As String = Valor7(j)
                                Dim Filtracion As String = Valor8(j)
                                Dim Resultado1 As String
                                Dim Resultado2 As String

                                Dim U As Decimal = 2000 * (B - D + X - Y)
                                Dim S As Decimal = 2000 * (C - D + X - Z)

                                If U < 0.5 Then
                                    Resultado1 = "<0.5"
                                Else
                                    Dim temp As Decimal = Math.Round(U * 2) / 2
                                    Resultado1 = temp.ToString
                                End If

                                If S < 0.5 Then
                                    Resultado2 = "<0.5"
                                Else
                                    Dim temp As Decimal = Math.Round(S * 2) / 2
                                    Resultado2 = temp.ToString
                                End If

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
                                    Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`, `Dato_4`, `Dato_5`, `Dato_6`, `Dato_7`, `Dato_8`, `Dato_9`, `Dato_10`, `Dato_11`, `Dato_12`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', 'D-381', '" & B & "', '" & D & "', '" & X & "', '" & Y & "', '" & C & "', '" & Z & "', '" & MaterialSuspendido & "', '" & Filtracion & "', '" & U & "', '" & Resultado1 & "','" & S & "','" & Resultado2 & "');"), conn)
                                    cmd.ExecuteNonQuery()
                                    Console.WriteLine("Datos Registrados")
                                    conn.Close()
                                Catch ex As Exception
                                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                    conn.Close()
                                    Exit Sub
                                End Try

                            End If

                        ElseIf ID_Prueba = "D-3338" And IDPrueba(j) = "D-3338" Then

                            Dim Lt1 As Double = Valor1(j)
                            Dim Lt2 As Double = Valor2(j)
                            Dim Lt3 As Double = Valor3(j)
                            Dim Lt4 As Double = Valor4(j)
                            Dim La1 As Double = Valor5(j)
                            Dim La2 As Double = Valor6(j)
                            Dim La3 As Double = Valor7(j)
                            Dim La4 As Double = Valor8(j)

                            Dim calc1 As Decimal = (La1 / Lt1) * 100
                            Dim calc2 As Decimal = (La2 / Lt2) * 100
                            Dim calc3 As Decimal = (La3 / Lt3) * 100
                            Dim calc4 As Decimal = (La4 / Lt4) * 100

                            calc1 = Round(calc1, 1)
                            calc2 = Round(calc2, 1)
                            calc3 = Round(calc3, 1)
                            calc4 = Round(calc4, 1)

                            Dim A As Decimal = (calc1 + calc2 + calc3 + calc4) / 4

                            A = Round(A, 1)

                            Dim D As Double = Valor9(j)

                            Dim T10 As Double = Valor10(j)
                            Dim T50 As Double = Valor11(j)
                            Dim T90 As Double = Valor12(j)

                            Dim T As Double = (T10 + T50 + T90) / 3

                            Dim LibreAzufre As Decimal = ((5528.73 - (92.6499 * A) + (10.1601 * T) + (0.314169 * A * T)) / D) + (0.0791707 * A) - (0.00944893 * T) - (0.000292178 * A * T) + 35.9936

                            Dim muestra1 As Double = Valor13(j)
                            Dim muestra2 As Double = Valor14(j)
                            Dim prom As Decimal
                            If muestra2 = 0 Then
                                prom = muestra1
                                prom = Round(prom, 4)
                            Else
                                prom = (muestra1 + muestra2) / 2

                                prom = Round(prom, 4)
                            End If

                            Dim Resultado As Double

                            If prom = 0 Then
                                Resultado = LibreAzufre
                            Else
                                Resultado = LibreAzufre * (1 - (0.01 * prom)) + (0.10166 * prom)
                            End If

                            Resultado = Round(Resultado, 3, MidpointRounding.ToEven)

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
                                Dim cmd As New MySqlCommand(String.Format("INSERT INTO `bd_productos`.`datosproducto` (`DatoID`, `ProductoID`, `ID_Prueba`, `Dato_1`, `Dato_2`, `Dato_3`, `Dato_4`, `Dato_5`, `Dato_6`, `Dato_7`, `Dato_8`, `Dato_9`) VALUES ('" & llave & "', '" & TxtBxIDProducto.Text & "', 'D-3338', '" & A & "', '" & D & "', '" & T10 & "', '" & T50 & "', '" & T90 & "', '" & T & "', '" & LibreAzufre & "', '" & prom & "', '" & Resultado & "');"), conn)
                                cmd.ExecuteNonQuery()
                                Console.WriteLine("Datos Registrados")
                                conn.Close()
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                                conn.Close()
                                Exit Sub
                            End Try

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
        Dim IDPrueba, Valor1, Valor2, Valor3, Valor4, Valor5, Valor6, Valor7, Valor8, Valor9, Valor10, Valor11, Valor12, Valor13, Valor14 As New List(Of String)()

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
                    Valor11.Add(sData(11).Trim())
                    Valor12.Add(sData(12).Trim())
                    Valor13.Add(sData(13).Trim())
                    Valor14.Add(sData(14).Trim())
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

                    ElseIf IDPrueba(i) = "D-86-01" Or IDPrueba(i) = "D-86-03" Or IDPrueba(i) = "D-86-07" Or IDPrueba(i) = "D-86-11" Or IDPrueba(i) = "D-86-12" Or IDPrueba(i) = "D-86-24" Or IDPrueba(i) = "D-86-25" Or IDPrueba(i) = "D-86-26" Or IDPrueba(i) = "D-86-14" Or IDPrueba(i) = "D-86-17" Or IDPrueba(i) = "D-86-18" Or IDPrueba(i) = "D-86-22" Or IDPrueba(i) = "D-86-27" Or IDPrueba(i) = "D-86-28" Then

                        Dim prueba = IDPrueba(i)

                        Dim TempM As String
                        Dim PresionB As String
                        Dim Obs As String
                        Dim AguaL As String
                        Dim Turbidez As String
                        Dim Secado As String
                        Dim Resultado As String

                        TempM = Valor1(i)
                        PresionB = Valor2(i)
                        Obs = Valor3(i)
                        AguaL = Valor4(i)
                        Turbidez = Valor5(i)
                        Secado = Valor6(i)
                        Resultado = Valor7(i)

                        For k As Integer = 0 To pruebasproducto - 1
                            If TextBoxArray(k).Name = "TxtBx" & prueba Then
                                TextBoxArray(k).Text = Resultado
                            End If
                        Next

                    ElseIf IDPrueba(i) = "D-2386" Then

                        Dim TFormCrist As String
                        Dim TCFormCrist As String
                        Dim TDesapCrist As String
                        Dim TCDesapCrist As Double
                        Dim Resultado As Decimal

                        TFormCrist = Valor1(i)
                        TCFormCrist = Valor2(i)
                        TDesapCrist = Valor3(i)
                        TCDesapCrist = Valor4(i)
                        Resultado = Math.Round((TCDesapCrist * 2)) / 2

                        For k As Integer = 0 To pruebasproducto - 1
                            If TextBoxArray(k).Name = "TxtBxD-2386" Then
                                TextBoxArray(k).Text = Format(Resultado, "0.0")
                            End If
                        Next

                    ElseIf IDPrueba(i) = "D-4176" Then

                        Dim TempM As String
                        Dim ClaraBrillante As String
                        Dim LibreAgua As String
                        Dim PenSuspension As String
                        Dim resultado As String
                        Dim Obs As String

                        TempM = Valor1(i)
                        ClaraBrillante = Valor2(i)
                        LibreAgua = Valor3(i)
                        PenSuspension = Valor4(i)
                        resultado = Valor5(i)
                        Obs = Valor6(i)

                        For k As Integer = 0 To pruebasproducto - 1
                            If TextBoxArray(k).Name = "TxtBxD-4176" Then
                                TextBoxArray(k).Text = resultado
                            End If
                        Next

                    ElseIf IDPrueba(i) = "D-3948" Then

                        Dim MaterialS As String
                        Dim Decantacion As String
                        Dim T1 As Double
                        Dim T2 As Double
                        Dim Var As Decimal
                        Dim Tmues As String
                        Dim resultado As String

                        MaterialS = Valor1(i)
                        Decantacion = Valor2(i)
                        T1 = Valor3(i)
                        T2 = Valor4(i)
                        Var = T2 - T1
                        Tmues = Valor5(i)
                        resultado = Valor6(i)

                        For k As Integer = 0 To pruebasproducto - 1
                            If TextBoxArray(k).Name = "TxtBxD-3948" Then
                                TextBoxArray(k).Text = resultado
                            End If
                        Next

                    ElseIf IDPrueba(i) = "D-1094-01" Or IDPrueba(i) = "D-1094-02" Or IDPrueba(i) = "D-1094-03" Then

                        Dim prueba As String = IDPrueba(i)

                        Dim Tmues As String
                        Dim VolBuff As String
                        Dim Obs As String
                        Dim Resultado As String

                        Tmues = Valor1(i)
                        VolBuff = Valor2(i)
                        Obs = Valor3(i)
                        Resultado = Valor4(i)

                        For k As Integer = 0 To pruebasproducto - 1
                            If TextBoxArray(k).Name = "TxtBx" & prueba Then
                                TextBoxArray(k).Text = Resultado
                            End If
                        Next

                    ElseIf IDPrueba(i) = "D-130-01" Or IDPrueba(i) = "D-130-02" Then

                        Dim prueba As String = IDPrueba(i)

                        Dim Turbidez As String = Valor1(i)
                        Dim Filtracion As String = Valor2(i)
                        Dim Resultado As String = Valor3(i)

                        For k As Integer = 0 To pruebasproducto - 1
                            If TextBoxArray(k).Name = "TxtBx" & prueba Then
                                TextBoxArray(k).Text = Resultado
                            End If
                        Next

                    ElseIf IDPrueba(i) = "D-4953" Then

                        Dim VolMuestra As String = Valor1(i)
                        Dim MuestraDescartada1 As String = Valor2(i)
                        Dim AguaLibre As String = Valor3(i)
                        Dim MuestraDescartada2 As String = Valor4(i)
                        Dim LecturaPatronAntes As Double = Valor5(i)
                        Dim LecturaNMTAntes As Double = Valor6(i)
                        Dim CorreccionAntes As Double = Valor7(i)
                        Dim LecturaPatronDesp As Double = Valor8(i)
                        Dim LecturaNMTDesp As Double = Valor9(i)
                        Dim CorreccionDesp As Double = Valor10(i)

                        Dim ValorAntes = LecturaNMTAntes + CorreccionAntes
                        Dim ValorDespues = LecturaNMTDesp + CorreccionDesp
                        Dim ValorAntes2 = ValorAntes * 6.895
                        Dim ValorDespues2 = ValorDespues * 6.895

                        ValorAntes2 = Math.Round(ValorAntes2 * 4) / 4
                        ValorDespues2 = Math.Round(ValorDespues2 * 4) / 4

                        For k As Integer = 0 To pruebasproducto - 1
                            If TextBoxArray(k).Name = "TxtBxD-4953" Then
                                TextBoxArray(k).Text = Format(ValorDespues2, "0.00")
                            End If
                        Next

                    ElseIf IDPrueba(i) = "D-4815" Then

                        Dim PesoEstandar As String = Valor1(i)
                        Dim PesoGasOx As String = Valor2(i)
                        Dim TempMue As String = Valor3(i)
                        Dim Resultado As String = Valor4(i)

                        For k As Integer = 0 To pruebasproducto - 1
                            If TextBoxArray(k).Name = "TxtBxD-4815" Then
                                TextBoxArray(k).Text = Resultado
                            End If
                        Next

                    ElseIf IDPrueba(i) = "D-1298" Then

                        Dim T1 As Double = Valor1(i)
                        Dim Api As String = Valor2(i)
                        Dim T2 As Double = Valor3(i)
                        Dim TP As Double = (T1 + T2) / 2
                        Dim PresionB As String = Valor4(i)
                        Dim Densidad As String = Valor5(i)
                        Dim Resultado As String = Valor6(i)

                        For k As Integer = 0 To pruebasproducto - 1
                            If TextBoxArray(k).Name = "TxtBxD-1298" Then
                                TextBoxArray(k).Text = Resultado
                            End If
                        Next

                    ElseIf IDPrueba(i) = "D-1250" Or IDPrueba(i) = "D-4952" Or IDPrueba(i) = "E-1064" Then

                        Dim prueba As String = IDPrueba(i)

                        Dim resultado As String = Valor1(i)

                        For k As Integer = 0 To pruebasproducto - 1
                            If TextBoxArray(k).Name = "TxtBx" & prueba Then
                                TextBoxArray(k).Text = resultado
                            End If
                        Next

                    ElseIf IDPrueba(i) = "D-445" Then

                        Dim Particulas As String = Valor1(i)
                        Dim Filtracion As String = Valor2(i)
                        Dim Resultado As String = Valor3(i)

                        For k As Integer = 0 To pruebasproducto - 1
                            If TextBoxArray(k).Name = "TxtBxD-445" Then
                                TextBoxArray(k).Text = Resultado
                            End If
                        Next

                    ElseIf IDPrueba(i) = "MMIN" Then

                        Dim LecturaNMTDesp As Double = Valor1(i)
                        Dim CorreccionDesp As Double = Valor2(i)
                        Dim Valor As Double = LecturaNMTDesp + CorreccionDesp

                        Valor = Valor * 6.895
                        Valor = Math.Round(Valor * 4) / 4

                        Dim A As Double = Valor3(i)

                        Valor = Valor + (1.13 * A)

                        Valor = Round(Valor, 1, MidpointRounding.ToEven)

                        For k As Integer = 0 To pruebasproducto - 1
                            If TextBoxArray(k).Name = "TxtBxMMIN" Then
                                TextBoxArray(k).Text = Valor
                            End If
                        Next

                    ElseIf IDPrueba(i) = "EN14078" Then

                        Dim RelacionDilucion As String = Valor1(i)
                        Dim DatoCurva As String = Valor2(i)
                        Dim DensidadBioD As String = Valor3(i)
                        Dim Obs As String = Valor4(i)
                        Dim Resultado As String = Valor5(i)

                        For k As Integer = 0 To pruebasproducto - 1
                            If TextBoxArray(k).Name = "TxtBxEN14078" Then
                                TextBoxArray(k).Text = Resultado
                            End If
                        Next

                    ElseIf IDPrueba(i) = "EN12937" Then

                        Dim PesoMuestra As String = Valor1(i)
                        Dim Concentracion As Decimal = Valor2(i)
                        Dim Obs As String = Valor3(i)

                        Concentracion = Round(Concentracion, 3, MidpointRounding.ToEven)

                        For k As Integer = 0 To pruebasproducto - 1
                            If TextBoxArray(k).Name = "TxtBxEN12937" Then
                                TextBoxArray(k).Text = Concentracion
                            End If
                        Next

                    ElseIf IDPrueba(i) = "D-7321" Then

                        Dim Wi1 As Double = Valor1(i)
                        Dim Wf1 As Double = Valor2(i)
                        Dim Wi2 As Double = Valor3(i)
                        Dim Wf2 As Double = Valor4(i)
                        Dim Wi3 As Double = Valor5(i)
                        Dim Wf3 As Double = Valor6(i)
                        Dim Vol1 As Double = Valor7(i)
                        Dim Vol2 As Double = Valor8(i)
                        Dim Vol3 As Double = Valor9(i)

                        Dim Diff1 As Double = Wi1 - Wf1
                        Dim Diff2 As Double = Wi2 - Wf2
                        Dim Diff3 As Double = Wi3 - Wf3

                        Dim SumW As Double = Diff1 + Diff2 + Diff3
                        Dim SumVol As Double = Vol1 + Vol2 + Vol3

                        Dim Resultado As Double = (SumW / SumVol) * 1000000

                        For k As Integer = 0 To pruebasproducto - 1
                            If TextBoxArray(k).Name = "TxtBxD-7321" Then
                                TextBoxArray(k).Text = Resultado
                            End If
                        Next

                    ElseIf IDPrueba(i) = "D-525" Then

                        Dim HoraInicio As String = Valor1(i)
                        Dim CaidaPresion As String = Valor2(i)
                        Dim PromedioTemp As Double = Valor3(i)
                        Dim IPT As Double = Valor4(i)
                        Dim Resultado As Decimal

                        If PromedioTemp > 100 Then
                            Resultado = IPT * ((1 + (0.101 * (PromedioTemp - 100))))
                        ElseIf PromedioTemp < 100 Then
                            Resultado = IPT * ((1 + (0.101 * (100 - PromedioTemp))))
                        ElseIf PromedioTemp = 100 Then
                            Resultado = IPT
                        End If

                        For k As Integer = 0 To pruebasproducto - 1
                            If TextBoxArray(k).Name = "TxtBxD-525" Then
                                TextBoxArray(k).Text = Resultado
                            End If
                        Next

                    ElseIf IDPrueba(i) = "D-381" Then

                        If TxtBxTipoProductoID.Text = "4" Then
                            Dim B As Double = Valor1(i)
                            Dim D As Double = Valor2(i)
                            Dim X As Double = Valor3(i)
                            Dim Y As Double = Valor4(i)
                            Dim MaterialSuspendido As String = Valor7(i)
                            Dim Filtracion As String = Valor8(i)
                            Dim Resultado As String

                            Dim A As Decimal = 2000 * (B - D + X - Y)

                            If A < 1 Then

                                Resultado = "<1"

                            Else

                                Dim temp As Decimal = Round(A)
                                Resultado = temp.ToString

                            End If

                            For k As Integer = 0 To pruebasproducto - 1
                                If TextBoxArray(k).Name = "TxtBxD-381" Then
                                    TextBoxArray(k).Text = Resultado
                                End If
                            Next

                        ElseIf TxtBxTipoProductoID.Text = "6" Or TxtBxTipoProductoID.Text = "7" Or TxtBxTipoProductoID.Text = "8" Or TxtBxTipoProductoID.Text = "9" Then

                            Dim B As Double = Valor1(i)
                            Dim D As Double = Valor2(i)
                            Dim X As Double = Valor3(i)
                            Dim Y As Double = Valor4(i)
                            Dim C As Double = Valor5(i)
                            Dim Z As Double = Valor6(i)
                            Dim MaterialSuspendido As String = Valor7(i)
                            Dim Filtracion As String = Valor8(i)
                            Dim Resultado1 As String
                            Dim Resultado2 As String

                            Dim U As Decimal = 2000 * (B - D + X - Y)
                            Dim S As Decimal = 2000 * (C - D + X - Z)

                            If U < 0.5 Then
                                Resultado1 = "<0.5"
                            Else
                                Dim temp As Decimal = Math.Round(U * 2) / 2
                                Resultado1 = temp.ToString
                            End If

                            If S < 0.5 Then
                                Resultado2 = "<0.5"
                            Else
                                Dim temp As Decimal = Math.Round(S * 2) / 2
                                Resultado2 = temp.ToString
                            End If

                            For k As Integer = 0 To pruebasproducto - 1
                                If TextBoxArray(k).Name = "TxtBxD-381" Then
                                    TextBoxArray(k).Text = Resultado2
                                End If
                            Next

                        End If

                    ElseIf IDPrueba(i) = "D-3338" Then

                        Dim Lt1 As Double = Valor1(i)
                        Dim Lt2 As Double = Valor2(i)
                        Dim Lt3 As Double = Valor3(i)
                        Dim Lt4 As Double = Valor4(i)
                        Dim La1 As Double = Valor5(i)
                        Dim La2 As Double = Valor6(i)
                        Dim La3 As Double = Valor7(i)
                        Dim La4 As Double = Valor8(i)

                        Dim calc1 As Decimal = (La1 / Lt1) * 100
                        Dim calc2 As Decimal = (La2 / Lt2) * 100
                        Dim calc3 As Decimal = (La3 / Lt3) * 100
                        Dim calc4 As Decimal = (La4 / Lt4) * 100

                        calc1 = Round(calc1, 1)
                        calc2 = Round(calc2, 1)
                        calc3 = Round(calc3, 1)
                        calc4 = Round(calc4, 1)

                        Dim A As Decimal = (calc1 + calc2 + calc3 + calc4) / 4

                        A = Round(A, 1)

                        Dim D As Double = Valor9(i)

                        Dim T10 As Double = Valor10(i)
                        Dim T50 As Double = Valor11(i)
                        Dim T90 As Double = Valor12(i)

                        Dim T As Double = (T10 + T50 + T90) / 3

                        Dim LibreAzufre As Decimal = ((5528.73 - (92.6499 * A) + (10.1601 * T) + (0.314169 * A * T)) / D) + (0.0791707 * A) - (0.00944893 * T) - (0.000292178 * A * T) + 35.9936

                        Dim muestra1 As Double = Valor13(i)
                        Dim muestra2 As Double = Valor14(i)
                        Dim prom As Decimal
                        If muestra2 = 0 Then
                            prom = muestra1
                            prom = Round(prom, 4)
                        Else
                            prom = (muestra1 + muestra2) / 2

                            prom = Round(prom, 4)
                        End If

                        Dim Resultado As Double

                        If prom = 0 Then
                            Resultado = LibreAzufre
                        Else
                            Resultado = LibreAzufre * (1 - (0.01 * prom)) + (0.10166 * prom)
                        End If

                        Resultado = Round(Resultado, 3, MidpointRounding.ToEven)

                        For k As Integer = 0 To pruebasproducto - 1
                            If TextBoxArray(k).Name = "TxtBxD-3338" Then
                                TextBoxArray(k).Text = Resultado
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