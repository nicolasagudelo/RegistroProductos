Imports MySql.Data.MySqlClient
Imports System.Configuration

Public Class Form7

    Dim conn As New MySqlConnection

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

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect()
        CargarDGV()
    End Sub

    Dim id_producto As String
    Dim id_prueba As String

    Public Sub RecibirVariablesForm5(ByVal var As String, ByVal var2 As String)
        id_producto = var
        id_prueba = var2
    End Sub

    Private Sub CargarDGV()

        If id_prueba = "D-3242" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'WP', Dato_2 as 'Vol', Dato_3 as 'Vb', Dato_4 as 'Normalidad', Dato_5 as 'W Muestra', Dato_6 as 'Vol Muestra', Dato_7 as 'Vol Blanco', Dato_8 as 'Temp. Muestra antes de la titulacion' , Dato_9 as 'Acidez'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-1319-01" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Longitud Total 1 (mm)', Dato_2 as 'Longitud Total 2 (mm)', Dato_3 as 'Longitud Total 3 (mm)', Dato_4 as 'Longitud Total 4 (mm)', Dato_5 as 'Longitud Aromaticos 1 (mm)', Dato_6 as 'Longitud Aromaticos 2 (mm)', Dato_7 as 'Longitud Aromaticos 3 (mm)', Dato_8 as 'Longitud Aromaticos 4 (mm)', Dato_9 as 'La1/Lt1 * 100', Dato_10 as 'La2/Lt2 * 100', Dato_11 as 'La3/Lt3 * 100', Dato_12 as 'La4/Lt4 * 100', Dato_13 as 'Promedio'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-1319-02" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Longitud Total 1 (mm)', Dato_2 as 'Longitud Total 2 (mm)', Dato_3 as 'Longitud Total 3 (mm)', Dato_4 as 'Longitud Total 4 (mm)', Dato_5 as 'Longitud Olefina 1 (mm)', Dato_6 as 'Longitud Olefina 2 (mm)', Dato_7 as 'Longitud Olefina 3 (mm)', Dato_8 as 'Longitud Olefina 4 (mm)', Dato_9 as 'Lo1/Lt1 * 100', Dato_10 as 'Lo2/Lt2 * 100', Dato_11 as 'Lo3/Lt3 * 100', Dato_12 as 'Lo4/Lt4 * 100', Dato_13 as 'Promedio'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-1319-03" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Longitud Total 1 (mm)', Dato_2 as 'Longitud Total 2 (mm)', Dato_3 as 'Longitud Total 3 (mm)', Dato_4 as 'Longitud Total 4 (mm)', Dato_5 as 'Longitud Saturados 1 (mm)', Dato_6 as 'Longitud Saturados 2 (mm)', Dato_7 as 'Longitud Saturados 3 (mm)', Dato_8 as 'Longitud Saturados 4 (mm)', Dato_9 as 'Li1/Lt1 * 100', Dato_10 as 'Li2/Lt2 * 100', Dato_11 as 'Li3/Lt3 * 100', Dato_12 as 'Li4/Lt4 * 100', Dato_13 as 'Promedio'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-1840" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Absorbancia (285nm)', Dato_2 as 'Peso Muestra', Dato_3 as 'Constante (K)', Dato_4 as 'Absortividad Naftaleno', Dato_5 as 'Densidad Rel. Muestra a 15ºC', Dato_6 as 'Densidad Rel. Naftaleno a 15ºC', Dato_7 as '% Mass', Dato_8 as 'B/C', Dato_9 as '% Volumen'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-1322" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Turbidez', Dato_2 as 'Filtracion', Dato_3 as 'Presion Barometrica (kPal)', Dato_4 as 'Temperatura Muestra (°C)', Dato_5 as 'Lectura 1 (mm)', Dato_6 as 'Lectura 2 (mm)', Dato_7 as 'Lectura 3 (mm)', Dato_8 as 'Promedio', Dato_9 as 'Factor de Correccion', Dato_10 as 'Valor Final'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-56" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Temperatura Muestra (°C)', Dato_2 as 'Presion Barometrica Observada (kPal)', Dato_3 as ' Punto de Chispa Observado(°C)', Dato_4 as 'Punto de Chispa Corregido (°C)'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-93" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Temperatura Muestra (°C)', Dato_2 as 'Presion Barometrica Observada (kPal)', Dato_3 as ' Punto de Chispa Observado(°C)', Dato_4 as 'Punto de Chispa Corregido (°C)'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-4294-01" Or id_prueba = "D-4294-02" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Agua Suspendida', Dato_2 as 'Homogeniziacion y Analisis Inmediato', Dato_3 as 'Muestra 1', Dato_4 as 'Muestra 2', Dato_5 as 'Promedio'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-3241-01" Or id_prueba = "D-3241-02" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'No. Serie Heater Tube', Dato_2 as 'Observaciones', Dato_3 as 'Temperatura Fuel en la Aireación (°C)', Dato_4 as 'Hora Inicio Heater', Dato_5 as 'Hora Finalizacion Aireación Heater', Dato_6 as 'Tiempo Caida 20 GOTAS Fuel Inicio Prueba (s) Ó VOLUMEN', Dato_7 as 'Tiempo Caida 20 GOTAS Fuel Final Prueba (s) Ó VOLUMEN', Dato_8 as 'Volumen Pasado Combustible Despues de Finalizada la Prueba (mL)', Dato_9 as 'Resultado', Dato_10 as 'Hora Finalizacion Prueba'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-86-01" Or id_prueba = "D-86-03" Or id_prueba = "D-86-07" Or id_prueba = "D-86-11" Or id_prueba = "D-86-12" Or id_prueba = "D-86-24" Or id_prueba = "D-86-25" Or id_prueba = "D-86-26" Or id_prueba = "D-86-14" Or id_prueba = "D-86-17" Or id_prueba = "D-86-18" Or id_prueba = "D-86-22" Or id_prueba = "D-86-27" Or id_prueba = "D-86-28" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Temperatura Muestra (°C)', Dato_2 as 'Presion Barometrica Observada (kPa)', Dato_3 as 'Observaciones', Dato_4 as 'Agua Libre', Dato_5 as 'Turbidez', Dato_6 as 'Secado con Desecante', Dato_7 as 'Resultado'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-2386" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Temperatura Observada Formacion Cristales (°C)', Dato_2 as 'Temperatura Corregida Formacion Cristales (°C)', Dato_3 as 'Temperatura Observada Desaparicion Total Cristales (°C)', Dato_4 as 'Temperatura Corregida Desaparicion Total Cristales (°C)', Dato_5 as 'Resultado'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-4176" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Temperatura Muestra (°F)', Dato_2 as 'Clara y Brillante', Dato_3 as 'Libre de Agua', Dato_4 as 'Particulas en Suspension', Dato_5 as 'Resultado', Dato_6 as 'Observaciones'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-3948" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Material Suspendido', Dato_2 as 'Decantacion', Dato_3 as 'Temp. Amb. 1 (°C)', Dato_4 as 'Temp. Amb. 2 (°C)', Dato_5 as 'Variacion (°C)', Dato_6 as 'Temp. Muestra (°C)', Dato_7 as 'Resultado'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-1094-01" Or id_prueba = "D-1094-02" Or id_prueba = "D-1094-03" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Temp. Muestra (°C)', Dato_2 as 'Volumen Buffer (mL)', Dato_3 as 'Observaciones', Dato_4 as 'Resultado'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-130-01" Or id_prueba = "D-130-02" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Turbidez', Dato_2 as 'Filtracion', Dato_3 as 'Resultado'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-4953" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Vol. Muestra 70-80%', Dato_2 as 'Muestra Descartada', Dato_3 as 'Agua Libre (Dos Fases)', Dato_4 as 'Muestra Descartada', Dato_5 as 'Lectura Patron PSI (Antes)', Dato_6 as 'Lectura Nanometro Trabajo PSI (Antes)', Dato_7 as 'Correccion PSI (Antes)', Dato_8 as 'Valor Presion de Vapor Corregido PSI (Antes)', Dato_9 as 'Valor Presion de Vapor Corregido kPa (Antes)', Dato_10 as 'Lectura Patron PSI (Despues)', Dato_11 as 'Lectura Nanometro Trabajo PSI (Despues)', Dato_12 as 'Correccion PSI (Despues)', Dato_13 as 'Valor Presion de Vapor Corregido PSI (Despues)', Dato_14 'Valor Presion de Vapor Corregido kPa (Despues)'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-4815" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Peso Estandar Interno (g)', Dato_2 as 'Peso Gasolina Oxigenada (g)', Dato_3 as 'Temperatura de la Muestra (°C)', Dato_4 as 'Resultado'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-1298" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Temperatura Observada 1 (°F)', Dato_2 as 'API Observado', Dato_3 as 'Temperatura Observada 2(°f)', Dato_4 as 'Promedio Temperatura (°F)', Dato_5 as 'Presion Barometrica (PSI)', Dato_6 as 'Densidad Relativa Despues de Correcciones as 15°C', Dato_7 as 'Resultado'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-445" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Particulas o Fibras', Dato_2 as 'Filtracion (Filtro 75 µm)', Dato_3 as 'Resultado'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "MMIN" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Presion de Vapor REID Obtenida kPa (P)', Dato_2 as 'Porcentaje Evaporado a 70°C (A)', Dato_3 as 'ICV (P + 1.13 x A)'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "EN14078" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Relacion Dilucion', Dato_2 as 'Dato Interpolado en la Curva', Dato_3 as 'Densidad BioDiesel Usada', Dato_4 as 'Observaciones', Dato_5 as 'Resultado'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "EN12937" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Peso Muestra', Dato_2 as 'Observaciones', Dato_3 as 'Concentracion Leida'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-7321" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Peso Inicial Membrana 1', Dato_2 as 'Peso Final Membrana 1', Dato_3 as 'Diferencia de pesos Membrana 1', Dato_4 as 'Peso Inicial Membrana 2', Dato_5 as 'Peso Final Membrana 2', Dato_6 as 'Diferencia de pesos Membrana 2', Dato_7 as 'Peso Inicial Membrana 3', Dato_8 as 'Peso Final Membrana 3', Dato_9 as 'Diferencia de pesos Membrana 3', Dato_10 as 'Volumen Filtrado Membrana 1', Dato_11 as 'Volumen Filtrado Membrana 2', Dato_12 as 'Volumen Filtrado Membrana 3', Dato_13 as 'Suma Diferencia de Pesos', Dato_14 as 'Suma Volumenes', Dato_15 as 'Resultado'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-525" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Hora Inicio Inmersion Vasija de Presion al Baño', Dato_2 as 'Caida de Presion en 10 Minutos (Antes de Iniciar)', Dato_3 as 'Promedio Temperatura de la Prueba (°C)', Dato_4 as 'Periodo de Induccion Observado', Dato_5 as 'Resultado'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        ElseIf id_prueba = "D-381" Then

            If Form5.TxtBxTipoProductoID.Text = "4" Then

                Dim query As String = "SELECT DatoID, Dato_1 as 'Peso Beaker Muestra con Residuo (B)', Dato_2 as 'Peso Beaker Muestra Vacio (D)', Dato_3 as 'Peso Beaker Blanco Antes (X)', Dato_4 as 'Peso Beaker Blanco Despues Prueba (Y)', Dato_5 as 'Material Suspendido', Dato_6 as 'Filtracion Vidrio Sinterizado', Dato_7 as 'Gomas Existentes', Dato_8 as 'Gomas Existentes Valor Reporte'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
                LoadDGV(query)

            ElseIf Form5.TxtBxTipoProductoID.Text = "6" Or Form5.TxtBxTipoProductoID.Text = "7" Or Form5.TxtBxTipoProductoID.Text = "8" Or Form5.TxtBxTipoProductoID.Text = "9" Then

                Dim query As String = "SELECT DatoID, Dato_1 as 'Peso Beaker Muestra con Residuo (B)', Dato_2 as 'Peso Beaker Muestra Vacio (D)', Dato_3 as 'Peso Beaker Blanco Antes (X)', Dato_4 as 'Peso Beaker Blanco Despues Prueba (Y)', Dato_5 as 'Peso Beaker Muestra con Residuo Despues Lavado (C)', Dato_6 as 'Peso Beaker Blanco Despues Lavado (Z)', Dato_7 as 'Material Suspendido', Dato_8 as 'Filtracion Vidrio Sinterizado', Dato_9 as 'Gomas sin Lavar', Dato_10 as 'Gomas sin Lavar Valor Reporte', Dato_11 as 'Gomas Lavadas', Dato_12 as 'Gomas Lavadas Valor Reporte'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
                LoadDGV(query)

            End If

        ElseIf id_prueba = "D-3338" Then

            Dim query As String = "SELECT DatoID, Dato_1 as 'Aromaticos (A)', Dato_2 as 'Densidad (D)', Dato_3 as 'T10°C Recogido', Dato_4 as 'T50°C Recogido', Dato_5 as 'T90°C Recogido', Dato_6 as 'Promedio (T)', Dato_7 as 'MJ/Kg, Libre de Azufre', Dato_8 as 'Azufre % Masa', Dato_9 as 'MJ/Kg Corregido con S'
                                   from datosproducto
                                   where ProductoID = '" & id_producto & "' and ID_Prueba = '" & id_prueba & "';"
            LoadDGV(query)

        End If




    End Sub

    Private Sub LoadDGV(ByVal query As String)
        Dim cmd As New MySqlCommand(query, conn)
        Dim reader As MySqlDataReader

        Try
            conn.Open()
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
        Try
            DGV.Columns(0).Visible = False
        Catch ex As Exception
        End Try

    End Sub
End Class