Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports iTextSharp.text.pdf
Imports System.IO
Imports iTextSharp.text


Public Class Form5

    Dim conn As New MySqlConnection

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

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TxtBxIDMuestra.Clear()
        'TxtBxOrigen.Clear()
        'TxtBxLote.Clear()
        'TxtBxATN.Clear()
        Connect()
        CArgarDGV()

        If TxtBxTipoProductoID.Text = "1" Then
            RBEspecifica.Checked = True
            GrpBxTipoPrueba.Enabled = False
        Else
            RBEspecifica.Checked = False
            GrpBxTipoPrueba.Enabled = True
        End If

        If TxtBxTipoProductoID.Text = "2" Or TxtBxTipoProductoID.Text = "3" Or TxtBxTipoProductoID.Text = "4" _
            Or TxtBxTipoProductoID.Text = "5" Then
            CBPruebaMicro.Visible = True
            If TxtBxTipoProductoID.Text = "3" Then
                PorcentajeBioD.Visible = True
            Else
                PorcentajeBioD.Visible = False
            End If
        Else
            CBPruebaMicro.Visible = False
            PorcentajeBioD.Visible = False
        End If

    End Sub

    Private Sub CArgarDGV()
        Dim query As String = "Select reportes.ID_Prueba, pruebas.Nombre as 'Prueba', Valor, Valor_2, Valor_3, Valor_4, Valor_5
                               from reportes inner join pruebas on reportes.ID_Prueba = pruebas.ID_Prueba
                               where ProductoID = '" & TxtBxIDProducto.Text & "';"

        Dim cmd As New MySqlCommand(query, conn)
        Dim reader As MySqlDataReader

        Try
            conn.Open()
            Console.WriteLine("Cargando Pruebas de este reporte")

            reader = cmd.ExecuteReader

            Dim table As New DataTable
            table.Load(reader)
            DGV.DataSource = table
            DGV.ReadOnly = True
            DGV.AllowUserToResizeColumns = True
            DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            reader.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, False, "Error")
            conn.Close()
        End Try

    End Sub

    Private Sub BtnRechazarReporte_Click(sender As Object, e As EventArgs) Handles BtnRechazarReporte.Click
        If RchTxtBxObservaciones.Text.Trim.Length = 0 Then
            If MessageBox.Show("¿Esta seguro que desea rechazar el analisis sin dejar ninguna observacion?", "Advertencia", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Try
                    conn.Open()
                    Dim cmd As New MySqlCommand(String.Format("UPDATE `bd_productos`.`productos` SET `Estado`='Pendiente', `Observaciones_Administrador` = '" & RchTxtBxObservaciones.Text & "' WHERE `ProductoID`='" & TxtBxIDProducto.Text & "';"), conn)
                    cmd.ExecuteNonQuery()
                    conn.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                    conn.Close()
                End Try
                Form1.CargarDGVProductosRevisados()
                Form1.CargarDGVProductosLimite()
                Form1.CargarDGVProductosSinRevisar()
                Form1.ProductosFechaLimiteCerca()
                Me.Close()
            End If
        Else
            Try
                conn.Open()
                Dim cmd As New MySqlCommand(String.Format("UPDATE `bd_productos`.`productos` SET `Estado`='Pendiente', `Observaciones_Administrador` = '" & RchTxtBxObservaciones.Text & "' WHERE `ProductoID`='" & TxtBxIDProducto.Text & "';"), conn)
                cmd.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                conn.Close()
            End Try
            Form1.CargarDGVProductosRevisados()
            Form1.CargarDGVProductosLimite()
            Form1.CargarDGVProductosSinRevisar()
            Form1.ProductosFechaLimiteCerca()
            Me.Close()
        End If
    End Sub

    Private Sub BtnAceptarReporte_Click(sender As Object, e As EventArgs) Handles BtnAceptarReporte.Click

        If RBBasica.Checked = False And RBCompleta.Checked = False And RBEspecifica.Checked = False Then
            MsgBox("Seleccione un tipo de prueba", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        If TxtBxATN.Text.Trim.Length = 0 Then
            MsgBox("El campo ATN no puede estar vacio", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        LlenarPDF()
    End Sub

    Sub CrearMail(pathfile As String)
        Dim OutApp As Object
        Dim OutMail As Object
        OutApp = CreateObject("Outlook.Application")
        OutMail = OutApp.CreateItem(0)
        On Error Resume Next
        Name = Path.GetFileName(pathfile)
        ' Change the mail address and subject in the macro before you run it.
        With OutMail
            '.To = "faizalmh@gmail.com"
            '.CC = ""
            '.BCC = ""
            .Subject = "Envio Reporte: " & Name
            '.Body = "Hello World!"
            .Attachments.Add(pathfile)
            .Display
            ' .Send
        End With
        On Error GoTo 0
        OutMail = Nothing
        OutApp = Nothing
    End Sub

    Private Sub LlenarPDF()
        If TxtBxTipoProductoID.Text = "1" Then

            Dim pdfTemplate As String = ConfigurationManager.AppSettings("Key1")
            Dim GuardarPDF As New SaveFileDialog
            GuardarPDF.InitialDirectory = "C:\"
            GuardarPDF.RestoreDirectory = False
            GuardarPDF.DefaultExt = ".pdf"
            GuardarPDF.ShowDialog()
            Dim filepath As String
            Dim tipo_prueba As Integer

            Dim imgurl As String = ConfigurationManager.AppSettings("Image")

            Try
                filepath = Path.GetFullPath(GuardarPDF.FileName)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                Exit Sub
            End Try

            Dim pdfReader As New PdfReader(pdfTemplate)
            Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(
                    filepath, FileMode.Create))
            Dim imgstream As New FileStream(imgurl, FileMode.Open, FileAccess.Read)
            Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imgstream)
            Dim content As PdfContentByte = pdfStamper.GetOverContent(1)
            img.ScaleToFit(80, 100)
            img.SetAbsolutePosition(260, 320)



            Dim pdfFormFields As AcroFields = pdfStamper.AcroFields
            pdfFormFields.SetField("Cliente", TxtBxCliente.Text)
            pdfFormFields.SetField("DIRECCION", TxtBxDireccion.Text)
            pdfFormFields.SetField("ATN", TxtBxATN.Text)
            pdfFormFields.SetField("FECHA RECIBO", TxtBxFechaEntrada.Text)
            pdfFormFields.SetField("HORA", TxtBxHoraEntrada.Text)
            pdfFormFields.SetField("FECHA REPORTE", TxtBxFechaReporte.Text)
            pdfFormFields.SetField("PERIODO DE ANALISIS", TxtBxPeriodoAnalisis.Text.ToUpper)
            pdfFormFields.SetField("ID MUESTRA", TxtBxIDMuestra.Text)
            pdfFormFields.SetField("No LABORATORIO", TxtBxIDProducto.Text.Substring(5))
            pdfFormFields.SetField("No REPORTE", TxtBxIDProducto.Text)
            pdfFormFields.SetField("ORIGEN TANQUE", TxtBxOrigen.Text)
            pdfFormFields.SetField("Lote", TxtBxLote.Text)
            pdfFormFields.SetField("Observaciones", RchTxtBxObservaciones.Text)
            pdfFormFields.SetField("Nombre", Form1.LblUsuario.Text.Substring(14))

            If RBCompleta.Checked = True Then
                pdfFormFields.SetField("CBBasico", "0")
                pdfFormFields.SetField("CBCompleto", "Yes")
                pdfFormFields.SetField("CBEspecifico", "0")
                tipo_prueba = 2
            ElseIf RBBasica.Checked = True Then
                pdfFormFields.SetField("CBBasico", "Yes")
                pdfFormFields.SetField("CBCompleto", "0")
                pdfFormFields.SetField("CBEspecifico", "0")
                tipo_prueba = 1
            ElseIf RBEspecifica.Checked = True Then
                pdfFormFields.SetField("CBBasico", "0")
                pdfFormFields.SetField("CBCompleto", "0")
                pdfFormFields.SetField("CBEspecifico", "Yes")
                tipo_prueba = 3
            End If

            Dim filas_total As Integer = DGV.RowCount - 2

            Dim id_prueba As String
            Dim valor_prueba As String

            For i As Integer = 0 To filas_total
                id_prueba = DGV(0, i).Value

                valor_prueba = DGV(6, i).Value.ToString.Trim
                If valor_prueba = "" Then
                    valor_prueba = DGV(5, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(4, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(3, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(2, i).Value.ToString.Trim
                End If

                Select Case id_prueba
                    Case "D-1298"
                        pdfFormFields.SetField("GravedadEspecifica", valor_prueba)
                        Exit Select
                    Case "E-1064"
                        pdfFormFields.SetField("ContenidoAguaKF", valor_prueba)
                        Exit Select
                    Case Else
                        MsgBox("La prueba" & id_prueba & " no se encuentra en la plantilla PDF y por tanto no podra agregarse a esta.", MsgBoxStyle.Exclamation, "Error")
                        Exit Select
                End Select

            Next

            content.AddImage(img)

            pdfStamper.FormFlattening = True
            pdfStamper.Close()

            Try
                conn.Open()
                Dim cmd As New MySqlCommand(String.Format("UPDATE `bd_productos`.`productos` SET `Estado`='Aprobado', `ID_Muestra` = '" & TxtBxIDMuestra.Text & "',`Tanque`='" & TxtBxOrigen.Text & "', `Lote`='" & TxtBxLote.Text & "', `ATN`='" & TxtBxATN.Text & "', `TipodePrueba`='" & tipo_prueba & "', `Observaciones_Administrador` ='" & RchTxtBxObservaciones.Text & "' WHERE `ProductoID`='" & TxtBxIDProducto.Text & "';"), conn)
                cmd.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                conn.Close()
            End Try

            MsgBox("Reporte Generado en " & filepath, MsgBoxStyle.Information, "PDF Creado")

            If MessageBox.Show("¿Desea generar un correo con el archivo creado?", "Crear Correo", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                CrearMail(filepath)
            End If

            Try
                Process.Start(filepath)
            Catch ex As Exception
                MsgBox("No se encontro el archivo", MsgBoxStyle.Exclamation, "Error")
            End Try


            Form1.CargarDGVProductosRevisados()
            Me.Close()

        ElseIf TxtBxTipoProductoID.Text = "2" And CBPruebaMicro.Checked = False Then

            Dim pdfTemplate As String = ConfigurationManager.AppSettings("Key2")
            Dim GuardarPDF As New SaveFileDialog
            GuardarPDF.InitialDirectory = "C:\"
            GuardarPDF.RestoreDirectory = False
            GuardarPDF.DefaultExt = ".pdf"
            GuardarPDF.ShowDialog()
            Dim filepath As String
            Dim tipo_prueba As Integer

            Dim imgurl As String = ConfigurationManager.AppSettings("Image")

            Try
                filepath = Path.GetFullPath(GuardarPDF.FileName)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                Exit Sub
            End Try

            Dim pdfReader As New PdfReader(pdfTemplate)
            Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(
                    filepath, FileMode.Create))
            Dim imgstream As New FileStream(imgurl, FileMode.Open, FileAccess.Read)
            Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imgstream)
            Dim content As PdfContentByte = pdfStamper.GetOverContent(1)
            img.ScaleToFit(80, 100)
            img.SetAbsolutePosition(240, 295)



            Dim pdfFormFields As AcroFields = pdfStamper.AcroFields
            pdfFormFields.SetField("Cliente", TxtBxCliente.Text)
            pdfFormFields.SetField("DIRECCION", TxtBxDireccion.Text)
            pdfFormFields.SetField("ATN", TxtBxATN.Text)
            pdfFormFields.SetField("FECHA RECIBO", TxtBxFechaEntrada.Text)
            pdfFormFields.SetField("HORA", TxtBxHoraEntrada.Text)
            pdfFormFields.SetField("FECHA REPORTE", TxtBxFechaReporte.Text)
            pdfFormFields.SetField("PERIODO DE ANALISIS", TxtBxPeriodoAnalisis.Text.ToUpper)
            pdfFormFields.SetField("ID MUESTRA", TxtBxIDMuestra.Text)
            pdfFormFields.SetField("No LABORATORIO", TxtBxIDProducto.Text.Substring(5))
            pdfFormFields.SetField("No REPORTE", TxtBxIDProducto.Text)
            pdfFormFields.SetField("ORIGEN TANQUE", TxtBxOrigen.Text)
            pdfFormFields.SetField("Lote", TxtBxLote.Text)
            pdfFormFields.SetField("Observaciones", RchTxtBxObservaciones.Text)
            pdfFormFields.SetField("NOMBRE", Form1.LblUsuario.Text.Substring(14))
            If RBCompleta.Checked = True Then
                pdfFormFields.SetField("CBBasico", "0")
                pdfFormFields.SetField("CBCompleto", "Yes")
                pdfFormFields.SetField("CBEspecifico", "0")
                tipo_prueba = 2
            ElseIf RBBasica.Checked = True Then
                pdfFormFields.SetField("CBBasico", "Yes")
                pdfFormFields.SetField("CBCompleto", "0")
                pdfFormFields.SetField("CBEspecifico", "0")
                tipo_prueba = 1
            ElseIf RBEspecifica.Checked = True Then
                pdfFormFields.SetField("CBBasico", "0")
                pdfFormFields.SetField("CBCompleto", "0")
                pdfFormFields.SetField("CBEspecifico", "Yes")
                tipo_prueba = 3
            End If

            Dim filas_total As Integer = DGV.RowCount - 2

            Dim id_prueba As String
            Dim valor_prueba As String

            For i As Integer = 0 To filas_total
                id_prueba = DGV(0, i).Value

                valor_prueba = DGV(6, i).Value.ToString.Trim
                If valor_prueba = "" Then
                    valor_prueba = DGV(5, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(4, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(3, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(2, i).Value.ToString.Trim
                End If

                Select Case id_prueba
                    Case "EN12937"
                        pdfFormFields.SetField("HumedadKF", valor_prueba)
                        Exit Select
                    Case "EN14103-01"
                        pdfFormFields.SetField("FAME", valor_prueba)
                        Exit Select
                    Case "EN14103-02"
                        pdfFormFields.SetField("Ester", valor_prueba)
                        Exit Select
                    Case "D-7321"
                        pdfFormFields.SetField("ContaminacionTotal", valor_prueba)
                        Exit Select
                    Case "D-97"
                        pdfFormFields.SetField("PuntoFluidez", valor_prueba)
                        Exit Select
                    Case "D-2500"
                        pdfFormFields.SetField("PuntoNube", valor_prueba)
                        Exit Select
                    Case Else
                        MsgBox("La prueba" & id_prueba & " no se encuentra en la plantilla PDF y por tanto no podra agregarse a esta.", MsgBoxStyle.Exclamation, "Error")
                        Exit Select
                End Select

            Next

            content.AddImage(img)

            pdfStamper.FormFlattening = True
            pdfStamper.Close()

            Try
                conn.Open()
                Dim cmd As New MySqlCommand(String.Format("UPDATE `bd_productos`.`productos` SET `Estado`='Aprobado', `ID_Muestra` = '" & TxtBxIDMuestra.Text & "',`Tanque`='" & TxtBxOrigen.Text & "', `Lote`='" & TxtBxLote.Text & "', `ATN`='" & TxtBxATN.Text & "', `TipodePrueba`='" & tipo_prueba & "', `Observaciones_Administrador` ='" & RchTxtBxObservaciones.Text & "' WHERE `ProductoID`='" & TxtBxIDProducto.Text & "';"), conn)
                cmd.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                conn.Close()
            End Try

            MsgBox("Reporte Generado en " & filepath, MsgBoxStyle.Information, "PDF Creado")

            If MessageBox.Show("¿Desea generar un correo con el archivo creado?", "Crear Correo", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                CrearMail(filepath)
            End If

            Try
                Process.Start(filepath)
            Catch ex As Exception
                MsgBox("No se encontro el archivo", MsgBoxStyle.Exclamation, "Error")
            End Try


            Form1.CargarDGVProductosRevisados()
            Me.Close()

        ElseIf TxtBxTipoProductoID.Text = "3" And CBPruebaMicro.Checked = False Then


            Dim pdfTemplate As String = ConfigurationManager.AppSettings("Key8")
            Dim GuardarPDF As New SaveFileDialog
            GuardarPDF.InitialDirectory = "C:\"
            GuardarPDF.RestoreDirectory = False
            GuardarPDF.DefaultExt = ".pdf"
            GuardarPDF.ShowDialog()
            Dim filepath As String
            Dim tipo_prueba As Integer

            Dim imgurl As String = ConfigurationManager.AppSettings("Image")

            Try
                filepath = Path.GetFullPath(GuardarPDF.FileName)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                Exit Sub
            End Try

            Dim pdfReader As New PdfReader(pdfTemplate)
            Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(
                    filepath, FileMode.Create))
            Dim imgstream As New FileStream(imgurl, FileMode.Open, FileAccess.Read)
            Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imgstream)
            Dim content As PdfContentByte = pdfStamper.GetOverContent(1)
            img.ScaleToFit(80, 100)
            img.SetAbsolutePosition(250, 145)



            Dim pdfFormFields As AcroFields = pdfStamper.AcroFields
            pdfFormFields.SetField("Cliente", TxtBxCliente.Text)
            pdfFormFields.SetField("DIRECCION", TxtBxDireccion.Text)
            pdfFormFields.SetField("ATN", TxtBxATN.Text)
            pdfFormFields.SetField("FECHA RECIBO", TxtBxFechaEntrada.Text)
            pdfFormFields.SetField("HORA", TxtBxHoraEntrada.Text)
            pdfFormFields.SetField("FECHA REPORTE", TxtBxFechaReporte.Text)
            pdfFormFields.SetField("PERIODO DE ANALISIS", TxtBxPeriodoAnalisis.Text.ToUpper)
            pdfFormFields.SetField("ID MUESTRA", TxtBxIDMuestra.Text)
            pdfFormFields.SetField("No LABORATORIO", TxtBxIDProducto.Text.Substring(5))
            pdfFormFields.SetField("No REPORTE", TxtBxIDProducto.Text)
            pdfFormFields.SetField("ORIGEN TANQUE", TxtBxOrigen.Text)
            pdfFormFields.SetField("Lote", TxtBxLote.Text)
            pdfFormFields.SetField("Observaciones", "Tipo de Producto: B" & PorcentajeBioD.Text & ". " & RchTxtBxObservaciones.Text)
            pdfFormFields.SetField("Nombre", Form1.LblUsuario.Text.Substring(14))
            If RBCompleta.Checked = True Then
                pdfFormFields.SetField("CBBasico", "0")
                pdfFormFields.SetField("CBCompleto", "Yes")
                pdfFormFields.SetField("CBEspecifico", "0")
                tipo_prueba = 2
            ElseIf RBBasica.Checked = True Then
                pdfFormFields.SetField("CBBasico", "Yes")
                pdfFormFields.SetField("CBCompleto", "0")
                pdfFormFields.SetField("CBEspecifico", "0")
                tipo_prueba = 1
            ElseIf RBEspecifica.Checked = True Then
                pdfFormFields.SetField("CBBasico", "0")
                pdfFormFields.SetField("CBCompleto", "0")
                pdfFormFields.SetField("CBEspecifico", "Yes")
                tipo_prueba = 3
            End If

            Dim filas_total As Integer = DGV.RowCount - 2

            Dim id_prueba As String
            Dim valor_prueba As String

            For i As Integer = 0 To filas_total
                id_prueba = DGV(0, i).Value

                valor_prueba = DGV(6, i).Value.ToString.Trim
                If valor_prueba = "" Then
                    valor_prueba = DGV(5, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(4, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(3, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(2, i).Value.ToString.Trim
                End If

                Select Case id_prueba
                    Case "D-1298"
                        pdfFormFields.SetField("GravedadAPI60", valor_prueba)
                        Exit Select
                    Case "D-1250"
                        pdfFormFields.SetField("Densidad15C", valor_prueba)
                        Exit Select
                    Case "D-86-01"
                        pdfFormFields.SetField("TxtBxPIE", valor_prueba)
                        Exit Select
                    Case "D-86-03"
                        pdfFormFields.SetField("TxtBxRecog10", valor_prueba)
                        Exit Select
                    Case "D-86-07"
                        pdfFormFields.SetField("TxtBxRecog50", valor_prueba)
                        Exit Select
                    Case "D-86-11"
                        pdfFormFields.SetField("TxtBxRecog90", valor_prueba)
                        Exit Select
                    Case "D-86-12"
                        pdfFormFields.SetField("TxtBxRecog95", valor_prueba)
                        Exit Select
                    Case "D-86-24"
                        pdfFormFields.SetField("TxtBxPFE", valor_prueba)
                        Exit Select
                    Case "D-86-25"
                        pdfFormFields.SetField("TxtBxResiduoDest", valor_prueba)
                        Exit Select
                    Case "D-86-26"
                        pdfFormFields.SetField("TxtBxPerdidaDest", valor_prueba)
                        Exit Select
                    Case "D-93"
                        pdfFormFields.SetField("FlashPoint", valor_prueba)
                        Exit Select
                    Case "D-4176"
                        pdfFormFields.SetField("Apariencia", valor_prueba)
                        Exit Select
                    Case "EN12937"
                        pdfFormFields.SetField("HumedadKF", valor_prueba)
                        Exit Select
                    Case "D-7321"
                        pdfFormFields.SetField("ContaminacionTotal", valor_prueba)
                        Exit Select
                    Case "EN14078"
                        pdfFormFields.SetField("DeterminacionBX", valor_prueba)
                        Exit Select
                    Case "D-4294-01"
                        pdfFormFields.SetField("Azufre%", valor_prueba)
                        Exit Select
                    Case "D-4294-02"
                        pdfFormFields.SetField("Azufremg", valor_prueba)
                        Exit Select
                    Case "D-97"
                        pdfFormFields.SetField("PuntoFluidez", valor_prueba)
                        Exit Select
                    Case "D-2500"
                        pdfFormFields.SetField("PuntoNube", valor_prueba)
                        Exit Select
                    Case Else
                        MsgBox("La prueba" & id_prueba & " no se encuentra en la plantilla PDF y por tanto no podra agregarse a esta.", MsgBoxStyle.Exclamation, "Error")
                        Exit Select
                End Select

            Next

            content.AddImage(img)

            pdfStamper.FormFlattening = True
            pdfStamper.Close()

            Try
                conn.Open()
                Dim cmd As New MySqlCommand(String.Format("UPDATE `bd_productos`.`productos` SET `Estado`='Aprobado', `ID_Muestra` = '" & TxtBxIDMuestra.Text & "',`Tanque`='" & TxtBxOrigen.Text & "', `Lote`='" & TxtBxLote.Text & "', `ATN`='" & TxtBxATN.Text & "', `TipodePrueba`='" & tipo_prueba & "', `Observaciones_Administrador` ='" & RchTxtBxObservaciones.Text & "' WHERE `ProductoID`='" & TxtBxIDProducto.Text & "';"), conn)
                cmd.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                conn.Close()
            End Try

            MsgBox("Reporte Generado en " & filepath, MsgBoxStyle.Information, "PDF Creado")

            If MessageBox.Show("¿Desea generar un correo con el archivo creado?", "Crear Correo", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                CrearMail(filepath)
            End If

            Try
                Process.Start(filepath)
            Catch ex As Exception
                MsgBox("No se encontro el archivo", MsgBoxStyle.Exclamation, "Error")
            End Try

            Form1.CargarDGVProductosRevisados()
            Me.Close()


        ElseIf TxtBxTipoProductoID.Text = "3" And CBPruebaMicro.Checked = True Then

            Dim pdfTemplate As String = ConfigurationManager.AppSettings("Micro")
            Dim GuardarPDF As New SaveFileDialog
            GuardarPDF.InitialDirectory = "C:\"
            GuardarPDF.RestoreDirectory = False
            GuardarPDF.DefaultExt = ".pdf"
            GuardarPDF.ShowDialog()
            Dim filepath As String
            Dim tipo_prueba As Integer

            Dim imgurl As String = ConfigurationManager.AppSettings("Image")

            Try
                filepath = Path.GetFullPath(GuardarPDF.FileName)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                Exit Sub
            End Try

            Dim pdfReader As New PdfReader(pdfTemplate)
            Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(
                    filepath, FileMode.Create))
            Dim imgstream As New FileStream(imgurl, FileMode.Open, FileAccess.Read)
            Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imgstream)
            Dim content As PdfContentByte = pdfStamper.GetOverContent(1)
            img.ScaleToFit(80, 100)
            img.SetAbsolutePosition(270, 232)



            Dim pdfFormFields As AcroFields = pdfStamper.AcroFields
            pdfFormFields.SetField("Producto", TxtBxProducto.Text.ToUpper)
            pdfFormFields.SetField("Cliente", TxtBxCliente.Text)
            pdfFormFields.SetField("DIRECCION", TxtBxDireccion.Text)
            pdfFormFields.SetField("ATN", TxtBxATN.Text)
            pdfFormFields.SetField("FECHA RECIBO", TxtBxFechaEntrada.Text)
            pdfFormFields.SetField("HORA", TxtBxHoraEntrada.Text)
            pdfFormFields.SetField("FECHA REPORTE", TxtBxFechaReporte.Text)
            pdfFormFields.SetField("PERIODO DE ANALISIS", TxtBxPeriodoAnalisis.Text.ToUpper)
            pdfFormFields.SetField("ID MUESTRA", TxtBxIDMuestra.Text)
            pdfFormFields.SetField("No LABORATORIO", TxtBxIDProducto.Text.Substring(5))
            pdfFormFields.SetField("No REPORTE", TxtBxIDProducto.Text)
            pdfFormFields.SetField("ORIGEN TANQUE", TxtBxOrigen.Text)
            pdfFormFields.SetField("Lote", TxtBxLote.Text)
            pdfFormFields.SetField("Observaciones", "Tipo de Producto B2E. " & RchTxtBxObservaciones.Text)
            pdfFormFields.SetField("Nombre", Form1.LblUsuario.Text.Substring(14))

            Dim filas_total As Integer = DGV.RowCount - 2

            Dim id_prueba As String
            Dim valor_prueba As String

            For i As Integer = 0 To filas_total
                id_prueba = DGV(0, i).Value

                valor_prueba = DGV(6, i).Value.ToString.Trim
                If valor_prueba = "" Then
                    valor_prueba = DGV(5, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(4, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(3, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(2, i).Value.ToString.Trim
                End If

                Select Case id_prueba
                    Case "D-7978-01"
                        pdfFormFields.SetField("DeterminacionMicroorganismos L", valor_prueba)
                        Exit Select
                    Case "D-7978-02"
                        pdfFormFields.SetField("DeterminacionMicroorganismos mL", valor_prueba)
                        Exit Select
                    Case Else
                        MsgBox("La prueba" & id_prueba & " no se encuentra en la plantilla PDF", MsgBoxStyle.Exclamation, "Error")
                        Exit Select
                End Select

            Next

            content.AddImage(img)

            pdfStamper.FormFlattening = True
            pdfStamper.Close()

            Try
                conn.Open()
                Dim cmd As New MySqlCommand(String.Format("UPDATE `bd_productos`.`productos` SET `Estado`='Aprobado', `ID_Muestra` = '" & TxtBxIDMuestra.Text & "',`Tanque`='" & TxtBxOrigen.Text & "', `Lote`='" & TxtBxLote.Text & "', `ATN`='" & TxtBxATN.Text & "', `TipodePrueba`='" & tipo_prueba & "', `Observaciones_Administrador` ='" & RchTxtBxObservaciones.Text & "' WHERE `ProductoID`='" & TxtBxIDProducto.Text & "';"), conn)
                cmd.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                conn.Close()
            End Try

            MsgBox("Reporte Generado en " & filepath, MsgBoxStyle.Information, "PDF Creado")

            If MessageBox.Show("¿Desea generar un correo con el archivo creado?", "Crear Correo", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                CrearMail(filepath)
            End If

            Try
                Process.Start(filepath)
            Catch ex As Exception
                MsgBox("No se encontro el archivo", MsgBoxStyle.Exclamation, "Error")
            End Try


            Form1.CargarDGVProductosRevisados()
            Me.Close()

            'ElseIf TxtBxTipoProductoID.Text = "5" And CBPruebaMicro.Checked = False Then

            '    Dim pdfTemplate As String = ConfigurationManager.AppSettings("Key8")
            '    Dim GuardarPDF As New SaveFileDialog
            '    GuardarPDF.InitialDirectory = "C:\"
            '    GuardarPDF.RestoreDirectory = False
            '    GuardarPDF.DefaultExt = ".pdf"
            '    GuardarPDF.ShowDialog()
            '    Dim filepath As String
            '    Dim tipo_prueba As Integer

            '    Dim imgurl As String = ConfigurationManager.AppSettings("Image")

            '    Try
            '        filepath = Path.GetFullPath(GuardarPDF.FileName)
            '    Catch ex As Exception
            '        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
            '        Exit Sub
            '    End Try

            '    Dim pdfReader As New PdfReader(pdfTemplate)
            '    Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(
            '            filepath, FileMode.Create))
            '    Dim imgstream As New FileStream(imgurl, FileMode.Open, FileAccess.Read)
            '    Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imgstream)
            '    Dim content As PdfContentByte = pdfStamper.GetOverContent(1)
            '    img.ScaleToFit(80, 100)
            '    img.SetAbsolutePosition(250, 145)



            '    Dim pdfFormFields As AcroFields = pdfStamper.AcroFields
            '    pdfFormFields.SetField("Cliente", TxtBxCliente.Text)
            '    pdfFormFields.SetField("DIRECCION", TxtBxDireccion.Text)
            '    pdfFormFields.SetField("ATN", TxtBxATN.Text)
            '    pdfFormFields.SetField("FECHA RECIBO", TxtBxFechaEntrada.Text)
            '    pdfFormFields.SetField("HORA", TxtBxHoraEntrada.Text)
            '    pdfFormFields.SetField("FECHA REPORTE", TxtBxFechaReporte.Text)
            '    pdfFormFields.SetField("PERIODO DE ANALISIS", TxtBxPeriodoAnalisis.Text.ToUpper)
            '    pdfFormFields.SetField("ID MUESTRA", TxtBxIDMuestra.Text)
            '    pdfFormFields.SetField("No LABORATORIO", TxtBxIDProducto.Text.Substring(5))
            '    pdfFormFields.SetField("No REPORTE", TxtBxIDProducto.Text)
            '    pdfFormFields.SetField("ORIGEN TANQUE", TxtBxOrigen.Text)
            '    pdfFormFields.SetField("Lote", TxtBxLote.Text)
            '    pdfFormFields.SetField("Observaciones", "Tipo de Producto: B" & PorcentajeBioD.Text & " " & RchTxtBxObservaciones.Text)
            '    pdfFormFields.SetField("Nombre", Form1.LblUsuario.Text.Substring(14))
            '    If RBCompleta.Checked = True Then
            '        pdfFormFields.SetField("CBBasico", "0")
            '        pdfFormFields.SetField("CBCompleto", "Yes")
            '        pdfFormFields.SetField("CBEspecifico", "0")
            '        tipo_prueba = 2
            '    ElseIf RBBasica.Checked = True Then
            '        pdfFormFields.SetField("CBBasico", "Yes")
            '        pdfFormFields.SetField("CBCompleto", "0")
            '        pdfFormFields.SetField("CBEspecifico", "0")
            '        tipo_prueba = 1
            '    ElseIf RBEspecifica.Checked = True Then
            '        pdfFormFields.SetField("CBBasico", "0")
            '        pdfFormFields.SetField("CBCompleto", "0")
            '        pdfFormFields.SetField("CBEspecifico", "Yes")
            '        tipo_prueba = 3
            '    End If

            '    Dim filas_total As Integer = DGV.RowCount - 2

            '    Dim id_prueba As String
            '    Dim valor_prueba As String

            '    For i As Integer = 0 To filas_total
            '        id_prueba = DGV(0, i).Value

            '        valor_prueba = DGV(6, i).Value.ToString.Trim
            '        If valor_prueba = "" Then
            '            valor_prueba = DGV(5, i).Value.ToString.Trim
            '        End If
            '        If valor_prueba = "" Then
            '            valor_prueba = DGV(4, i).Value.ToString.Trim
            '        End If
            '        If valor_prueba = "" Then
            '            valor_prueba = DGV(3, i).Value.ToString.Trim
            '        End If
            '        If valor_prueba = "" Then
            '            valor_prueba = DGV(2, i).Value.ToString.Trim
            '        End If

            '        Select Case id_prueba
            '            Case "D-1298"
            '                pdfFormFields.SetField("GravedadAPI60", valor_prueba)
            '                Exit Select
            '            Case "D-1250"
            '                pdfFormFields.SetField("Densidad15C", valor_prueba)
            '                Exit Select
            '            Case "D-86-01"
            '                pdfFormFields.SetField("TxtBxPIE", valor_prueba)
            '                Exit Select
            '            Case "D-86-03"
            '                pdfFormFields.SetField("TxtBxRecog10", valor_prueba)
            '                Exit Select
            '            Case "D-86-07"
            '                pdfFormFields.SetField("TxtBxRecog50", valor_prueba)
            '                Exit Select
            '            Case "D-86-11"
            '                pdfFormFields.SetField("TxtBxRecog90", valor_prueba)
            '                Exit Select
            '            Case "D-86-12"
            '                pdfFormFields.SetField("TxtBxRecog95", valor_prueba)
            '                Exit Select
            '            Case "D-86-24"
            '                pdfFormFields.SetField("TxtBxPFE", valor_prueba)
            '                Exit Select
            '            Case "D-86-25"
            '                pdfFormFields.SetField("TxtBxResiduoDest", valor_prueba)
            '                Exit Select
            '            Case "D-86-26"
            '                pdfFormFields.SetField("TxtBxPerdidaDest", valor_prueba)
            '                Exit Select
            '            Case "D-93"
            '                pdfFormFields.SetField("FlashPoint", valor_prueba)
            '                Exit Select
            '            Case "D-4176"
            '                pdfFormFields.SetField("Apariencia", valor_prueba)
            '                Exit Select
            '            Case "EN12937"
            '                pdfFormFields.SetField("HumedadKF", valor_prueba)
            '                Exit Select
            '            Case "D-7321"
            '                pdfFormFields.SetField("ContaminacionTotal", valor_prueba)
            '                Exit Select
            '            Case "EN14078"
            '                pdfFormFields.SetField("DeterminacionBX", valor_prueba)
            '                Exit Select
            '            Case "D-4294-01"
            '                pdfFormFields.SetField("Azufre%", valor_prueba)
            '                Exit Select
            '            Case "D-4294-02"
            '                pdfFormFields.SetField("Azufremg", valor_prueba)
            '                Exit Select
            '            Case "D-97"
            '                pdfFormFields.SetField("PuntoFluidez", valor_prueba)
            '                Exit Select
            '            Case "D-2500"
            '                pdfFormFields.SetField("PuntoNube", valor_prueba)
            '                Exit Select
            '            Case Else
            '                MsgBox("La prueba" & id_prueba & " no se encuentra en la plantilla PDF y por tanto no podra agregarse a esta.", MsgBoxStyle.Exclamation, "Error")
            '                Exit Select
            '        End Select

            '    Next

            '    content.AddImage(img)

            '    pdfStamper.FormFlattening = True
            '    pdfStamper.Close()

            '    Try
            '        conn.Open()
            '        Dim cmd As New MySqlCommand(String.Format("UPDATE `bd_productos`.`productos` SET `Estado`='Aprobado', `ID_Muestra` = '" & TxtBxIDMuestra.Text & "',`Tanque`='" & TxtBxOrigen.Text & "', `Lote`='" & TxtBxLote.Text & "', `ATN`='" & TxtBxATN.Text & "', `TipodePrueba`='" & tipo_prueba & "', `Observaciones_Administrador` ='" & RchTxtBxObservaciones.Text & "' WHERE `ProductoID`='" & TxtBxIDProducto.Text & "';"), conn)
            '        cmd.ExecuteNonQuery()
            '        conn.Close()
            '    Catch ex As Exception
            '        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
            '        conn.Close()
            '    End Try

            '    MsgBox("Reporte Generado en " & filepath, MsgBoxStyle.Information, "PDF Creado")

            '    If MessageBox.Show("¿Desea generar un correo con el archivo creado?", "Crear Correo", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            '        CrearMail(filepath)
            '    End If

            '    Try
            '        Process.Start(filepath)
            '    Catch ex As Exception
            '        MsgBox("No se encontro el archivo", MsgBoxStyle.Exclamation, "Error")
            '    End Try

            '    Form1.CargarDGVProductosRevisados()
            '    Me.Close()

        ElseIf TxtBxTipoProductoID.Text = "4" And CBPruebaMicro.Checked = True Then

            Dim pdfTemplate As String = ConfigurationManager.AppSettings("Micro")
            Dim GuardarPDF As New SaveFileDialog
            GuardarPDF.InitialDirectory = "C:\"
            GuardarPDF.RestoreDirectory = False
            GuardarPDF.DefaultExt = ".pdf"
            GuardarPDF.ShowDialog()
            Dim filepath As String
            Dim tipo_prueba As Integer

            Dim imgurl As String = ConfigurationManager.AppSettings("Image")

            Try
                filepath = Path.GetFullPath(GuardarPDF.FileName)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                Exit Sub
            End Try

            Dim pdfReader As New PdfReader(pdfTemplate)
            Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(
                    filepath, FileMode.Create))
            Dim imgstream As New FileStream(imgurl, FileMode.Open, FileAccess.Read)
            Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imgstream)
            Dim content As PdfContentByte = pdfStamper.GetOverContent(1)
            img.ScaleToFit(80, 100)
            img.SetAbsolutePosition(270, 232)



            Dim pdfFormFields As AcroFields = pdfStamper.AcroFields
            pdfFormFields.SetField("Producto", "B" & PorcentajeBioD.Text)
            pdfFormFields.SetField("Cliente", TxtBxCliente.Text)
            pdfFormFields.SetField("DIRECCION", TxtBxDireccion.Text)
            pdfFormFields.SetField("ATN", TxtBxATN.Text)
            pdfFormFields.SetField("FECHA RECIBO", TxtBxFechaEntrada.Text)
            pdfFormFields.SetField("HORA", TxtBxHoraEntrada.Text)
            pdfFormFields.SetField("FECHA REPORTE", TxtBxFechaReporte.Text)
            pdfFormFields.SetField("PERIODO DE ANALISIS", TxtBxPeriodoAnalisis.Text.ToUpper)
            pdfFormFields.SetField("ID MUESTRA", TxtBxIDMuestra.Text)
            pdfFormFields.SetField("No LABORATORIO", TxtBxIDProducto.Text.Substring(5))
            pdfFormFields.SetField("No REPORTE", TxtBxIDProducto.Text)
            pdfFormFields.SetField("ORIGEN TANQUE", TxtBxOrigen.Text)
            pdfFormFields.SetField("Lote", TxtBxLote.Text)
            pdfFormFields.SetField("Observaciones", "Tipo de Producto B" & PorcentajeBioD.Text & "." & RchTxtBxObservaciones.Text)
            pdfFormFields.SetField("Nombre", Form1.LblUsuario.Text.Substring(14))

            Dim filas_total As Integer = DGV.RowCount - 2

            Dim id_prueba As String
            Dim valor_prueba As String

            For i As Integer = 0 To filas_total
                id_prueba = DGV(0, i).Value

                valor_prueba = DGV(6, i).Value.ToString.Trim
                If valor_prueba = "" Then
                    valor_prueba = DGV(5, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(4, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(3, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(2, i).Value.ToString.Trim
                End If

                Select Case id_prueba
                    Case "D-7978-01"
                        pdfFormFields.SetField("DeterminacionMicroorganismos L", valor_prueba)
                        Exit Select
                    Case "D-7978-02"
                        pdfFormFields.SetField("DeterminacionMicroorganismos mL", valor_prueba)
                        Exit Select
                    Case Else
                        MsgBox("La prueba" & id_prueba & " no se encuentra en la plantilla PDF", MsgBoxStyle.Exclamation, "Error")
                        Exit Select
                End Select

            Next

            content.AddImage(img)

            pdfStamper.FormFlattening = True
            pdfStamper.Close()

            Try
                conn.Open()
                Dim cmd As New MySqlCommand(String.Format("UPDATE `bd_productos`.`productos` SET `Estado`='Aprobado', `ID_Muestra` = '" & TxtBxIDMuestra.Text & "',`Tanque`='" & TxtBxOrigen.Text & "', `Lote`='" & TxtBxLote.Text & "', `ATN`='" & TxtBxATN.Text & "', `TipodePrueba`='" & tipo_prueba & "', `Observaciones_Administrador` ='" & RchTxtBxObservaciones.Text & "' WHERE `ProductoID`='" & TxtBxIDProducto.Text & "';"), conn)
                cmd.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                conn.Close()
            End Try

            MsgBox("Reporte Generado en " & filepath, MsgBoxStyle.Information, "PDF Creado")

            If MessageBox.Show("¿Desea generar un correo con el archivo creado?", "Crear Correo", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                CrearMail(filepath)
            End If

            Try
                Process.Start(filepath)
            Catch ex As Exception
                MsgBox("No se encontro el archivo", MsgBoxStyle.Exclamation, "Error")
            End Try


            Form1.CargarDGVProductosRevisados()
            Me.Close()

        ElseIf TxtBxTipoProductoID.Text = "5" And CBPruebaMicro.Checked = False Then

            Dim pdfTemplate As String = ConfigurationManager.AppSettings("Key8")
            Dim GuardarPDF As New SaveFileDialog
            GuardarPDF.InitialDirectory = "C:\"
            GuardarPDF.RestoreDirectory = False
            GuardarPDF.DefaultExt = ".pdf"
            GuardarPDF.ShowDialog()
            Dim filepath As String
            Dim tipo_prueba As Integer

            Dim imgurl As String = ConfigurationManager.AppSettings("Image")

            Try
                filepath = Path.GetFullPath(GuardarPDF.FileName)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                Exit Sub
            End Try

            Dim pdfReader As New PdfReader(pdfTemplate)
            Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(
                    filepath, FileMode.Create))
            Dim imgstream As New FileStream(imgurl, FileMode.Open, FileAccess.Read)
            Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imgstream)
            Dim content As PdfContentByte = pdfStamper.GetOverContent(1)
            img.ScaleToFit(80, 100)
            img.SetAbsolutePosition(250, 145)



            Dim pdfFormFields As AcroFields = pdfStamper.AcroFields
            pdfFormFields.SetField("Cliente", TxtBxCliente.Text)
            pdfFormFields.SetField("DIRECCION", TxtBxDireccion.Text)
            pdfFormFields.SetField("ATN", TxtBxATN.Text)
            pdfFormFields.SetField("FECHA RECIBO", TxtBxFechaEntrada.Text)
            pdfFormFields.SetField("HORA", TxtBxHoraEntrada.Text)
            pdfFormFields.SetField("FECHA REPORTE", TxtBxFechaReporte.Text)
            pdfFormFields.SetField("PERIODO DE ANALISIS", TxtBxPeriodoAnalisis.Text.ToUpper)
            pdfFormFields.SetField("ID MUESTRA", TxtBxIDMuestra.Text)
            pdfFormFields.SetField("No LABORATORIO", TxtBxIDProducto.Text.Substring(5))
            pdfFormFields.SetField("No REPORTE", TxtBxIDProducto.Text)
            pdfFormFields.SetField("ORIGEN TANQUE", TxtBxOrigen.Text)
            pdfFormFields.SetField("Lote", TxtBxLote.Text)
            pdfFormFields.SetField("Observaciones", RchTxtBxObservaciones.Text)
            pdfFormFields.SetField("Nombre", Form1.LblUsuario.Text.Substring(14))
            If RBCompleta.Checked = True Then
                pdfFormFields.SetField("CBBasico", "0")
                pdfFormFields.SetField("CBCompleto", "Yes")
                pdfFormFields.SetField("CBEspecifico", "0")
                tipo_prueba = 2
            ElseIf RBBasica.Checked = True Then
                pdfFormFields.SetField("CBBasico", "Yes")
                pdfFormFields.SetField("CBCompleto", "0")
                pdfFormFields.SetField("CBEspecifico", "0")
                tipo_prueba = 1
            ElseIf RBEspecifica.Checked = True Then
                pdfFormFields.SetField("CBBasico", "0")
                pdfFormFields.SetField("CBCompleto", "0")
                pdfFormFields.SetField("CBEspecifico", "Yes")
                tipo_prueba = 3
            End If

            Dim filas_total As Integer = DGV.RowCount - 2

            Dim id_prueba As String
            Dim valor_prueba As String

            For i As Integer = 0 To filas_total
                id_prueba = DGV(0, i).Value

                valor_prueba = DGV(6, i).Value.ToString.Trim
                If valor_prueba = "" Then
                    valor_prueba = DGV(5, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(4, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(3, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(2, i).Value.ToString.Trim
                End If

                Select Case id_prueba
                    Case "D-1298"
                        pdfFormFields.SetField("GravedadAPI60", valor_prueba)
                        Exit Select
                    Case "D-1250"
                        pdfFormFields.SetField("Densidad15C", valor_prueba)
                        Exit Select
                    Case "D-86-01"
                        pdfFormFields.SetField("TxtBxPIE", valor_prueba)
                        Exit Select
                    Case "D-86-03"
                        pdfFormFields.SetField("TxtBxRecog10", valor_prueba)
                        Exit Select
                    Case "D-86-07"
                        pdfFormFields.SetField("TxtBxRecog50", valor_prueba)
                        Exit Select
                    Case "D-86-11"
                        pdfFormFields.SetField("TxtBxRecog90", valor_prueba)
                        Exit Select
                    Case "D-86-12"
                        pdfFormFields.SetField("TxtBxRecog95", valor_prueba)
                        Exit Select
                    Case "D-86-24"
                        pdfFormFields.SetField("TxtBxPFE", valor_prueba)
                        Exit Select
                    Case "D-86-25"
                        pdfFormFields.SetField("TxtBxResiduoDest", valor_prueba)
                        Exit Select
                    Case "D-86-26"
                        pdfFormFields.SetField("TxtBxPerdidaDest", valor_prueba)
                        Exit Select
                    Case "D-93"
                        pdfFormFields.SetField("FlashPoint", valor_prueba)
                        Exit Select
                    Case "D-4176"
                        pdfFormFields.SetField("Apariencia", valor_prueba)
                        Exit Select
                    Case "EN12937"
                        pdfFormFields.SetField("HumedadKF", valor_prueba)
                        Exit Select
                    Case "D-7321"
                        pdfFormFields.SetField("ContaminacionTotal", valor_prueba)
                        Exit Select
                    Case "EN14078"
                        pdfFormFields.SetField("DeterminacionBX", valor_prueba)
                        Exit Select
                    Case "D-4294-01"
                        pdfFormFields.SetField("Azufre%", valor_prueba)
                        Exit Select
                    Case "D-4294-02"
                        pdfFormFields.SetField("Azufremg", valor_prueba)
                        Exit Select
                    Case "D-97"
                        pdfFormFields.SetField("PuntoFluidez", valor_prueba)
                        Exit Select
                    Case "D-2500"
                        pdfFormFields.SetField("PuntoNube", valor_prueba)
                        Exit Select
                    Case Else
                        MsgBox("La prueba" & id_prueba & " no se encuentra en la plantilla PDF y por tanto no podra agregarse a esta.", MsgBoxStyle.Exclamation, "Error")
                        Exit Select
                End Select

            Next

            content.AddImage(img)

            pdfStamper.FormFlattening = True
            pdfStamper.Close()

            Try
                conn.Open()
                Dim cmd As New MySqlCommand(String.Format("UPDATE `bd_productos`.`productos` SET `Estado`='Aprobado', `ID_Muestra` = '" & TxtBxIDMuestra.Text & "',`Tanque`='" & TxtBxOrigen.Text & "', `Lote`='" & TxtBxLote.Text & "', `ATN`='" & TxtBxATN.Text & "', `TipodePrueba`='" & tipo_prueba & "', `Observaciones_Administrador` ='" & RchTxtBxObservaciones.Text & "' WHERE `ProductoID`='" & TxtBxIDProducto.Text & "';"), conn)
                cmd.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                conn.Close()
            End Try

            MsgBox("Reporte Generado en " & filepath, MsgBoxStyle.Information, "PDF Creado")

            If MessageBox.Show("¿Desea generar un correo con el archivo creado?", "Crear Correo", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                CrearMail(filepath)
            End If

            Try
                Process.Start(filepath)
            Catch ex As Exception
                MsgBox("No se encontro el archivo", MsgBoxStyle.Exclamation, "Error")
            End Try

            Form1.CargarDGVProductosRevisados()
            Me.Close()

        ElseIf TxtBxTipoProductoID.Text = "2" And CBPruebaMicro.Checked = True Then

            Dim pdfTemplate As String = ConfigurationManager.AppSettings("Micro")
            Dim GuardarPDF As New SaveFileDialog
            GuardarPDF.InitialDirectory = "C:\"
            GuardarPDF.RestoreDirectory = False
            GuardarPDF.DefaultExt = ".pdf"
            GuardarPDF.ShowDialog()
            Dim filepath As String
            Dim tipo_prueba As Integer

            Dim imgurl As String = ConfigurationManager.AppSettings("Image")

            Try
                filepath = Path.GetFullPath(GuardarPDF.FileName)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                Exit Sub
            End Try

            Dim pdfReader As New PdfReader(pdfTemplate)
            Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(
                    filepath, FileMode.Create))
            Dim imgstream As New FileStream(imgurl, FileMode.Open, FileAccess.Read)
            Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imgstream)
            Dim content As PdfContentByte = pdfStamper.GetOverContent(1)
            img.ScaleToFit(80, 100)
            img.SetAbsolutePosition(270, 232)



            Dim pdfFormFields As AcroFields = pdfStamper.AcroFields
            pdfFormFields.SetField("Producto", TxtBxProducto.Text.ToUpper)
            pdfFormFields.SetField("Cliente", TxtBxCliente.Text)
            pdfFormFields.SetField("DIRECCION", TxtBxDireccion.Text)
            pdfFormFields.SetField("ATN", TxtBxATN.Text)
            pdfFormFields.SetField("FECHA RECIBO", TxtBxFechaEntrada.Text)
            pdfFormFields.SetField("HORA", TxtBxHoraEntrada.Text)
            pdfFormFields.SetField("FECHA REPORTE", TxtBxFechaReporte.Text)
            pdfFormFields.SetField("PERIODO DE ANALISIS", TxtBxPeriodoAnalisis.Text.ToUpper)
            pdfFormFields.SetField("ID MUESTRA", TxtBxIDMuestra.Text)
            pdfFormFields.SetField("No LABORATORIO", TxtBxIDProducto.Text.Substring(5))
            pdfFormFields.SetField("No REPORTE", TxtBxIDProducto.Text)
            pdfFormFields.SetField("ORIGEN TANQUE", TxtBxOrigen.Text)
            pdfFormFields.SetField("Lote", TxtBxLote.Text)
            pdfFormFields.SetField("Observaciones", RchTxtBxObservaciones.Text)
            pdfFormFields.SetField("Nombre", Form1.LblUsuario.Text.Substring(14))

            Dim filas_total As Integer = DGV.RowCount - 2

            Dim id_prueba As String
            Dim valor_prueba As String

            For i As Integer = 0 To filas_total
                id_prueba = DGV(0, i).Value

                valor_prueba = DGV(6, i).Value.ToString.Trim
                If valor_prueba = "" Then
                    valor_prueba = DGV(5, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(4, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(3, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(2, i).Value.ToString.Trim
                End If

                Select Case id_prueba
                    Case "D-7978-01"
                        pdfFormFields.SetField("DeterminacionMicroorganismos L", valor_prueba)
                        Exit Select
                    Case "D-7978-02"
                        pdfFormFields.SetField("DeterminacionMicroorganismos mL", valor_prueba)
                        Exit Select
                    Case Else
                        MsgBox("La prueba" & id_prueba & " no se encuentra en la plantilla PDF", MsgBoxStyle.Exclamation, "Error")
                        Exit Select
                End Select

            Next

            content.AddImage(img)

            pdfStamper.FormFlattening = True
            pdfStamper.Close()

            Try
                conn.Open()
                Dim cmd As New MySqlCommand(String.Format("UPDATE `bd_productos`.`productos` SET `Estado`='Aprobado', `ID_Muestra` = '" & TxtBxIDMuestra.Text & "',`Tanque`='" & TxtBxOrigen.Text & "', `Lote`='" & TxtBxLote.Text & "', `ATN`='" & TxtBxATN.Text & "', `TipodePrueba`='" & tipo_prueba & "', `Observaciones_Administrador` ='" & RchTxtBxObservaciones.Text & "' WHERE `ProductoID`='" & TxtBxIDProducto.Text & "';"), conn)
                cmd.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                conn.Close()
            End Try

            MsgBox("Reporte Generado en " & filepath, MsgBoxStyle.Information, "PDF Creado")

            If MessageBox.Show("¿Desea generar un correo con el archivo creado?", "Crear Correo", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                CrearMail(filepath)
            End If

            Try
                Process.Start(filepath)
            Catch ex As Exception
                MsgBox("No se encontro el archivo", MsgBoxStyle.Exclamation, "Error")
            End Try


            Form1.CargarDGVProductosRevisados()
            Me.Close()

        ElseIf TxtBxTipoProductoID.Text = "4" And CBPruebaMicro.Checked = False Then
            Dim pdfTemplate As String = ConfigurationManager.AppSettings("Key7")
            Dim GuardarPDF As New SaveFileDialog
            GuardarPDF.InitialDirectory = "C:\"
            GuardarPDF.RestoreDirectory = False
            GuardarPDF.DefaultExt = ".pdf"
            GuardarPDF.ShowDialog()
            Dim filepath As String
            Dim tipo_prueba As Integer

            Dim imgurl As String = ConfigurationManager.AppSettings("Image")

            Try
                filepath = Path.GetFullPath(GuardarPDF.FileName)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                Exit Sub
            End Try

            Dim pdfReader As New PdfReader(pdfTemplate)
            Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(
                    filepath, FileMode.Create))
            Dim imgstream As New FileStream(imgurl, FileMode.Open, FileAccess.Read)
            Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imgstream)
            Dim content As PdfContentByte = pdfStamper.GetOverContent(1)
            img.ScaleToFit(80, 100)
            img.SetAbsolutePosition(263, 137)



            Dim pdfFormFields As AcroFields = pdfStamper.AcroFields
            pdfFormFields.SetField("Cliente", TxtBxCliente.Text)
            pdfFormFields.SetField("Direccion", TxtBxDireccion.Text)
            pdfFormFields.SetField("ATN", TxtBxATN.Text)
            pdfFormFields.SetField("FechaRecibo", TxtBxFechaEntrada.Text)
            pdfFormFields.SetField("HoraRecibo", TxtBxHoraEntrada.Text)
            pdfFormFields.SetField("FechaReporte", TxtBxFechaReporte.Text)
            pdfFormFields.SetField("PeriodoAnalisis", TxtBxPeriodoAnalisis.Text.ToUpper)
            pdfFormFields.SetField("IdMuestra", TxtBxIDMuestra.Text)
            pdfFormFields.SetField("NoLab", TxtBxIDProducto.Text.Substring(5))
            pdfFormFields.SetField("NoReporte", TxtBxIDProducto.Text)
            pdfFormFields.SetField("Origen/Tanque", TxtBxOrigen.Text)
            pdfFormFields.SetField("Cochada/Lote", TxtBxLote.Text)
            pdfFormFields.SetField("Observaciones", RchTxtBxObservaciones.Text)
            pdfFormFields.SetField("Aprobador", Form1.LblUsuario.Text.Substring(14))
            If RBCompleta.Checked = True Then
                pdfFormFields.SetField("CBBasico", "0")
                pdfFormFields.SetField("CBCompleto", "Yes")
                pdfFormFields.SetField("CBEspecifico", "0")
                tipo_prueba = 2
            ElseIf RBBasica.Checked = True Then
                pdfFormFields.SetField("CBBasico", "Yes")
                pdfFormFields.SetField("CBCompleto", "0")
                pdfFormFields.SetField("CBEspecifico", "0")
                tipo_prueba = 1
            ElseIf RBEspecifica.Checked = True Then
                pdfFormFields.SetField("CBBasico", "0")
                pdfFormFields.SetField("CBCompleto", "0")
                pdfFormFields.SetField("CBEspecifico", "Yes")
                tipo_prueba = 3
            End If

            Dim filas_total As Integer = DGV.RowCount - 2

            Dim id_prueba As String
            Dim valor_prueba As String

            For i As Integer = 0 To filas_total
                id_prueba = DGV(0, i).Value

                valor_prueba = DGV(6, i).Value.ToString.Trim
                If valor_prueba = "" Then
                    valor_prueba = DGV(5, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(4, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(3, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(2, i).Value.ToString.Trim
                End If

                Select Case id_prueba
                    Case "D-3242"
                        pdfFormFields.SetField("TxtBxAcidezTotal", valor_prueba)
                        Exit Select
                    Case "D-1319-01"
                        pdfFormFields.SetField("TxtBxAromaticos", valor_prueba)
                        Exit Select
                    Case "D-4294-01"
                        pdfFormFields.SetField("TxtBxAzufre", valor_prueba)
                        Exit Select
                    Case "D-4952"
                        pdfFormFields.SetField("TxtBxPruebaDoctor", valor_prueba)
                        Exit Select
                    Case "D-1840"
                        pdfFormFields.SetField("TxtBxNaftalenos", valor_prueba)
                        Exit Select
                    Case "D-1298"
                        pdfFormFields.SetField("TxtBxGravedad", valor_prueba)
                        Exit Select
                    Case "D-1250"
                        pdfFormFields.SetField("TxtBxDensidad", valor_prueba)
                        Exit Select
                    Case "D-86-01"
                        pdfFormFields.SetField("TxbBxPIE", valor_prueba)
                        Exit Select
                    Case "D-86-03"
                        pdfFormFields.SetField("TxtBxTemp10", valor_prueba)
                        Exit Select
                    Case "D-86-07"
                        pdfFormFields.SetField("TxtBxTemp50", valor_prueba)
                        Exit Select
                    Case "D-86-11"
                        pdfFormFields.SetField("TxtBxTemp90", valor_prueba)
                        Exit Select
                    Case "D-86-24"
                        pdfFormFields.SetField("TxtBxPFE", valor_prueba)
                        Exit Select
                    Case "D-86-25"
                        pdfFormFields.SetField("TxtBxResiduoDestilacion", valor_prueba)
                        Exit Select
                    Case "D-86-26"
                        pdfFormFields.SetField("TxtBxPerdidaDestilacion", valor_prueba)
                        Exit Select
                    Case "D-56"
                        pdfFormFields.SetField("TxtBxPuntoChispa", valor_prueba)
                        Exit Select
                    Case "D-2386"
                        pdfFormFields.SetField("TxtBxPCongelacion", valor_prueba)
                        Exit Select
                    Case "D-445"
                        pdfFormFields.SetField("TxtBxViscosidad", valor_prueba)
                        Exit Select
                    Case "D-3338"
                        pdfFormFields.SetField("TxtBxCalorNeto", valor_prueba)
                        Exit Select
                    Case "D-1322"
                        pdfFormFields.SetField("TxtBxPuntoHumo", valor_prueba)
                        Exit Select
                    Case "D-130-01"
                        pdfFormFields.SetField("TxtBxCorrosion100", valor_prueba)
                        Exit Select
                    Case "D-3241-01"
                        pdfFormFields.SetField("TxtBxCaidaPresion", valor_prueba)
                        Exit Select
                    Case "D-3241-02"
                        pdfFormFields.SetField("TxtBxCodigoColor", valor_prueba)
                        Exit Select
                    Case "D-4176"
                        pdfFormFields.SetField("TxtBxApariencia", valor_prueba)
                        Exit Select
                    Case "D-381"
                        pdfFormFields.SetField("TxtBxGoma", valor_prueba)
                        Exit Select
                    Case "D-1094-02"
                        pdfFormFields.SetField("TxtBxClasifInterfase", valor_prueba)
                        Exit Select
                    Case "D-1094-03"
                        pdfFormFields.SetField("TxtBxClasifSeparacion", valor_prueba)
                        Exit Select
                    Case "D-1094-01"
                        pdfFormFields.SetField("TxtBxCambioVolumen", valor_prueba)
                        Exit Select
                    Case "D-3948"
                        pdfFormFields.SetField("TxtBxMSEP-A", valor_prueba)
                        Exit Select
                    Case Else
                        MsgBox("La prueba" & id_prueba & " no se encuentra en la plantilla PDF", MsgBoxStyle.Exclamation, "Error")
                        Exit Select
                End Select

            Next

            content.AddImage(img)

            pdfStamper.FormFlattening = True
            pdfStamper.Close()

            Try
                conn.Open()
                Dim cmd As New MySqlCommand(String.Format("UPDATE `bd_productos`.`productos` SET `Estado`='Aprobado', `ID_Muestra` = '" & TxtBxIDMuestra.Text & "',`Tanque`='" & TxtBxOrigen.Text & "', `Lote`='" & TxtBxLote.Text & "', `ATN`='" & TxtBxATN.Text & "', `TipodePrueba`='" & tipo_prueba & "', `Observaciones_Administrador` ='" & RchTxtBxObservaciones.Text & "' WHERE `ProductoID`='" & TxtBxIDProducto.Text & "';"), conn)
                cmd.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                conn.Close()
            End Try

            MsgBox("Reporte Generado en " & filepath, MsgBoxStyle.Information, "PDF Creado")

            If MessageBox.Show("¿Desea generar un correo con el archivo creado?", "Crear Correo", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                CrearMail(filepath)
            End If

            Try
                Process.Start(filepath)
            Catch ex As Exception
                MsgBox("No se encontro el archivo", MsgBoxStyle.Exclamation, "Error")
            End Try


            Form1.CargarDGVProductosRevisados()
            Me.Close()

        ElseIf TxtBxTipoProductoID.Text = "5" And CBPruebaMicro.Checked = True Then

            Dim pdfTemplate As String = ConfigurationManager.AppSettings("Micro")
            Dim GuardarPDF As New SaveFileDialog
            GuardarPDF.InitialDirectory = "C:\"
            GuardarPDF.RestoreDirectory = False
            GuardarPDF.DefaultExt = ".pdf"
            GuardarPDF.ShowDialog()
            Dim filepath As String
            Dim tipo_prueba As Integer

            Dim imgurl As String = ConfigurationManager.AppSettings("Image")

            Try
                filepath = Path.GetFullPath(GuardarPDF.FileName)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                Exit Sub
            End Try

            Dim pdfReader As New PdfReader(pdfTemplate)
            Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(
                    filepath, FileMode.Create))
            Dim imgstream As New FileStream(imgurl, FileMode.Open, FileAccess.Read)
            Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imgstream)
            Dim content As PdfContentByte = pdfStamper.GetOverContent(1)
            img.ScaleToFit(80, 100)
            img.SetAbsolutePosition(263, 137)



            Dim pdfFormFields As AcroFields = pdfStamper.AcroFields
            pdfFormFields.SetField("Producto", TxtBxProducto.Text.ToUpper)
            pdfFormFields.SetField("Cliente", TxtBxCliente.Text)
            pdfFormFields.SetField("DIRECCION", TxtBxDireccion.Text)
            pdfFormFields.SetField("ATN", TxtBxATN.Text)
            pdfFormFields.SetField("FECHA RECIBO", TxtBxFechaEntrada.Text)
            pdfFormFields.SetField("HORA", TxtBxHoraEntrada.Text)
            pdfFormFields.SetField("FECHA REPORTE", TxtBxFechaReporte.Text)
            pdfFormFields.SetField("PERIODO DE ANALISIS", TxtBxPeriodoAnalisis.Text.ToUpper)
            pdfFormFields.SetField("ID MUESTRA", TxtBxIDMuestra.Text)
            pdfFormFields.SetField("No LABORATORIO", TxtBxIDProducto.Text.Substring(5))
            pdfFormFields.SetField("No REPORTE", TxtBxIDProducto.Text)
            pdfFormFields.SetField("ORIGEN TANQUE", TxtBxOrigen.Text)
            pdfFormFields.SetField("Lote", TxtBxLote.Text)
            pdfFormFields.SetField("Observaciones", RchTxtBxObservaciones.Text)
            pdfFormFields.SetField("Nombre", Form1.LblUsuario.Text.Substring(14))

            Dim filas_total As Integer = DGV.RowCount - 2

            Dim id_prueba As String
            Dim valor_prueba As String

            For i As Integer = 0 To filas_total
                id_prueba = DGV(0, i).Value

                valor_prueba = DGV(6, i).Value.ToString.Trim
                If valor_prueba = "" Then
                    valor_prueba = DGV(5, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(4, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(3, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(2, i).Value.ToString.Trim
                End If

                Select Case id_prueba
                    Case "D-7978-01"
                        pdfFormFields.SetField("DeterminacionMicroorganismos L", valor_prueba)
                        Exit Select
                    Case "D-7978-02"
                        pdfFormFields.SetField("DeterminacionMicroorganismos mL", valor_prueba)
                        Exit Select
                    Case Else
                        MsgBox("La prueba" & id_prueba & " no se encuentra en la plantilla PDF", MsgBoxStyle.Exclamation, "Error")
                        Exit Select
                End Select

            Next

            content.AddImage(img)

            pdfStamper.FormFlattening = True
            pdfStamper.Close()

            Try
                conn.Open()
                Dim cmd As New MySqlCommand(String.Format("UPDATE `bd_productos`.`productos` SET `Estado`='Aprobado', `ID_Muestra` = '" & TxtBxIDMuestra.Text & "',`Tanque`='" & TxtBxOrigen.Text & "', `Lote`='" & TxtBxLote.Text & "', `ATN`='" & TxtBxATN.Text & "', `TipodePrueba`='" & tipo_prueba & "', `Observaciones_Administrador` ='" & RchTxtBxObservaciones.Text & "' WHERE `ProductoID`='" & TxtBxIDProducto.Text & "';"), conn)
                cmd.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                conn.Close()
            End Try

            MsgBox("Reporte Generado en " & filepath, MsgBoxStyle.Information, "PDF Creado")

            If MessageBox.Show("¿Desea generar un correo con el archivo creado?", "Crear Correo", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                CrearMail(filepath)
            End If

            Try
                Process.Start(filepath)
            Catch ex As Exception
                MsgBox("No se encontro el archivo", MsgBoxStyle.Exclamation, "Error")
            End Try


            Form1.CargarDGVProductosRevisados()
            Me.Close()

        ElseIf TxtBxTipoProductoID.Text = "4" And CBPruebaMicro.Checked = True Then

            Dim pdfTemplate As String = ConfigurationManager.AppSettings("Micro")
            Dim GuardarPDF As New SaveFileDialog
            GuardarPDF.InitialDirectory = "C:\"
            GuardarPDF.RestoreDirectory = False
            GuardarPDF.DefaultExt = ".pdf"
            GuardarPDF.ShowDialog()
            Dim filepath As String
            Dim tipo_prueba As Integer

            Dim imgurl As String = ConfigurationManager.AppSettings("Image")

            Try
                filepath = Path.GetFullPath(GuardarPDF.FileName)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                Exit Sub
            End Try

            Dim pdfReader As New PdfReader(pdfTemplate)
            Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(
                    filepath, FileMode.Create))
            Dim imgstream As New FileStream(imgurl, FileMode.Open, FileAccess.Read)
            Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imgstream)
            Dim content As PdfContentByte = pdfStamper.GetOverContent(1)
            img.ScaleToFit(80, 100)
            img.SetAbsolutePosition(270, 232)



            Dim pdfFormFields As AcroFields = pdfStamper.AcroFields
            pdfFormFields.SetField("Producto", TxtBxProducto.Text.ToUpper)
            pdfFormFields.SetField("Cliente", TxtBxCliente.Text)
            pdfFormFields.SetField("DIRECCION", TxtBxDireccion.Text)
            pdfFormFields.SetField("ATN", TxtBxATN.Text)
            pdfFormFields.SetField("FECHA RECIBO", TxtBxFechaEntrada.Text)
            pdfFormFields.SetField("HORA", TxtBxHoraEntrada.Text)
            pdfFormFields.SetField("FECHA REPORTE", TxtBxFechaReporte.Text)
            pdfFormFields.SetField("PERIODO DE ANALISIS", TxtBxPeriodoAnalisis.Text.ToUpper)
            pdfFormFields.SetField("ID MUESTRA", TxtBxIDMuestra.Text)
            pdfFormFields.SetField("No LABORATORIO", TxtBxIDProducto.Text.Substring(5))
            pdfFormFields.SetField("No REPORTE", TxtBxIDProducto.Text)
            pdfFormFields.SetField("ORIGEN TANQUE", TxtBxOrigen.Text)
            pdfFormFields.SetField("Lote", TxtBxLote.Text)
            pdfFormFields.SetField("Observaciones", RchTxtBxObservaciones.Text)
            pdfFormFields.SetField("Nombre", Form1.LblUsuario.Text.Substring(14))

            Dim filas_total As Integer = DGV.RowCount - 2

            Dim id_prueba As String
            Dim valor_prueba As String

            For i As Integer = 0 To filas_total
                id_prueba = DGV(0, i).Value

                valor_prueba = DGV(6, i).Value.ToString.Trim
                If valor_prueba = "" Then
                    valor_prueba = DGV(5, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(4, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(3, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(2, i).Value.ToString.Trim
                End If

                Select Case id_prueba
                    Case "D-7978-01"
                        pdfFormFields.SetField("DeterminacionMicroorganismos L", valor_prueba)
                        Exit Select
                    Case "D-7978-02"
                        pdfFormFields.SetField("DeterminacionMicroorganismos mL", valor_prueba)
                        Exit Select
                    Case Else
                        MsgBox("La prueba" & id_prueba & " no se encuentra en la plantilla PDF", MsgBoxStyle.Exclamation, "Error")
                        Exit Select
                End Select

            Next

            content.AddImage(img)

            pdfStamper.FormFlattening = True
            pdfStamper.Close()

            Try
                conn.Open()
                Dim cmd As New MySqlCommand(String.Format("UPDATE `bd_productos`.`productos` SET `Estado`='Aprobado', `ID_Muestra` = '" & TxtBxIDMuestra.Text & "',`Tanque`='" & TxtBxOrigen.Text & "', `Lote`='" & TxtBxLote.Text & "', `ATN`='" & TxtBxATN.Text & "', `TipodePrueba`='" & tipo_prueba & "', `Observaciones_Administrador` ='" & RchTxtBxObservaciones.Text & "' WHERE `ProductoID`='" & TxtBxIDProducto.Text & "';"), conn)
                cmd.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                conn.Close()
            End Try

            MsgBox("Reporte Generado en " & filepath, MsgBoxStyle.Information, "PDF Creado")

            If MessageBox.Show("¿Desea generar un correo con el archivo creado?", "Crear Correo", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                CrearMail(filepath)
            End If

            Try
                Process.Start(filepath)
            Catch ex As Exception
                MsgBox("No se encontro el archivo", MsgBoxStyle.Exclamation, "Error")
            End Try


            Form1.CargarDGVProductosRevisados()
            Me.Close()

        ElseIf TxtBxTipoProductoID.Text = "7" Then

            Dim pdfTemplate As String = ConfigurationManager.AppSettings("Key10")
            Dim GuardarPDF As New SaveFileDialog
            GuardarPDF.InitialDirectory = "C:\"
            GuardarPDF.RestoreDirectory = False
            GuardarPDF.DefaultExt = ".pdf"
            GuardarPDF.ShowDialog()
            Dim filepath As String
            Dim tipo_prueba As Integer

            Dim imgurl As String = ConfigurationManager.AppSettings("Image")

            Try
                filepath = Path.GetFullPath(GuardarPDF.FileName)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                Exit Sub
            End Try

            Dim pdfReader As New PdfReader(pdfTemplate)
            Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(
                    filepath, FileMode.Create))
            Dim imgstream As New FileStream(imgurl, FileMode.Open, FileAccess.Read)
            Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imgstream)
            Dim content As PdfContentByte = pdfStamper.GetOverContent(1)
            img.ScaleToFit(80, 100)
            img.SetAbsolutePosition(235, 210)



            Dim pdfFormFields As AcroFields = pdfStamper.AcroFields
            pdfFormFields.SetField("Cliente", TxtBxCliente.Text)
            pdfFormFields.SetField("DIRECCION", TxtBxDireccion.Text)
            pdfFormFields.SetField("ATN", TxtBxATN.Text)
            pdfFormFields.SetField("FECHA RECIBO", TxtBxFechaEntrada.Text)
            pdfFormFields.SetField("HORA", TxtBxHoraEntrada.Text)
            pdfFormFields.SetField("FECHA REPORTE", TxtBxFechaReporte.Text)
            pdfFormFields.SetField("PERIODO DE ANALISIS", TxtBxPeriodoAnalisis.Text.ToUpper)
            pdfFormFields.SetField("ID MUESTRA", TxtBxIDMuestra.Text)
            pdfFormFields.SetField("No LABORATORIO", TxtBxIDProducto.Text.Substring(5))
            pdfFormFields.SetField("No REPORTE", TxtBxIDProducto.Text)
            pdfFormFields.SetField("ORIGEN TANQUE", TxtBxOrigen.Text)
            pdfFormFields.SetField("Lote", TxtBxLote.Text)
            pdfFormFields.SetField("Observaciones", RchTxtBxObservaciones.Text)
            pdfFormFields.SetField("NOMBRE", Form1.LblUsuario.Text.Substring(14))
            If RBCompleta.Checked = True Then
                pdfFormFields.SetField("CBBasico", "0")
                pdfFormFields.SetField("CBCompleto", "Yes")
                pdfFormFields.SetField("CBEspecifico", "0")
                tipo_prueba = 2
            ElseIf RBBasica.Checked = True Then
                pdfFormFields.SetField("CBBasico", "Yes")
                pdfFormFields.SetField("CBCompleto", "0")
                pdfFormFields.SetField("CBEspecifico", "0")
                tipo_prueba = 1
            ElseIf RBEspecifica.Checked = True Then
                pdfFormFields.SetField("CBBasico", "0")
                pdfFormFields.SetField("CBCompleto", "0")
                pdfFormFields.SetField("CBEspecifico", "Yes")
                tipo_prueba = 3
            End If

            Dim filas_total As Integer = DGV.RowCount - 2

            Dim id_prueba As String
            Dim valor_prueba As String

            For i As Integer = 0 To filas_total
                id_prueba = DGV(0, i).Value

                valor_prueba = DGV(6, i).Value.ToString.Trim
                If valor_prueba = "" Then
                    valor_prueba = DGV(5, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(4, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(3, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(2, i).Value.ToString.Trim
                End If

                Select Case id_prueba
                    Case "D-86-01"
                        pdfFormFields.SetField("TxtBxPIE", valor_prueba)
                        Exit Select
                    Case "D-86-14"
                        pdfFormFields.SetField("TxtBxTemp10", valor_prueba)
                        Exit Select
                    Case "D-86-18"
                        pdfFormFields.SetField("TxtBxTemp50", valor_prueba)
                        Exit Select
                    Case "D-86-22"
                        pdfFormFields.SetField("TxtBxTemp90", valor_prueba)
                        Exit Select
                    Case "D-86-24"
                        pdfFormFields.SetField("TxtBxPFE", valor_prueba)
                        Exit Select
                    Case "D-86-28"
                        pdfFormFields.SetField("TxtBxResiduoVolumen", valor_prueba)
                        Exit Select
                    Case "D-4953"
                        pdfFormFields.SetField("PVREID", valor_prueba)
                        Exit Select
                    Case "D-130-02"
                        pdfFormFields.SetField("CorrosionLamina50", valor_prueba)
                        Exit Select
                    Case "D-381"
                        pdfFormFields.SetField("GomaExistente", valor_prueba)
                        Exit Select
                    Case "D-525"
                        pdfFormFields.SetField("EstabilidadOxidacion", valor_prueba)
                        Exit Select
                    Case "D-1319-01"
                        pdfFormFields.SetField("Aromaticos", valor_prueba)
                        Exit Select
                    Case "D-1319-02"
                        pdfFormFields.SetField("Olefinas", valor_prueba)
                        Exit Select
                    Case "D-1319-03"
                        pdfFormFields.SetField("Insaturados", valor_prueba)
                        Exit Select
                    Case Else
                        MsgBox("La prueba" & id_prueba & " no se encuentra en la plantilla PDF y por tanto no podra agregarse a esta.", MsgBoxStyle.Exclamation, "Error")
                        Exit Select
                End Select

            Next

            content.AddImage(img)

            pdfStamper.FormFlattening = True
            pdfStamper.Close()

            Try
                conn.Open()
                Dim cmd As New MySqlCommand(String.Format("UPDATE `bd_productos`.`productos` SET `Estado`='Aprobado', `ID_Muestra` = '" & TxtBxIDMuestra.Text & "',`Tanque`='" & TxtBxOrigen.Text & "', `Lote`='" & TxtBxLote.Text & "', `ATN`='" & TxtBxATN.Text & "', `TipodePrueba`='" & tipo_prueba & "', `Observaciones_Administrador` ='" & RchTxtBxObservaciones.Text & "' WHERE `ProductoID`='" & TxtBxIDProducto.Text & "';"), conn)
                cmd.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                conn.Close()
            End Try

            MsgBox("Reporte Generado en " & filepath, MsgBoxStyle.Information, "PDF Creado")

            If MessageBox.Show("¿Desea generar un correo con el archivo creado?", "Crear Correo", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                CrearMail(filepath)
            End If

            Try
                Process.Start(filepath)
            Catch ex As Exception
                MsgBox("No se encontro el archivo", MsgBoxStyle.Exclamation, "Error")
            End Try


            Form1.CargarDGVProductosRevisados()
            Me.Close()

        ElseIf TxtBxTipoProductoID.Text = "8" Then

            Dim pdfTemplate As String = ConfigurationManager.AppSettings("Key11")
            Dim GuardarPDF As New SaveFileDialog
            GuardarPDF.InitialDirectory = "C:\"
            GuardarPDF.RestoreDirectory = False
            GuardarPDF.DefaultExt = ".pdf"
            GuardarPDF.ShowDialog()
            Dim filepath As String
            Dim tipo_prueba As Integer

            Dim imgurl As String = ConfigurationManager.AppSettings("Image")

            Try
                filepath = Path.GetFullPath(GuardarPDF.FileName)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                Exit Sub
            End Try

            Dim pdfReader As New PdfReader(pdfTemplate)
            Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(
                    filepath, FileMode.Create))
            Dim imgstream As New FileStream(imgurl, FileMode.Open, FileAccess.Read)
            Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imgstream)
            Dim content As PdfContentByte = pdfStamper.GetOverContent(1)
            img.ScaleToFit(80, 100)
            img.SetAbsolutePosition(400, 490)



            Dim pdfFormFields As AcroFields = pdfStamper.AcroFields
            pdfFormFields.SetField("Cliente", TxtBxCliente.Text)
            pdfFormFields.SetField("DIRECCION", TxtBxDireccion.Text)
            pdfFormFields.SetField("ATN", TxtBxATN.Text)
            pdfFormFields.SetField("FECHA RECIBO", TxtBxFechaEntrada.Text)
            pdfFormFields.SetField("HORA", TxtBxHoraEntrada.Text)
            pdfFormFields.SetField("FECHA REPORTE", TxtBxFechaReporte.Text)
            pdfFormFields.SetField("PERIODO DE ANALISIS", TxtBxPeriodoAnalisis.Text.ToUpper)
            pdfFormFields.SetField("ID MUESTRA", TxtBxIDMuestra.Text)
            pdfFormFields.SetField("No LABORATORIO", TxtBxIDProducto.Text.Substring(5))
            pdfFormFields.SetField("No REPORTE", TxtBxIDProducto.Text)
            pdfFormFields.SetField("ORIGEN TANQUE", TxtBxOrigen.Text)
            pdfFormFields.SetField("Lote", TxtBxLote.Text)
            pdfFormFields.SetField("Observaciones", RchTxtBxObservaciones.Text)
            pdfFormFields.SetField("NOMBRE", Form1.LblUsuario.Text.Substring(14))
            If RBCompleta.Checked = True Then
                pdfFormFields.SetField("CBBasico", "0")
                pdfFormFields.SetField("CBCompleto", "Yes")
                pdfFormFields.SetField("CBEspecifico", "0")
                tipo_prueba = 2
            ElseIf RBBasica.Checked = True Then
                pdfFormFields.SetField("CBBasico", "Yes")
                pdfFormFields.SetField("CBCompleto", "0")
                pdfFormFields.SetField("CBEspecifico", "0")
                tipo_prueba = 1
            ElseIf RBEspecifica.Checked = True Then
                pdfFormFields.SetField("CBBasico", "0")
                pdfFormFields.SetField("CBCompleto", "0")
                pdfFormFields.SetField("CBEspecifico", "Yes")
                tipo_prueba = 3
            End If

            Dim filas_total As Integer = DGV.RowCount - 2

            Dim id_prueba As String
            Dim valor_prueba As String

            For i As Integer = 0 To filas_total
                id_prueba = DGV(0, i).Value

                valor_prueba = DGV(6, i).Value.ToString.Trim
                If valor_prueba = "" Then
                    valor_prueba = DGV(5, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(4, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(3, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(2, i).Value.ToString.Trim
                End If

                Select Case id_prueba
                    Case "D-86-01"
                        pdfFormFields.SetField("TxtBxPIE", valor_prueba)
                        Exit Select
                    Case "D-86-14"
                        pdfFormFields.SetField("TxtBxTemp10", valor_prueba)
                        Exit Select
                    Case "D-86-18"
                        pdfFormFields.SetField("TxtBxTemp50", valor_prueba)
                        Exit Select
                    Case "D-86-22"
                        pdfFormFields.SetField("TxtBxTemp90", valor_prueba)
                        Exit Select
                    Case "D-86-24"
                        pdfFormFields.SetField("TxtBxPFE", valor_prueba)
                        Exit Select
                    Case "D-86-28"
                        pdfFormFields.SetField("TxtBxResiduoVolumen", valor_prueba)
                        Exit Select
                    Case "D-4953"
                        pdfFormFields.SetField("PVREID", valor_prueba)
                        Exit Select
                    Case "MMIN"
                        pdfFormFields.SetField("ICV", valor_prueba)
                        Exit Select
                    Case "D-4815"
                        pdfFormFields.SetField("Oxigenados%V", valor_prueba)
                        Exit Select
                    Case "D-130-02"
                        pdfFormFields.SetField("CorrosionLamina50", valor_prueba)
                        Exit Select
                    Case "D-381"
                        pdfFormFields.SetField("GomaExistente", valor_prueba)
                        Exit Select
                    Case "D-525"
                        pdfFormFields.SetField("EstabilidadOxidacion", valor_prueba)
                        Exit Select
                    Case Else
                        MsgBox("La prueba" & id_prueba & " no se encuentra en la plantilla PDF y por tanto no podra agregarse a esta.", MsgBoxStyle.Exclamation, "Error")
                        Exit Select
                End Select

            Next

            content.AddImage(img)

            pdfStamper.FormFlattening = True
            pdfStamper.Close()

            Try
                conn.Open()
                Dim cmd As New MySqlCommand(String.Format("UPDATE `bd_productos`.`productos` SET `Estado`='Aprobado', `ID_Muestra` = '" & TxtBxIDMuestra.Text & "',`Tanque`='" & TxtBxOrigen.Text & "', `Lote`='" & TxtBxLote.Text & "', `ATN`='" & TxtBxATN.Text & "', `TipodePrueba`='" & tipo_prueba & "', `Observaciones_Administrador` ='" & RchTxtBxObservaciones.Text & "' WHERE `ProductoID`='" & TxtBxIDProducto.Text & "';"), conn)
                cmd.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                conn.Close()
            End Try

            MsgBox("Reporte Generado en " & filepath, MsgBoxStyle.Information, "PDF Creado")

            If MessageBox.Show("¿Desea generar un correo con el archivo creado?", "Crear Correo", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                CrearMail(filepath)
            End If

            Try
                Process.Start(filepath)
            Catch ex As Exception
                MsgBox("No se encontro el archivo", MsgBoxStyle.Exclamation, "Error")
            End Try


            Form1.CargarDGVProductosRevisados()
            Me.Close()

        ElseIf TxtBxTipoProductoID.Text = "9" Then

            Dim pdfTemplate As String = ConfigurationManager.AppSettings("Key12")
            Dim GuardarPDF As New SaveFileDialog
            GuardarPDF.InitialDirectory = "C:\"
            GuardarPDF.RestoreDirectory = False
            GuardarPDF.DefaultExt = ".pdf"
            GuardarPDF.ShowDialog()
            Dim filepath As String
            Dim tipo_prueba As Integer

            Dim imgurl As String = ConfigurationManager.AppSettings("Image")

            Try
                filepath = Path.GetFullPath(GuardarPDF.FileName)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                Exit Sub
            End Try

            Dim pdfReader As New PdfReader(pdfTemplate)
            Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(
                        filepath, FileMode.Create))
            Dim imgstream As New FileStream(imgurl, FileMode.Open, FileAccess.Read)
            Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imgstream)
            Dim content As PdfContentByte = pdfStamper.GetOverContent(1)
            img.ScaleToFit(80, 100)
            img.SetAbsolutePosition(400, 490)



            Dim pdfFormFields As AcroFields = pdfStamper.AcroFields
            pdfFormFields.SetField("Cliente", TxtBxCliente.Text)
            pdfFormFields.SetField("DIRECCION", TxtBxDireccion.Text)
            pdfFormFields.SetField("ATN", TxtBxATN.Text)
            pdfFormFields.SetField("FECHA RECIBO", TxtBxFechaEntrada.Text)
            pdfFormFields.SetField("HORA", TxtBxHoraEntrada.Text)
            pdfFormFields.SetField("FECHA REPORTE", TxtBxFechaReporte.Text)
            pdfFormFields.SetField("PERIODO DE ANALISIS", TxtBxPeriodoAnalisis.Text.ToUpper)
            pdfFormFields.SetField("ID MUESTRA", TxtBxIDMuestra.Text)
            pdfFormFields.SetField("No LABORATORIO", TxtBxIDProducto.Text.Substring(5))
            pdfFormFields.SetField("No REPORTE", TxtBxIDProducto.Text)
            pdfFormFields.SetField("ORIGEN TANQUE", TxtBxOrigen.Text)
            pdfFormFields.SetField("Lote", TxtBxLote.Text)
            pdfFormFields.SetField("Observaciones", RchTxtBxObservaciones.Text)
            pdfFormFields.SetField("NOMBRE", Form1.LblUsuario.Text.Substring(14))
            If RBCompleta.Checked = True Then
                pdfFormFields.SetField("CBBasico", "0")
                pdfFormFields.SetField("CBCompleto", "Yes")
                pdfFormFields.SetField("CBEspecifico", "0")
                tipo_prueba = 2
            ElseIf RBBasica.Checked = True Then
                pdfFormFields.SetField("CBBasico", "Yes")
                pdfFormFields.SetField("CBCompleto", "0")
                pdfFormFields.SetField("CBEspecifico", "0")
                tipo_prueba = 1
            ElseIf RBEspecifica.Checked = True Then
                pdfFormFields.SetField("CBBasico", "0")
                pdfFormFields.SetField("CBCompleto", "0")
                pdfFormFields.SetField("CBEspecifico", "Yes")
                tipo_prueba = 3
            End If

            Dim filas_total As Integer = DGV.RowCount - 2

            Dim id_prueba As String
            Dim valor_prueba As String

            For i As Integer = 0 To filas_total
                id_prueba = DGV(0, i).Value

                valor_prueba = DGV(6, i).Value.ToString.Trim
                If valor_prueba = "" Then
                    valor_prueba = DGV(5, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(4, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(3, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(2, i).Value.ToString.Trim
                End If

                Select Case id_prueba
                    Case "D-86-01"
                        pdfFormFields.SetField("TxtBxPIE", valor_prueba)
                        Exit Select
                    Case "D-86-14"
                        pdfFormFields.SetField("TxtBxTemp10", valor_prueba)
                        Exit Select
                    Case "D-86-18"
                        pdfFormFields.SetField("TxtBxTemp50", valor_prueba)
                        Exit Select
                    Case "D-86-22"
                        pdfFormFields.SetField("TxtBxTemp90", valor_prueba)
                        Exit Select
                    Case "D-86-24"
                        pdfFormFields.SetField("TxtBxPFE", valor_prueba)
                        Exit Select
                    Case "D-86-28"
                        pdfFormFields.SetField("TxtBxResiduoVolumen", valor_prueba)
                        Exit Select
                    Case "D-4953"
                        pdfFormFields.SetField("PVREID", valor_prueba)
                        Exit Select
                    Case "MMIN"
                        pdfFormFields.SetField("ICV", valor_prueba)
                        Exit Select
                    Case "D-4815"
                        pdfFormFields.SetField("Oxigenados%V", valor_prueba)
                        Exit Select
                    Case "D-130-02"
                        pdfFormFields.SetField("CorrosionLamina50", valor_prueba)
                        Exit Select
                    Case "D-381"
                        pdfFormFields.SetField("GomaExistente", valor_prueba)
                        Exit Select
                    Case "D-525"
                        pdfFormFields.SetField("EstabilidadOxidacion", valor_prueba)
                        Exit Select
                    Case Else
                        MsgBox("La prueba" & id_prueba & " no se encuentra en la plantilla PDF", MsgBoxStyle.Exclamation, "Error")
                        Exit Select
                End Select

            Next

            content.AddImage(img)

            pdfStamper.FormFlattening = True
            pdfStamper.Close()

            Try
                conn.Open()
                Dim cmd As New MySqlCommand(String.Format("UPDATE `bd_productos`.`productos` SET `Estado`='Aprobado', `ID_Muestra` = '" & TxtBxIDMuestra.Text & "',`Tanque`='" & TxtBxOrigen.Text & "', `Lote`='" & TxtBxLote.Text & "', `ATN`='" & TxtBxATN.Text & "', `TipodePrueba`='" & tipo_prueba & "', `Observaciones_Administrador` ='" & RchTxtBxObservaciones.Text & "' WHERE `ProductoID`='" & TxtBxIDProducto.Text & "';"), conn)
                cmd.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                conn.Close()
            End Try

            MsgBox("Reporte Generado en " & filepath, MsgBoxStyle.Information, "PDF Creado")

            If MessageBox.Show("¿Desea generar un correo con el archivo creado?", "Crear Correo", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                CrearMail(filepath)
            End If

            Try
                Process.Start(filepath)
            Catch ex As Exception
                MsgBox("No se encontro el archivo", MsgBoxStyle.Exclamation, "Error")
            End Try


            Form1.CargarDGVProductosRevisados()
            Me.Close()

        ElseIf TxtBxTipoProductoID.Text = "6" Then

            Dim pdfTemplate As String = ConfigurationManager.AppSettings("Key6")
            Dim GuardarPDF As New SaveFileDialog
            GuardarPDF.InitialDirectory = "C:\"
            GuardarPDF.RestoreDirectory = False
            GuardarPDF.DefaultExt = ".pdf"
            GuardarPDF.ShowDialog()
            Dim filepath As String
            Dim tipo_prueba As Integer

            Dim imgurl As String = ConfigurationManager.AppSettings("Image")

            Try
                filepath = Path.GetFullPath(GuardarPDF.FileName)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                Exit Sub
            End Try

            Dim pdfReader As New PdfReader(pdfTemplate)
            Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(
                        filepath, FileMode.Create))
            Dim imgstream As New FileStream(imgurl, FileMode.Open, FileAccess.Read)
            Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imgstream)
            Dim content As PdfContentByte = pdfStamper.GetOverContent(1)
            img.ScaleToFit(80, 100)
            img.SetAbsolutePosition(260, 215)



            Dim pdfFormFields As AcroFields = pdfStamper.AcroFields
            pdfFormFields.SetField("Cliente", TxtBxCliente.Text)
            pdfFormFields.SetField("DIRECCION", TxtBxDireccion.Text)
            pdfFormFields.SetField("ATN", TxtBxATN.Text)
            pdfFormFields.SetField("FECHA RECIBO", TxtBxFechaEntrada.Text)
            pdfFormFields.SetField("HORA", TxtBxHoraEntrada.Text)
            pdfFormFields.SetField("FECHA REPORTE", TxtBxFechaReporte.Text)
            pdfFormFields.SetField("PERIODO DE ANALISIS", TxtBxPeriodoAnalisis.Text.ToUpper)
            pdfFormFields.SetField("ID MUESTRA", TxtBxIDMuestra.Text)
            pdfFormFields.SetField("No LABORATORIO", TxtBxIDProducto.Text.Substring(5))
            pdfFormFields.SetField("No REPORTE", TxtBxIDProducto.Text)
            pdfFormFields.SetField("ORIGEN TANQUE", TxtBxOrigen.Text)
            pdfFormFields.SetField("Lote", TxtBxLote.Text)
            pdfFormFields.SetField("Observaciones", RchTxtBxObservaciones.Text)
            pdfFormFields.SetField("NOMBRE", Form1.LblUsuario.Text.Substring(14))
            If RBCompleta.Checked = True Then
                pdfFormFields.SetField("CBBasico", "0")
                pdfFormFields.SetField("CBCompleto", "Yes")
                pdfFormFields.SetField("CBEspecifico", "0")
                tipo_prueba = 2
            ElseIf RBBasica.Checked = True Then
                pdfFormFields.SetField("CBBasico", "Yes")
                pdfFormFields.SetField("CBCompleto", "0")
                pdfFormFields.SetField("CBEspecifico", "0")
                tipo_prueba = 1
            ElseIf RBEspecifica.Checked = True Then
                pdfFormFields.SetField("CBBasico", "0")
                pdfFormFields.SetField("CBCompleto", "0")
                pdfFormFields.SetField("CBEspecifico", "Yes")
                tipo_prueba = 3
            End If

            Dim filas_total As Integer = DGV.RowCount - 2

            Dim id_prueba As String
            Dim valor_prueba As String

            For i As Integer = 0 To filas_total
                id_prueba = DGV(0, i).Value

                valor_prueba = DGV(6, i).Value.ToString.Trim
                If valor_prueba = "" Then
                    valor_prueba = DGV(5, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(4, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(3, i).Value.ToString.Trim
                End If
                If valor_prueba = "" Then
                    valor_prueba = DGV(2, i).Value.ToString.Trim
                End If

                Select Case id_prueba
                    Case "D-86-01"
                        pdfFormFields.SetField("TxtBxPIE", valor_prueba)
                        Exit Select
                    Case "D-86-14"
                        pdfFormFields.SetField("TxtBxEvap10", valor_prueba)
                        Exit Select
                    Case "D-86-18"
                        pdfFormFields.SetField("TxtBxEvap50", valor_prueba)
                        Exit Select
                    Case "D-86-22"
                        pdfFormFields.SetField("TxtBxEvap90", valor_prueba)
                        Exit Select
                    Case "D-86-24"
                        pdfFormFields.SetField("TxtBxPFE", valor_prueba)
                        Exit Select
                    Case "D-86-28"
                        pdfFormFields.SetField("ResiduoVolumen", valor_prueba)
                        Exit Select
                    Case "D-4953"
                        pdfFormFields.SetField("PresionVaporREID", valor_prueba)
                        Exit Select
                    Case "MMIN"
                        pdfFormFields.SetField("ICV", valor_prueba)
                        Exit Select
                    Case "D-130-02"
                        pdfFormFields.SetField("Corrosion Lamina 50", valor_prueba)
                        Exit Select
                    Case "D-381"
                        pdfFormFields.SetField("Goma Existente100ml", valor_prueba)
                        Exit Select
                    Case "D-525"
                        pdfFormFields.SetField("EstabilidadOxidacion", valor_prueba)
                        Exit Select
                    Case "D-1319-01"
                        pdfFormFields.SetField("Aromaticos", valor_prueba)
                    Case "D-1319-02"
                        pdfFormFields.SetField("Olefinas", valor_prueba)
                    Case "D-1319-03"
                        pdfFormFields.SetField("Insaturados", valor_prueba)
                    Case Else
                        MsgBox("La prueba" & id_prueba & " no se encuentra en la plantilla PDF", MsgBoxStyle.Exclamation, "Error")
                        Exit Select
                End Select

            Next

            content.AddImage(img)

            pdfStamper.FormFlattening = True
            pdfStamper.Close()

            Try
                conn.Open()
                Dim cmd As New MySqlCommand(String.Format("UPDATE `bd_productos`.`productos` SET `Estado`='Aprobado', `ID_Muestra` = '" & TxtBxIDMuestra.Text & "',`Tanque`='" & TxtBxOrigen.Text & "', `Lote`='" & TxtBxLote.Text & "', `ATN`='" & TxtBxATN.Text & "', `TipodePrueba`='" & tipo_prueba & "', `Observaciones_Administrador` ='" & RchTxtBxObservaciones.Text & "' WHERE `ProductoID`='" & TxtBxIDProducto.Text & "';"), conn)
                cmd.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                conn.Close()
            End Try

            MsgBox("Reporte Generado en " & filepath, MsgBoxStyle.Information, "PDF Creado")

            If MessageBox.Show("¿Desea generar un correo con el archivo creado?", "Crear Correo", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                CrearMail(filepath)
            End If

            Try
                Process.Start(filepath)
            Catch ex As Exception
                MsgBox("No se encontro el archivo", MsgBoxStyle.Exclamation, "Error")
            End Try


            Form1.CargarDGVProductosRevisados()
            Me.Close()

        End If

    End Sub

    'Private Sub ListarCampos()
    '    If TxtBxTipoProductoID.Text = "7" Then
    '        Dim pdfTemplate As String = ConfigurationManager.AppSettings("Key7")

    '        Dim pdfReader As PdfReader = New PdfReader(pdfTemplate)

    '        Dim PDFfld As Object

    '        Dim sb As New StringBuilder()

    '        For Each PDFfld In pdfReader.AcroFields.Fields
    '            sb.Append(PDFfld.Key.ToString() + Environment.NewLine)
    '        Next
    '    End If
    'End Sub

    Private Sub BtnGenerarPDF_Click(sender As Object, e As EventArgs) Handles BtnGenerarPDF.Click
        LlenarPDF()
    End Sub

    Private Sub CBPruebaMicro_CheckedChanged(sender As Object, e As EventArgs) Handles CBPruebaMicro.CheckedChanged
        If CBPruebaMicro.Checked = True Then
            GrpBxTipoPrueba.Visible = False
            RBCompleta.Checked = True
        End If
        If CBPruebaMicro.Checked = False Then
            GrpBxTipoPrueba.Visible = True
            RBCompleta.Checked = False
            RBBasica.Checked = False
            RBEspecifica.Checked = False
        End If
    End Sub
End Class
