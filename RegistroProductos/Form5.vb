Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Text


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
                    Dim cmd As New MySqlCommand(String.Format("UPDATE `bd_productos`.`productos` SET `Estado`='Pendiente', `Observaciones` = '" & RchTxtBxObservaciones.Text & "' WHERE `ProductoID`='" & TxtBxIDProducto.Text & "';"), conn)
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
                Dim cmd As New MySqlCommand(String.Format("UPDATE `bd_productos`.`productos` SET `Estado`='Pendiente', `Observaciones` = '" & RchTxtBxObservaciones.Text & "' WHERE `ProductoID`='" & TxtBxIDProducto.Text & "';"), conn)
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

        If TxtBxIDMuestra.Text.Trim.Length = 0 Then
            MsgBox("El campo ID Muestra no puede estar vacio", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        If TxtBxOrigen.Text.Trim.Length = 0 Then
            MsgBox("El campo Origen/Tanque no puede estar vacio", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        If TxtBxLote.Text.Trim.Length = 0 Then
            MsgBox("El campo Cachada/Lote no puede estar vacio", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        CargarPDF()
    End Sub

    Private Sub CargarPDF()

        'ListarCampos()
        LlenarPDF()
    End Sub

    Private Sub LlenarPDF()
        If TxtBxTipoProductoID.Text = "7" Then
            Dim pdfTemplate As String = ConfigurationManager.AppSettings("Key7")
            Dim GuardarPDF As New SaveFileDialog
            GuardarPDF.InitialDirectory = "C:\"
            GuardarPDF.RestoreDirectory = True
            GuardarPDF.DefaultExt = ".pdf"
            GuardarPDF.ShowDialog()
            Dim filepath As String
            Dim tipo_prueba As Integer

            Dim imgurl As String = "C:\Users\IDETECO\source\repos\RegistroProductos\RegistroProductos\Firmas\Firma.png"

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
            pdfFormFields.SetField("FechaReporte", TxtBxFechaRegistro.Text)
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
                    Case "D-32-43"
                        pdfFormFields.SetField("TxtBxAcidezTotal", valor_prueba)
                        Exit Select
                    Case "D-1319"
                        pdfFormFields.SetField("TxtAromaticos", valor_prueba)
                        Exit Select
                    Case "D-4294"
                        pdfFormFields.SetField("TxtAzufre", valor_prueba)
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
                    Case "D-86-1"
                        pdfFormFields.SetField("TxbBxPIE", valor_prueba)
                        Exit Select
                    Case "D-86-2"
                        pdfFormFields.SetField("TxtBxTemp10", valor_prueba)
                        Exit Select
                    Case "D-86-3"
                        pdfFormFields.SetField("TxtBxTemp50", valor_prueba)
                        Exit Select
                    Case "D-86-4"
                        pdfFormFields.SetField("TxtBxTemp90", valor_prueba)
                        Exit Select
                    Case "D-86-6"
                        pdfFormFields.SetField("TxtBxPFE", valor_prueba)
                        Exit Select
                    Case "D-86-7"
                        pdfFormFields.SetField("TxtBxResiduoDestilacion", valor_prueba)
                        Exit Select
                    Case "D-86-8"
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
                    Case "D-130-1"
                        pdfFormFields.SetField("TxtBxCorrosion100", valor_prueba)
                        Exit Select
                    Case "D-3241-1"
                        pdfFormFields.SetField("TxtBxCaidaPresion", valor_prueba)
                        Exit Select
                    Case "D-3241-2"
                        pdfFormFields.SetField("TxtBxCodigoColor", valor_prueba)
                        Exit Select
                    Case "D-3241-2"
                        pdfFormFields.SetField("TxtBxCodigoColor", valor_prueba)
                        Exit Select
                    Case "D-4176"
                        pdfFormFields.SetField("TxtBxApariencia", valor_prueba)
                        Exit Select
                    Case "D-381"
                        pdfFormFields.SetField("TxtBxGoma", valor_prueba)
                        Exit Select
                    Case "D-1094-2"
                        pdfFormFields.SetField("TxtBxClasifInterfase", valor_prueba)
                        Exit Select
                    Case "D-1094-3"
                        pdfFormFields.SetField("TxtBxClasifSeparacion", valor_prueba)
                        Exit Select
                    Case "D-1094-1"
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
                Dim cmd As New MySqlCommand(String.Format("UPDATE `bd_productos`.`productos` SET `Estado`='Aprobado', `ID_Muestra` = '" & TxtBxIDMuestra.Text & "',`Tanque`='" & TxtBxOrigen.Text & "', `Lote`='" & TxtBxLote.Text & "', `ATN`='" & TxtBxATN.Text & "', `TipodePrueba`='" & tipo_prueba & "' WHERE `ProductoID`='" & TxtBxIDProducto.Text & "';"), conn)
                cmd.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                conn.Close()
            End Try

            MsgBox("Reporte Generado en " & filepath, MsgBoxStyle.Information, "PDF Creado")

            Try
                Process.Start(filepath)
            Catch ex As Exception
                MsgBox("No se encontro el archivo", MsgBoxStyle.Exclamation, "Error")
            End Try


            Form1.CargarDGVProductosRevisados()
            Me.Close()

        End If

    End Sub

    Private Sub ListarCampos()
        If TxtBxTipoProductoID.Text = "7" Then
            Dim pdfTemplate As String = ConfigurationManager.AppSettings("Key7")

            Dim pdfReader As PdfReader = New PdfReader(pdfTemplate)

            Dim PDFfld As Object

            Dim sb As New StringBuilder()

            For Each PDFfld In pdfReader.AcroFields.Fields
                sb.Append(PDFfld.Key.ToString() + Environment.NewLine)
            Next
        End If
    End Sub

    Private Sub BtnGenerarPDF_Click(sender As Object, e As EventArgs) Handles BtnGenerarPDF.Click
        CargarPDF()
    End Sub
End Class
