Imports System.Net
Imports Newtonsoft.Json
Imports System.IO
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Imports System.Threading


Public Class FormImportacionArchivos

    Private _usuario As dUsuario
    Private ficha As String
    Dim exitos As New List(Of String)
    Dim errores As New List(Of String)

    Public Sub New(ByVal u As dUsuario)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        InicializarGrilla()

        Usuario = u
    End Sub

    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

    Private Sub InicializarGrilla()
        dgvArchivos.Columns.Clear() ' Limpiar columnas si ya existían

        ' Columna de selección (checkbox)
        Dim checkCol As New DataGridViewCheckBoxColumn()
        checkCol.Name = "Seleccionar"
        checkCol.HeaderText = ""
        checkCol.Width = 30
        checkCol.TrueValue = True
        checkCol.FalseValue = False
        checkCol.ThreeState = False
        dgvArchivos.Columns.Add(checkCol)

        ' Columna para el nombre del archivo
        dgvArchivos.Columns.Add("Nombre", "Nombre del Archivo")

        ' Columna ComboBox para seleccionar el origen
        Dim comboCol As New DataGridViewComboBoxColumn()
        comboCol.Name = "Origen"
        comboCol.HeaderText = "Origen"
        comboCol.Items.Add("Delta600")
        comboCol.Items.Add("Bentley600")
        dgvArchivos.Columns.Add(comboCol)

        ' Columna para la ruta completa (visible o no según lo que prefieras)
        Dim rutaCol As New DataGridViewTextBoxColumn()
        rutaCol.Name = "Ruta"
        rutaCol.HeaderText = "Ruta del Archivo"
        rutaCol.Width = 400
        rutaCol.Visible = True ' Cambiá a False si querés que sea oculta
        dgvArchivos.Columns.Add(rutaCol)
    End Sub

    Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "Archivos CSV, XLSX y FAT (*.csv;*.xlsx;*.fat)|*.csv;*.xlsx;*.fat"
        ofd.Multiselect = True

        If ofd.ShowDialog() = DialogResult.OK Then
            For Each archivo In ofd.FileNames
                Dim nombreArchivo As String = Path.GetFileName(archivo)
                Dim nuevaFila As Integer = dgvArchivos.Rows.Add()
                Dim Ruta As String = Path.GetDirectoryName(archivo)

                dgvArchivos.Rows(nuevaFila).Cells("Seleccionar").Value = False
                dgvArchivos.Rows(nuevaFila).Cells("Nombre").Value = nombreArchivo
                dgvArchivos.Rows(nuevaFila).Cells("Origen").Value = "" ' El usuario deberá seleccionar
                dgvArchivos.Rows(nuevaFila).Cells("Ruta").Value = Ruta
            Next
        End If

        dgvArchivos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If String.IsNullOrEmpty(tbxFicha.Text.Trim()) Then
            MsgBox("Debe ingresar un número de ficha.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim ficha As Long
        If Not Long.TryParse(tbxFicha.Text.Trim(), ficha) Then
            MsgBox("El número de ficha no es válido.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sa As New dSolicitudAnalisis
        Dim datos As DataRow = sa.buscarDatosFicha(ficha)

        If datos IsNot Nothing Then
            tbxFechaIngreso.Text = datos("fechaingreso").ToString()
            tbxCliente.Text = datos("cliente").ToString()
            tbxTipoInforme.Text = datos("tipoinforme").ToString()
        Else
            MsgBox("Ficha no encontrada.", MsgBoxStyle.Information)
        End If

        tbxCliente.ReadOnly = True
        tbxTipoInforme.ReadOnly = True
        tbxFechaIngreso.ReadOnly = True
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        ' Limpiar campos de texto
        tbxFicha.Text = ""
        tbxCliente.Text = ""
        tbxTipoInforme.Text = ""
        tbxFechaIngreso.Text = ""

        ' Limpiar la grilla de archivos
        If dgvArchivos.Columns.Count > 0 Then
            dgvArchivos.Rows.Clear()
        End If

        tbxCliente.ReadOnly = True
        tbxTipoInforme.ReadOnly = True
        tbxFechaIngreso.ReadOnly = True
    End Sub

    'Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click

    '     ficha = tbxFicha.Text
    '     Dim tipoInforme As String = tbxTipoInforme.Text.Trim().ToUpper()

    '     'Elimina los registros dependiendo el tipo de informe que sea de la tabla control/calidad
    '     RestablecerEstadoFicha(ficha, tipoInforme)

    '     For Each row As DataGridViewRow In dgvArchivos.Rows
    '         If Convert.ToBoolean(row.Cells("Seleccionar").Value) Then
    '             Dim rutaArchivo As String = Convert.ToString(row.Cells("Ruta").Value)
    '             Dim nombreArchivo As String = Convert.ToString(row.Cells("Nombre").Value)
    '             Dim origenArchivo As String = Convert.ToString(row.Cells("Origen").Value).Trim().ToUpper()
    '             Dim extension As String = IO.Path.GetExtension(nombreArchivo).ToLower().Replace(".", "")

    '             Select Case origenArchivo
    '                 Case "DELTA600"
    '                     Select Case tipoInforme
    '                         Case "CONTROL LECHERO"
    '                             Select Case extension
    '                                 Case "csv"
    '                                     ProcesarArchivoControlCsv(rutaArchivo, nombreArchivo)
    '                                 Case "xls", "xlsx"
    '                                     ProcesarArchivoControlXls(rutaArchivo, nombreArchivo)
    '                                 Case Else
    '                                     errores.Add("Error moviendo archivo " & nombreArchivo & " Extensión {extension} no soportada para CONTROL desde Delta600.")
    '                             End Select

    '                         Case "CALIDAD"
    '                             Select Case extension
    '                                 Case "fat"
    '                                     ProcesarArchivoCalidadFat(rutaArchivo, nombreArchivo)
    '                                 Case "xls", "xlsx", "csv"
    '                                     ProcesarArchivoCalidadXlsCsv(rutaArchivo, nombreArchivo)
    '                                 Case Else
    '                                     errores.Add("Error moviendo archivo " & nombreArchivo & " Extensión {extension} no soportada para CALIDAD desde Delta600.")
    '                             End Select

    '                         Case Else
    '                             errores.Add(nombreArchivo & " Tipo de informe no reconocido (esperado CALIDAD o CONTROL).")
    '                     End Select

    '                 Case "BENTLEY600"
    '                     Select Case tipoInforme
    '                         Case "CONTROL LECHERO"
    '                             ProcesarArchivoControlB6(rutaArchivo, nombreArchivo)
    '                         Case "CALIDAD"
    '                             ProcesarArchivoCalidadB6Csv(rutaArchivo, nombreArchivo)
    '                         Case Else
    '                             errores.Add("Error moviendo archivo " & nombreArchivo & " Tipo de informe no reconocido (esperado CALIDAD o CONTROL).")
    '                     End Select

    '                 Case Else
    '                     errores.Add(nombreArchivo & " Origen no reconocido. Debe ser 'Delta600' o 'Bentley600'.")
    '             End Select
    '         End If
    '     Next

    '     ' Mostrar resumen final
    '     If exitos.Count > 0 Then
    '         MessageBox.Show("Archivos procesados correctamente:" & Environment.NewLine & String.Join(Environment.NewLine, exitos.ToArray()), "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '         tbxFicha.Text = ""
    '         tbxCliente.Text = ""
    '         tbxTipoInforme.Text = ""
    '         tbxFechaIngreso.Text = ""

    '         ' Limpiar la grilla de archivos
    '         If dgvArchivos.Columns.Count > 0 Then
    '             dgvArchivos.Rows.Clear()
    '         End If

    '         tbxCliente.ReadOnly = True
    '         tbxTipoInforme.ReadOnly = True
    '         tbxFechaIngreso.ReadOnly = True

    '     End If

    '     If errores.Count > 0 Then
    '         MessageBox.Show("Se encontraron errores:" & Environment.NewLine & String.Join(Environment.NewLine, errores.ToArray()), "Errores", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '     End If

    ' End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        ficha = tbxFicha.Text
        Dim tipoInforme As String = tbxTipoInforme.Text.Trim().ToUpper()

        ' Eliminar registros anteriores
        RestablecerEstadoFicha(ficha, tipoInforme)

        Dim archivosSeleccionados As New List(Of ArchivoSeleccionado)

        For Each row As DataGridViewRow In dgvArchivos.Rows
            If Convert.ToBoolean(row.Cells("Seleccionar").Value) Then
                Dim archivo As New ArchivoSeleccionado With {
                    .Ruta = Convert.ToString(row.Cells("Ruta").Value),
                    .Nombre = Convert.ToString(row.Cells("Nombre").Value),
                    .Origen = Convert.ToString(row.Cells("Origen").Value).Trim().ToUpper(),
                    .TipoInforme = tipoInforme
                }
                archivosSeleccionados.Add(archivo)
            End If
        Next

        ' Procesar archivos seleccionados
        ProcesarArchivos(archivosSeleccionados)

        ' Limpieza y reseteo
        tbxFicha.Clear()
        tbxCliente.Clear()
        tbxTipoInforme.Clear()
        tbxFechaIngreso.Clear()

        If dgvArchivos.Columns.Count > 0 Then
            dgvArchivos.Rows.Clear()
        End If

        tbxCliente.ReadOnly = True
        tbxTipoInforme.ReadOnly = True
        tbxFechaIngreso.ReadOnly = True
    End Sub

    Public Sub ProcesarArchivos(archivos As List(Of ArchivoSeleccionado))
        Dim exitos As New List(Of String)
        Dim errores As New List(Of String)

        For Each archivo In archivos
            Dim extension As String = IO.Path.GetExtension(archivo.Nombre).ToLower().Replace(".", "")
            Dim procesadoCorrectamente As Boolean = False

            Try
                Select Case archivo.Origen
                    Case "DELTA600"
                        Select Case archivo.TipoInforme
                            Case "CONTROL LECHERO"
                                Select Case extension
                                    Case "csv"
                                        ProcesarArchivoControlCsv(archivo.Ruta, archivo.Nombre)
                                        procesadoCorrectamente = True
                                    Case "xls", "xlsx"
                                        ProcesarArchivoControlXls(archivo.Ruta, archivo.Nombre)
                                        procesadoCorrectamente = True
                                    Case Else
                                        errores.Add(String.Format("{0} → Extensión '{1}' no soportada para CONTROL desde Delta600.", archivo.Nombre, extension))
                                End Select

                                If procesadoCorrectamente Then
                                    ' Pre informe Control
                                    PrepararYGenerarExcelControl(ficha)
                                End If

                            Case "CALIDAD"
                                Select Case extension
                                    Case "fat"
                                        ProcesarArchivoCalidadFat(archivo.Ruta, archivo.Nombre)
                                        procesadoCorrectamente = True
                                    Case "xls", "xlsx", "csv"
                                        ProcesarArchivoCalidadXlsCsv(archivo.Ruta, archivo.Nombre)
                                        procesadoCorrectamente = True
                                    Case Else
                                        errores.Add(String.Format("{0} → Extensión '{1}' no soportada para CALIDAD desde Delta600.", archivo.Nombre, extension))
                                End Select


                            Case Else
                                errores.Add(String.Format("{0} → Tipo de informe '{1}' no soportado desde Delta600.", archivo.Nombre, archivo.TipoInforme))
                        End Select

                    Case "BENTLEY600"
                        Select Case archivo.TipoInforme
                            Case "CONTROL LECHERO"
                                ProcesarArchivoControlB6(archivo.Ruta, archivo.Nombre)
                                procesadoCorrectamente = True

                                'If procesadoCorrectamente Then
                                '    PrepararYGenerarExcelControl(ficha)
                                'End If

                            Case "CALIDAD"
                                ProcesarArchivoCalidadB6Csv(archivo.Ruta, archivo.Nombre)
                                procesadoCorrectamente = True
                                
                                'If procesadoCorrectamente Then
                                '    If VerificarDatosCalidad(ficha) Then
                                '        GenerarExcelCalidad(archivo)
                                '    End If
                                'End If

                            Case Else
                                errores.Add(String.Format("{0} → Tipo de informe '{1}' no soportado desde Bentley600.", archivo.Nombre, archivo.TipoInforme))
                        End Select

                    Case Else
                        errores.Add(String.Format("{0} → Origen '{1}' no soportado.", archivo.Nombre, archivo.Origen))
                End Select

                If procesadoCorrectamente Then
                    exitos.Add(archivo.Nombre)
                End If

            Catch ex As Exception
                errores.Add(String.Format("{0} → Error en procesamiento: {1}", archivo.Nombre, ex.Message))
            End Try
        Next

        ' Mostrar resumen final
        Dim mensajeFinal As String = "Resumen del procesamiento:" & vbCrLf & vbCrLf
        mensajeFinal &= "✔ Archivos procesados correctamente: " & exitos.Count & vbCrLf
        If exitos.Count > 0 Then mensajeFinal &= String.Join(vbCrLf, exitos.ToArray()) & vbCrLf

        mensajeFinal &= vbCrLf & "❌ Archivos con error: " & errores.Count & vbCrLf
        If errores.Count > 0 Then mensajeFinal &= String.Join(vbCrLf, errores.ToArray())

        MsgBox(mensajeFinal, MsgBoxStyle.Information, "Resultado final")
    End Sub



    Private Sub ProcesarArchivoCalidadFat(rutaArchivo As String, nombreArchivo As String)
        Dim extension As String = Path.GetExtension(nombreArchivo).ToLower().Replace(".", "")
        If extension <> "fat" Then Exit Sub

        Dim matricula As String = ""
        Dim grasa As Double = 0
        Dim proteina As Double = 0
        Dim lactosa As Double = 0
        Dim st As Double = 0
        Dim rc As Integer = 0
        Dim ficha As String = ""
        Dim ficha2 As String = ""
        Dim ficha3 As String = ""

        Try
            Using objReader As New StreamReader(Path.Combine(rutaArchivo, nombreArchivo))
                Dim cuentalinea As Long = 1
                Dim sLine As String = ""

                Do
                    sLine = objReader.ReadLine()
                    If sLine Is Nothing Then Exit Do

                    ficha2 = Mid(nombreArchivo, Len(nombreArchivo) - 4, 1)
                    ficha3 = Mid(nombreArchivo, 1, 1)
                    If "abcdABCD".Contains(ficha2) Then
                        ficha = Mid(nombreArchivo, 1, Len(nombreArchivo) - 5)
                    Else
                        ficha = Mid(nombreArchivo, 1, Len(nombreArchivo) - 4)
                    End If
                    If ficha.StartsWith("l", StringComparison.OrdinalIgnoreCase) Then
                        ficha3 = ficha.TrimStart("l"c, "L"c)
                    Else
                        ficha3 = ficha
                    End If

                    Dim fecha As String = Format(Now(), "yyyy-MM-dd")
                    Dim Texto As String = sLine

                    Dim id As Integer = 0
                    Integer.TryParse(Trim(Mid(Texto, 1, 8)), id)

                    matricula = Trim(Mid(Texto, 9, 9))

                    Double.TryParse(Trim(Mid(Texto, 18, 9)), grasa)
                    Double.TryParse(Trim(Mid(Texto, 27, 9)), proteina)
                    Double.TryParse(Trim(Mid(Texto, 36, 9)), lactosa)
                    Double.TryParse(Trim(Mid(Texto, 45, 9)), st)
                    Integer.TryParse(Trim(Mid(Texto, 54, 10)), rc)

                    Dim c As New dImpCalidad()
                    c.FICHA = ficha3
                    c.FECHA = fecha
                    c.EQUIPO = "bentley"
                    c.PRODUCTO = "leche"
                    c.MUESTRA = matricula
                    c.RC = rc
                    c.GRASA = grasa
                    c.PROTEINA = proteina
                    c.LACTOSA = lactosa
                    c.ST = st
                    c.CRIOSCOPIA = -1
                    c.UREA = -1
                    c.PROTEINAV = -1
                    c.CASEINA = -1
                    c.DENSIDAD = -1
                    c.PH = -1
                    c.guardar()

                    cuentalinea += 1

                    Dim csm As New dCalidadSolicitudMuestra
                    Dim listacsm As ArrayList = csm.listarporsolicitud(ficha3)
                    Dim noactualizafecha As Integer = 0
                    If listacsm IsNot Nothing Then
                        For Each csm In listacsm
                            If csm.RB = 1 Then
                                noactualizafecha = 1
                                Exit For
                            End If
                        Next
                    End If

                    If noactualizafecha = 0 Then
                        Dim sa As New dSolicitudAnalisis
                        sa.ID = ficha3
                        sa.actualizarfechaproceso(fecha)
                        sa = Nothing
                    End If

                Loop

                'MoverArchivoProcesado(rutaArchivo, nombreArchivo) ' muestra MsgBox

                ' Insertar en preinformes
                Dim pi As New dPreinformes
                Dim _fecha As String = Format(Now(), "yyyy-MM-dd")
                pi.FICHA = ficha3
                pi = pi.buscar()
                If pi Is Nothing Then
                    Dim pi2 As New dPreinformes
                    Dim sa As New dSolicitudAnalisis
                    Dim tipof As Integer = 0
                    sa.ID = ficha3
                    sa = sa.buscar()
                    If sa IsNot Nothing Then
                        tipof = sa.IDTIPOINFORME
                    End If
                    pi2.FICHA = ficha3
                    pi2.TIPO = tipof
                    pi2.CREADO = 0
                    pi2.FECHA = _fecha
                    pi2.guardar()
                    pi2 = Nothing
                    sa = Nothing
                End If
                pi = Nothing

                ' Guardar estado
                Dim est As New dEstados
                est.FICHA = ficha3
                est.ESTADO = 4
                est.FECHA = _fecha
                est.guardar2()
                est = Nothing
            End Using
        Catch
            ' No hace nada si hay error general
        End Try
    End Sub

    Public Sub ProcesarArchivoCalidadXlsCsv(rutaArchivo As String, nombrearchivo As String)
        Dim extension As String = Microsoft.VisualBasic.Right(nombrearchivo, 3)
        Dim linea As Integer = 1

        If nombrearchivo.Length > 12 Then ' controlo si el archivo es de delta nuevo
            Dim objReader As New StreamReader(rutaArchivo + "\" + nombrearchivo)
            Dim sLine As String = ""
            Dim arraytext() As String
            Dim matricula As String = ""
            Dim grasa As Double = 0
            Dim proteina As Double = 0
            Dim lactosa As Double = 0
            Dim st As Double = 0
            Dim rc As Integer = 0
            Dim ficha As String = ""
            Dim ficha2 As String = ""
            Dim ficha3 As String = ""
            Dim producto As String = ""
            Dim crioscopia As Integer = 0
            Dim urea As Integer = 0
            Dim proteinav As Double = 0
            Dim caseina As Double = 0
            Dim densidad As Double = 0
            Dim ph As Double = 0

            If extension = "csv" Or extension = "CSV" Then
                Dim c As New dImpCalidad()
                Do
                    sLine = objReader.ReadLine()
                    If sLine <> " " And sLine <> "" Then
                        If linea = 3 Then
                            arraytext = Split(sLine, ";")
                            If arraytext.Length < 11 Then arraytext = Split(sLine, ";")
                            producto = Trim(arraytext(10))
                        End If
                        If Not sLine Is Nothing Then
                            If linea >= 8 Then
                                arraytext = Split(sLine, ";")
                                If arraytext.Length < 39 Then arraytext = Split(sLine, ";")

                                If arraytext.Count >= 5 Then matricula = Trim(arraytext(5))

                                ' Inicializo en -1 todos los datos si la línea no tiene todos los campos
                                grasa = -1 : proteina = -1 : lactosa = -1 : st = -1 : rc = -1
                                crioscopia = -1 : urea = -1 : proteinav = -1 : caseina = -1 : densidad = -1 : ph = -1

                                ' Extraer y validar datos
                                Try
                                    If arraytext.Length > 14 Then
                                        If Trim(arraytext(11)) <> "" AndAlso Trim(arraytext(11)) <> "-" Then grasa = arraytext(11)
                                        If Trim(arraytext(12)) <> "" AndAlso Trim(arraytext(12)) <> "-" Then proteina = arraytext(12)
                                        If Trim(arraytext(13)) <> "" AndAlso Trim(arraytext(13)) <> "-" Then lactosa = arraytext(13)
                                        If Trim(arraytext(14)) <> "" AndAlso Trim(arraytext(14)) <> "-" Then st = arraytext(14)
                                    End If
                                    If arraytext.Length > 9 Then
                                        If Trim(arraytext(9)) <> "" AndAlso Trim(arraytext(9)) <> "-" Then rc = arraytext(9)
                                    End If
                                    If arraytext.Length > 15 Then
                                        If Trim(arraytext(15)) <> "" AndAlso Trim(arraytext(15)) <> "-" Then crioscopia = arraytext(15)
                                    End If
                                    If arraytext.Length > 16 Then
                                        If Trim(arraytext(16)) <> "" AndAlso Trim(arraytext(16)) <> "-" Then urea = arraytext(16)
                                    End If
                                    If arraytext.Length > 18 Then
                                        If Trim(arraytext(18)) <> "" AndAlso Trim(arraytext(18)) <> "-" Then proteinav = arraytext(18)
                                    End If
                                    If arraytext.Length > 19 Then
                                        If Trim(arraytext(19)) <> "" AndAlso Trim(arraytext(19)) <> "-" Then caseina = arraytext(19)
                                    End If
                                    If arraytext.Length > 22 Then
                                        If Trim(arraytext(22)) <> "" AndAlso Trim(arraytext(22)) <> "-" Then ph = arraytext(22)
                                    End If
                                Catch ex As Exception
                                    MsgBox("Error en archivo: " & nombrearchivo & ", línea: " & linea)
                                    Exit Sub
                                End Try

                                ficha2 = Mid(nombrearchivo, Len(nombrearchivo) - 21, 1)
                                ficha3 = If("ABCDEFGHIJKLabcdefghijkl".Contains(ficha2), Mid(nombrearchivo, 1, Len(nombrearchivo) - 22), Mid(nombrearchivo, 1, Len(nombrearchivo) - 21))
                                If Mid(ficha3, 1, 1).ToLower() = "l" Then ficha3 = ficha3.TrimStart("l"c, "L"c)

                                ' Control de crioscopía
                                Dim cc As New dCrioscopia_Control
                                cc.FICHA = ficha3
                                cc.MUESTRA = matricula
                                cc = cc.buscarxfichaxmuestra
                                If Not cc Is Nothing Then
                                    Dim diferencia = Math.Abs(cc.DELTA - cc.CRIOSCOPO)
                                    If diferencia > 5 Then crioscopia = cc.CRIOSCOPO
                                End If

                                ' Guardar datos
                                Dim fecha As String = Format(Now(), "yyyy-MM-dd")
                                c.FICHA = ficha3
                                c.FECHA = fecha
                                c.EQUIPO = "delta2"
                                c.PRODUCTO = producto
                                c.MUESTRA = matricula
                                c.RC = rc
                                c.GRASA = grasa
                                c.PROTEINA = proteina
                                c.LACTOSA = lactosa
                                c.ST = st
                                c.CRIOSCOPIA = crioscopia
                                c.UREA = urea
                                c.PROTEINAV = proteinav
                                c.CASEINA = caseina
                                c.DENSIDAD = densidad
                                c.PH = ph
                                c.guardar()

                                ' Verifica si actualizar fecha proceso
                                Dim csm As New dCalidadSolicitudMuestra
                                Dim listacsm As ArrayList = csm.listarporsolicitud(ficha3)
                                Dim noactualizafecha As Integer = 0
                                If Not listacsm Is Nothing Then
                                    For Each csm In listacsm
                                        If csm.RB = 1 Then noactualizafecha = 1
                                    Next
                                End If
                                If noactualizafecha = 0 Then
                                    Dim sa As New dSolicitudAnalisis
                                    sa.ID = ficha3
                                    sa.actualizarfechaproceso(fecha)
                                End If
                            End If
                        End If
                    End If
                    linea += 1
                Loop
                objReader.Close()

                'MoverArchivoProcesado(rutaArchivo, nombreArchivo) ' muestra MsgBox

                ' Preinforme
                Dim pi As New dPreinformes
                Dim _fecha As String = Format(Now(), "yyyy-MM-dd")
                pi.FICHA = ficha3
                pi = pi.buscar
                If pi Is Nothing Then
                    Dim pi2 As New dPreinformes
                    pi2.FICHA = ficha3
                    pi2.TIPO = 10
                    pi2.CREADO = 0
                    pi2.FECHA = _fecha
                    pi2.guardar()
                End If

                ' Estado
                Dim est As New dEstados
                est.FICHA = ficha3
                est.ESTADO = 4
                est.FECHA = _fecha
                est.guardar2()
            End If
        End If
    End Sub

    Private Sub RegistrarPreinformeYEstado(ficha As String, tipoInforme As Integer)
        Dim fecha As String = Format(Now(), "yyyy-MM-dd")
        Dim pi As New dPreinformes()
        pi.FICHA = ficha
        If pi.buscar() Is Nothing Then
            Dim nuevo As New dPreinformes()
            nuevo.FICHA = ficha
            nuevo.TIPO = tipoInforme
            nuevo.CREADO = 0
            nuevo.FECHA = fecha
            nuevo.guardar()
        End If

        Dim est As New dEstados()
        est.FICHA = ficha
        est.ESTADO = 4
        est.FECHA = fecha
        est.guardar2()
    End Sub

    Private Sub ProcesarArchivoControlCsv(rutaArchivo As String, nombreArchivo As String)
        Dim extension As String
        Dim linea As Integer = 1
        Dim ficha As String = ""
        Dim ficha2 As String = ""
        Dim ficha3 As String = ""

        extension = Microsoft.VisualBasic.Right(nombreArchivo, 3)
        Dim objReader As New StreamReader(Path.Combine(rutaArchivo, nombreArchivo))
        Dim sLine As String = ""
        Dim arraytext() As String
        Dim matricula As String = ""
        Dim grasa As Double = 0
        Dim proteina As Double = 0
        Dim lactosa As Double = 0
        Dim st As Double = 0
        Dim rc As Integer = 0
        Dim producto As String = ""
        Dim crioscopia As Integer = 0
        Dim urea As Integer = 0
        Dim proteinav As Double = 0
        Dim caseina As Double = 0
        Dim densidad As Double = 0
        Dim ph As Double = 0
        Dim bhb As Double = 0

        If extension = "csv" Or extension = "CSV" Then
            Dim c As New dImpControl()
            Do
                sLine = objReader.ReadLine()
                If sLine IsNot Nothing AndAlso Trim(sLine) <> "" Then
                    If linea = 3 Then
                        arraytext = Split(sLine, ";")
                        If arraytext.Length < 11 Then arraytext = Split(sLine, ",")
                        producto = Trim(arraytext(10))
                    End If

                    If linea >= 8 Then
                        arraytext = Split(sLine, ";")
                        If arraytext.Length < 39 Then arraytext = Split(sLine, ",")

                        If arraytext.Count >= 5 Then matricula = Trim(arraytext(5))

                        If arraytext.Length <= 13 Then
                            grasa = -1 : proteina = -1 : lactosa = -1 : st = -1
                            rc = If(IsNumeric(arraytext(11)), arraytext(11), -1)
                            crioscopia = -1 : urea = -1 : proteinav = -1 : caseina = -1 : densidad = -1 : ph = -1
                        Else
                            grasa = ValOrDefault(arraytext(11))
                            proteina = ValOrDefault(arraytext(12))
                            lactosa = ValOrDefault(arraytext(13))
                            st = ValOrDefault(arraytext(14))
                            rc = If(IsNumeric(arraytext(9)), arraytext(9), -1)
                            crioscopia = ValOrDefault(arraytext(15))
                            urea = ValOrDefault(arraytext(16))
                            proteinav = ValOrDefault(arraytext(18))
                            caseina = ValOrDefault(arraytext(19))
                            ph = ValOrDefault(arraytext(22))
                            bhb = ValOrDefault(arraytext(30))
                        End If

                        ficha2 = Mid(nombreArchivo, Len(nombreArchivo) - 21, 1)
                        ficha3 = Mid(nombreArchivo, 1, 1)
                        ficha = If("ABCDEFGHIJKLabcdefghijkL".Contains(ficha2), Mid(nombreArchivo, 1, Len(nombreArchivo) - 22), Mid(nombreArchivo, 1, Len(nombreArchivo) - 21))

                        If ficha.StartsWith("L", StringComparison.OrdinalIgnoreCase) Then
                            ficha3 = ficha.TrimStart("l"c, "L"c)
                        Else
                            ficha3 = ficha
                        End If

                        ' Cargar crioscopia desde tabla si difiere más de 5
                        Dim cc As New dCrioscopia_Control With {.FICHA = ficha3, .MUESTRA = matricula}
                        cc = cc.buscarxfichaxmuestra
                        If cc IsNot Nothing Then
                            Dim diferencia = Math.Abs(cc.DELTA - cc.CRIOSCOPO)
                            If diferencia > 5 Then crioscopia = cc.CRIOSCOPO
                        End If

                        ' Guardar
                        Dim fechaactual As Date = Now()
                        Dim fecha As String = Format(fechaactual, "yyyy-MM-dd")

                        With c
                            .FICHA = ficha3
                            .FECHA = fecha
                            .EQUIPO = "delta"
                            .PRODUCTO = producto
                            .MUESTRA = matricula
                            .RC = rc
                            .GRASA = grasa
                            .PROTEINA = proteina
                            .LACTOSA = lactosa
                            .ST = st
                            .CRIOSCOPIA = crioscopia
                            .UREA = urea
                            .PROTEINAV = proteinav
                            .CASEINA = caseina
                            .DENSIDAD = densidad
                            .PH = ph
                            .BHB = bhb
                            .guardar()
                        End With

                        Dim sa2 As New dSolicitudAnalisis With {.ID = ficha3}
                        sa2.actualizarfechaproceso(fecha)

                        ' Preinforme
                        Dim pi As New dPreinformes With {.FICHA = ficha3}
                        If pi.buscar() Is Nothing Then
                            Dim pi2 As New dPreinformes With {.FICHA = ficha3, .TIPO = 1, .CREADO = 0, .FECHA = fecha}
                            pi2.guardar()
                        End If

                        ' Estado
                        Dim est As New dEstados With {.FICHA = ficha3, .ESTADO = 4, .FECHA = fecha}
                        est.guardar2()
                    End If
                End If
                linea += 1
            Loop Until sLine Is Nothing
            objReader.Close()
        End If

        ' Mover archivo
        'MoverArchivoProcesado(rutaArchivo, nombreArchivo) ' muestra MsgBox

    End Sub

    Private Function ValOrDefault(valor As String) As Double
        If valor Is Nothing OrElse Trim(valor) = "" OrElse valor = "-" Then
            Return -1
        End If
        Try
            Return Convert.ToDouble(valor)
        Catch
            Return -1
        End Try
    End Function

    Private Sub ProcesarArchivoControlXls(rutaArchivo As String, nombreArchivo As String)
        Dim extension As String = Path.GetExtension(nombreArchivo).ToLower().Replace(".", "")
        If extension <> "xls" Then
            Exit Sub
        End If

        Dim matricula As String = ""
        Dim grasa As Double = 0
        Dim proteina As Double = 0
        Dim lactosa As Double = 0
        Dim st As Double = 0
        Dim rc As Integer = 0
        Dim ficha As String = ""
        Dim ficha2 As String = ""
        Dim ficha3 As String = ""
        Dim bandera As Integer = 0

        Try
            Dim Arch As String = Path.Combine(rutaArchivo, nombreArchivo)
            Dim x1app As Microsoft.Office.Interop.Excel.Application = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
            Dim x1libro As Microsoft.Office.Interop.Excel.Workbook = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
            Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

            Dim CantFilas As Integer = x1app.Range("a1").CurrentRegion.Rows.Count

            ficha2 = Mid(nombreArchivo, Len(nombreArchivo) - 4, 1)
            ficha3 = Mid(nombreArchivo, 1, 1)
            If "abcdefghijABCDEFGHIJ".Contains(ficha2) Then
                ficha = Mid(nombreArchivo, 1, Len(nombreArchivo) - 5)
            Else
                ficha = Mid(nombreArchivo, 1, Len(nombreArchivo) - 4)
            End If
            If ficha.StartsWith("l", StringComparison.OrdinalIgnoreCase) Then
                ficha3 = ficha.TrimStart("l"c, "L"c)
            Else
                ficha3 = ficha
            End If

            Dim fecha As String = Format(Now(), "yyyy-MM-dd")

            Dim c As New dImpControl()
            For i As Integer = 1 To CantFilas
                Dim id As String = If(Trim(x1hoja.Cells(i, 1).formula) <> "", Trim(x1hoja.Cells(i, 1).value), "-1")
                matricula = If(Trim(x1hoja.Cells(i, 2).formula) <> "", Trim(x1hoja.Cells(i, 2).value), "-1")

                bandera = 0
                Try
                    grasa = If(Trim(x1hoja.Cells(i, 3).formula) <> "", CDbl(x1hoja.Cells(i, 3).value), -1)
                Catch
                    Continue For
                End Try

                Try
                    proteina = If(Trim(x1hoja.Cells(i, 4).formula) <> "", CDbl(x1hoja.Cells(i, 4).value), -1)
                    bandera = 1
                Catch
                    Continue For
                End Try

                Try
                    lactosa = If(Trim(x1hoja.Cells(i, 5).formula) <> "", CDbl(x1hoja.Cells(i, 5).value), -1)
                Catch
                    Continue For
                End Try

                Try
                    st = If(Trim(x1hoja.Cells(i, 6).formula) <> "", CDbl(x1hoja.Cells(i, 6).value), -1)
                Catch
                    Continue For
                End Try

                Try
                    rc = If(Trim(x1hoja.Cells(i, 7).formula) <> "", CInt(x1hoja.Cells(i, 7).value), -1)
                Catch
                    bandera = 2
                End Try

                ' Guardar según bandera
                If bandera = 0 Then
                    c.FICHA = ficha3
                    c.FECHA = fecha
                    c.EQUIPO = "bentley"
                    c.PRODUCTO = "leche"
                    c.MUESTRA = matricula
                    c.RC = grasa
                    c.GRASA = -1
                    c.PROTEINA = proteina
                    c.LACTOSA = lactosa
                    c.ST = st
                    c.CRIOSCOPIA = -1
                    c.UREA = -1
                    c.PROTEINAV = -1
                    c.CASEINA = -1
                    c.DENSIDAD = -1
                    c.PH = -1
                    c.guardar()

                ElseIf bandera = 1 Then
                    c.FICHA = ficha3
                    c.FECHA = fecha
                    c.EQUIPO = "bentley"
                    c.PRODUCTO = "leche"
                    c.MUESTRA = matricula
                    c.RC = rc
                    c.GRASA = grasa
                    c.PROTEINA = proteina
                    c.LACTOSA = lactosa
                    c.ST = st
                    c.CRIOSCOPIA = -1
                    c.UREA = -1
                    c.PROTEINAV = -1
                    c.CASEINA = -1
                    c.DENSIDAD = -1
                    c.PH = -1
                    c.guardar()

                ElseIf bandera = 2 Then
                    c.FICHA = ficha3
                    c.FECHA = fecha
                    c.EQUIPO = "bentley"
                    c.PRODUCTO = "leche"
                    c.MUESTRA = id
                    c.RC = st
                    c.GRASA = matricula
                    c.PROTEINA = grasa
                    c.LACTOSA = proteina
                    c.ST = lactosa
                    c.CRIOSCOPIA = -1
                    c.UREA = -1
                    c.PROTEINAV = -1
                    c.CASEINA = -1
                    c.DENSIDAD = -1
                    c.PH = -1
                    c.guardar()
                End If

                Dim sa2 As New dSolicitudAnalisis
                sa2.ID = ficha3
                sa2.actualizarfechaproceso(fecha)
                sa2 = Nothing
            Next

            ' Cierro Excel
            x1libro.Close()
            x1app.Quit()
            ReleaseComObject(x1hoja)
            ReleaseComObject(x1libro)
            ReleaseComObject(x1app)

            'MoverArchivoProcesado(rutaArchivo, nombreArchivo) ' muestra MsgBox

            ' Insertar en preinformes
            Dim pi As New dPreinformes
            Dim _fecha As String = Format(Now(), "yyyy-MM-dd")
            pi.FICHA = ficha3
            pi = pi.buscar()
            If pi Is Nothing Then
                Dim pi2 As New dPreinformes
                Dim sa As New dSolicitudAnalisis
                Dim tipof As Integer = 0
                sa.ID = ficha3
                sa = sa.buscar()
                If sa IsNot Nothing Then
                    tipof = sa.IDTIPOINFORME
                End If
                pi2.FICHA = ficha3
                pi2.TIPO = tipof
                pi2.CREADO = 0
                pi2.FECHA = _fecha
                pi2.guardar()
                pi2 = Nothing
                sa = Nothing
            End If
            pi = Nothing

            ' Guardar estado
            Dim est As New dEstados
            est.FICHA = ficha3
            est.ESTADO = 4
            est.FECHA = _fecha
            est.guardar2()
            est = Nothing

        Catch
            ' No hace nada si hay error general
        End Try
    End Sub

    Public Function MoverArchivoProcesado(rutaArchivo As String, nombreArchivo As String) As Boolean
        Try
            Dim sArchivoOrigen As String = Path.Combine(rutaArchivo, nombreArchivo)
            Dim sRutaDestino As String = "\\192.168.1.20\e\Documentos\SECRETARIA\Analisis\Leche\Bentley-delta\Pasados NET\" & nombreArchivo

            My.Computer.FileSystem.MoveFile(sArchivoOrigen, sRutaDestino, True)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub ProcesarArchivos(ruta As String, archivos As List(Of String))
        Dim archivosExitosos As New List(Of String)
        Dim archivosFallidos As New List(Of String)

        For Each archivo In archivos
            If MoverArchivoProcesado(ruta, archivo) Then
                archivosExitosos.Add(archivo)
            Else
                archivosFallidos.Add(archivo)
            End If
        Next

        ' Mostrar resumen
        Dim mensajeFinal As String = "Resumen del procesamiento:" & vbCrLf & vbCrLf
        mensajeFinal &= "✔ Archivos movidos correctamente: " & archivosExitosos.Count & vbCrLf
        If archivosExitosos.Count > 0 Then
            mensajeFinal &= String.Join(vbCrLf, archivosExitosos.ToArray()) & vbCrLf
        End If

        mensajeFinal &= vbCrLf & "❌ Archivos con error: " & archivosFallidos.Count & vbCrLf
        If archivosFallidos.Count > 0 Then
            mensajeFinal &= String.Join(vbCrLf, archivosFallidos.ToArray())
        End If

        MsgBox(mensajeFinal, MsgBoxStyle.Information, "Resultado final")
    End Sub


    ' Método para liberar objetos COM:
    Private Sub ReleaseComObject(ByRef obj As Object)
        Try
            If obj IsNot Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
                obj = Nothing
            End If
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Function IsNullOrWhiteSpace(ByVal value As String) As Boolean
        Return (value Is Nothing) OrElse (value.Trim().Length = 0)
    End Function

    Private Sub ProcesarArchivoCalidadB6Csv(rutaArchivo As String, nombreArchivo As String)
        Dim extension As String = Microsoft.VisualBasic.Right(nombreArchivo, 3)
        Dim linea As Integer = 1

        If extension.ToLower() = "csv" Then
            Dim objReader As New StreamReader(rutaArchivo + "\" + nombreArchivo)
            Dim sLine As String = ""
            Dim arraytext() As String
            Dim matricula As String = ""
            Dim grasa As Double = 0
            Dim proteina As Double = 0
            Dim lactosa As Double = 0
            Dim st As Double = 0
            Dim rc As Integer = 0
            Dim ficha As String = ""
            Dim ficha2 As String = ""
            Dim ficha3 As String = ""
            Dim equipo As String = ""
            Dim producto As String = ""
            Dim crioscopia As Integer = 0
            Dim urea As Integer = 0
            Dim proteinav As Double = 0
            Dim caseina As Double = 0
            Dim densidad As Double = 0
            Dim ph As Double = 0

            Dim c As New dImpCalidad()

            Do
                sLine = objReader.ReadLine()

                If sLine IsNot Nothing AndAlso Trim(sLine) <> "" Then
                    If linea = 3 Then
                        arraytext = Split(sLine, ";")
                        If arraytext.Length < 11 Then
                            arraytext = Split(sLine, ",")
                        End If
                        producto = Trim(arraytext(10))
                    End If

                    If linea >= 7 Then
                        arraytext = Split(sLine, ";")
                        If arraytext.Length < 39 Then
                            arraytext = Split(sLine, ",")
                        End If

                        If arraytext.Length >= 6 Then
                            matricula = Trim(arraytext(5))
                        End If

                        If arraytext.Length <= 13 Then
                            grasa = -1
                            proteina = -1
                            lactosa = -1
                            st = -1
                            If Trim(arraytext(11)) <> "" And Trim(arraytext(11)) <> "-" Then
                                Try
                                    rc = CInt(arraytext(11))
                                Catch ex As Exception
                                    MsgBox("Error en archivo: " & nombreArchivo & ", línea: " & linea)
                                End Try
                            Else
                                rc = -1
                            End If
                            crioscopia = -1
                            urea = -1
                            proteinav = -1
                            caseina = -1
                            densidad = -1
                            ph = -1
                        Else
                            If Trim(arraytext(11)) = "" Or Trim(arraytext(11)) = "-" Then
                                grasa = -1
                            Else
                                Try
                                    grasa = CDbl(arraytext(11))
                                Catch ex As Exception
                                    MsgBox("Error en archivo: " & nombreArchivo & ", línea: " & linea & ", valor: Grasa")
                                    Exit Sub
                                End Try
                            End If

                            If Trim(arraytext(12)) = "" Or Trim(arraytext(12)) = "-" Then
                                proteina = -1
                            Else
                                Try
                                    proteina = CDbl(arraytext(12))
                                Catch ex As Exception
                                    MsgBox("Error en archivo: " & nombreArchivo & ", línea: " & linea & ", valor: Proteína")
                                    Exit Sub
                                End Try
                            End If

                            If Trim(arraytext(13)) = "" Or Trim(arraytext(13)) = "-" Then
                                lactosa = -1
                            Else
                                Try
                                    lactosa = CDbl(arraytext(13))
                                Catch ex As Exception
                                    MsgBox("Error en archivo: " & nombreArchivo & ", línea: " & linea & ", valor: Lactosa")
                                    Exit Sub
                                End Try
                            End If

                            If Trim(arraytext(14)) = "" Or Trim(arraytext(14)) = "-" Then
                                st = -1
                            Else
                                Try
                                    st = CDbl(arraytext(14))
                                Catch ex As Exception
                                    MsgBox("Error en archivo: " & nombreArchivo & ", línea: " & linea & ", valor: Sólidos totales")
                                    Exit Sub
                                End Try
                            End If

                            If Trim(arraytext(9)) = "" Or Trim(arraytext(9)) = "-" Then
                                rc = -1
                            Else
                                Try
                                    rc = CInt(arraytext(9))
                                Catch ex As Exception
                                    MsgBox("Error en archivo: " & nombreArchivo & ", línea: " & linea & ", valor: RC")
                                    Exit Sub
                                End Try
                            End If

                            ' CRIOSCOPIA
                            If Trim(arraytext(15)) = "" Or Trim(arraytext(15)) = "-" Then
                                crioscopia = -1
                            Else
                                Try
                                    crioscopia = CInt(arraytext(15))
                                Catch ex As Exception
                                    MsgBox("Error en archivo: " & nombreArchivo & ", línea: " & linea & ", valor: Crioscopía")
                                    Exit Sub
                                End Try
                            End If

                            If Trim(arraytext(16)) = "" Or Trim(arraytext(16)) = "-" Then
                                urea = -1
                            Else
                                Try
                                    urea = CInt(arraytext(16))
                                Catch ex As Exception
                                    MsgBox("Error en archivo: " & nombreArchivo & ", línea: " & linea & ", valor: Urea")
                                    Exit Sub
                                End Try
                            End If

                            If Trim(arraytext(18)) = "" Or Trim(arraytext(18)) = "-" Then
                                proteinav = -1
                            Else
                                Try
                                    proteinav = CDbl(arraytext(18))
                                Catch ex As Exception
                                    MsgBox("Error en archivo: " & nombreArchivo & ", línea: " & linea & ", valor: Proteína verdadera")
                                    Exit Sub
                                End Try
                            End If

                            If Trim(arraytext(19)) = "" Or Trim(arraytext(19)) = "-" Then
                                caseina = -1
                            Else
                                Try
                                    caseina = CDbl(arraytext(19))
                                Catch ex As Exception
                                    MsgBox("Error en archivo: " & nombreArchivo & ", línea: " & linea & ", valor: Caseína")
                                    Exit Sub
                                End Try
                            End If

                            densidad = -1

                            If arraytext.Length > 22 Then
                                If Trim(arraytext(22)) = "" Or Trim(arraytext(22)) = "-" Then
                                    ph = -1
                                Else
                                    Try
                                        ph = CDbl(arraytext(22))
                                    Catch ex As Exception
                                        MsgBox("Error en archivo: " & nombreArchivo & ", línea: " & linea & ", valor: pH")
                                        Exit Sub
                                    End Try
                                End If
                            End If
                        End If

                        ficha2 = Mid(nombreArchivo, Len(nombreArchivo) - 21, 1)
                        ficha3 = Mid(nombreArchivo, 1, 1)
                        If "abcdefghijkABCDEFGHJK".IndexOf(ficha2) >= 0 Then
                            ficha = Mid(nombreArchivo, 1, Len(nombreArchivo) - 22)
                        Else
                            ficha = Mid(nombreArchivo, 1, Len(nombreArchivo) - 21)
                        End If
                        If Mid(ficha, 1, 1).ToLower() = "l" Then
                            ficha3 = ficha.TrimStart("l"c, "L"c)
                        Else
                            ficha3 = ficha
                        End If

                        ' Control de crioscopia
                        Dim cc As New dCrioscopia_Control
                        Dim ficha_cc As Long = 0
                        Dim muestra_cc As String = ""
                        Dim res_delta As Integer = 0
                        Dim res_crioscopo As Integer = 0
                        Dim diferencia_cc As Integer = 0
                        ficha_cc = ficha3
                        muestra_cc = matricula
                        cc.FICHA = ficha_cc
                        cc.MUESTRA = muestra_cc
                        cc = cc.buscarxfichaxmuestra
                        If Not cc Is Nothing Then
                            res_delta = cc.DELTA
                            res_crioscopo = cc.CRIOSCOPO
                            If res_delta > res_crioscopo Then
                                diferencia_cc = res_delta - res_crioscopo
                            Else
                                diferencia_cc = res_crioscopo - res_delta
                            End If
                            If diferencia_cc > 5 Then
                                crioscopia = res_crioscopo
                            End If
                        End If
                        cc = Nothing

                        Dim fechaoriginal As Date = Now()
                        Dim fecha As String = Format(fechaoriginal, "yyyy-MM-dd")

                        c.FICHA = ficha3
                        c.FECHA = fecha
                        c.EQUIPO = "Bentley600"
                        c.PRODUCTO = producto
                        c.MUESTRA = matricula
                        c.RC = rc
                        c.GRASA = grasa
                        c.PROTEINA = proteina
                        c.LACTOSA = lactosa
                        c.ST = st
                        c.CRIOSCOPIA = crioscopia
                        c.UREA = urea
                        c.PROTEINAV = proteinav
                        c.CASEINA = caseina
                        c.DENSIDAD = densidad
                        c.PH = ph

                        c.guardar()

                        Dim csm As New dCalidadSolicitudMuestra
                        Dim listacsm As New ArrayList
                        Dim noactualizafecha As Integer = 0

                        listacsm = csm.listarporsolicitud(ficha3)
                        If Not listacsm Is Nothing Then
                            For Each csm In listacsm
                                If csm.RB = 1 Then
                                    noactualizafecha = 1
                                End If
                            Next
                        End If

                        If noactualizafecha = 0 Then
                            Dim sa As New dSolicitudAnalisis
                            sa.ID = ficha3
                            sa.actualizarfechaproceso(fecha)
                            sa = Nothing
                        End If
                    End If
                End If
                linea += 1
            Loop Until sLine Is Nothing

            objReader.Close()

            'MoverArchivoProcesado(rutaArchivo, nombreArchivo) ' muestra MsgBox

            ' Insert tabla preinforme_calidad
            Dim pi As New dPreinformes
            Dim fechaactual As Date = Now()
            Dim _fecha As String = Format(fechaactual, "yyyy-MM-dd")
            pi.FICHA = ficha3
            pi = pi.buscar

            If pi Is Nothing Then
                Dim pi2 As New dPreinformes
                Dim sa As New dSolicitudAnalisis
                Dim tipof As Integer = 0
                sa.ID = ficha3
                sa = sa.buscar
                If Not sa Is Nothing Then
                    tipof = sa.IDTIPOINFORME
                End If
                pi2.FICHA = ficha3
                pi2.TIPO = tipof
                pi2.CREADO = 0
                pi2.FECHA = _fecha
                pi2.guardar()
                pi2 = Nothing
                sa = Nothing
            End If

            pi = Nothing

            ' Grabar estado de la ficha
            Dim est As New dEstados
            est.FICHA = ficha3
            est.ESTADO = 4
            est.FECHA = _fecha
            est.guardar2()
            est = Nothing

        End If

    End Sub

    Private Function ParseDoubleSafe(arr() As String, index As Integer) As Double
        If arr.Length > index Then
            Dim result As Double
            If Double.TryParse(arr(index), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, result) Then
                Return result
            End If
        End If
        Return -1 ' Valor por defecto si no puede convertir
    End Function

    Private Function ParseIntSafe(arr() As String, index As Integer) As Integer
        If arr.Length > index Then
            Dim result As Integer
            If Integer.TryParse(arr(index), result) Then
                Return result
            End If
        End If
        Return -1 ' Valor por defecto si no puede convertir
    End Function

    Private Sub ProcesarArchivoControlB6(ByVal rutaArchivo As String, ByVal nombreArchivo As String)
        Dim rutaArchivoOrigen As String = rutaArchivo + "\" + nombreArchivo
        Dim rutaArchivoDestino As String = "\\192.168.1.20\e\Documentos\SECRETARIA\Analisis\Leche\Bentley-delta\Pasados NET\" & nombreArchivo
        Dim extension As String = Path.GetExtension(nombreArchivo).ToLower().Replace(".", "")
        Dim linea As Integer = 1
        Dim ficha3 As String = ""

        If Not File.Exists(rutaArchivoOrigen) Then
            Return
        End If

        If extension = "csv" Then
            Dim objReader As New StreamReader(rutaArchivoOrigen)
            Dim sLine As String = ""
            Dim arraytext() As String
            Dim matricula As String = ""
            Dim grasa As Double = 0
            Dim proteina As Double = 0
            Dim lactosa As Double = 0
            Dim st As Double = 0
            Dim rc As Integer = 0
            Dim ficha As String = ""
            Dim ficha2 As String = ""
            Dim equipo As String = ""
            Dim producto As String = ""
            Dim crioscopia As Integer = 0
            Dim urea As Integer = 0
            Dim proteinav As Double = 0
            Dim caseina As Double = 0
            Dim densidad As Double = 0
            Dim ph As Double = 0
            Dim bhb As Double = 0

            Dim c As New dImpControl()

            Do
                sLine = objReader.ReadLine()
                If sLine <> " " AndAlso Not sLine Is Nothing Then
                    If linea = 3 Then
                        arraytext = Split(sLine, ";")
                        If arraytext.Length < 11 Then
                            arraytext = Split(sLine, ",")
                        End If
                        producto = Trim(arraytext(10))
                    End If

                    If sLine <> ";" AndAlso sLine <> ";;" AndAlso sLine <> ";;;" AndAlso sLine <> ";;;;" AndAlso
                       sLine <> ";;;;;" AndAlso sLine <> ";;;;;;" AndAlso sLine <> ";;;;;;;" AndAlso sLine <> ";;;;;;;;" AndAlso
                       sLine <> ";;;;;;;;;" AndAlso sLine <> ";;;;;;;;;;" AndAlso sLine <> ";;;;;;;;;;;" AndAlso sLine <> ";;;;;;;;;;;;" AndAlso
                       sLine <> ";;;;;;;;;;;;;" AndAlso sLine <> ";;;;;;;;;;;;;;" AndAlso sLine <> ";;;;;;;;;;;;;;;" AndAlso sLine <> ";;;;;;;;;;;;;;;;" AndAlso
                       sLine <> ";;;;;;;;;;;;;;;;;" AndAlso sLine <> ";;;;;;;;;;;;;;;;;;" AndAlso sLine <> ";;;;;;;;;;;;;;;;;;" AndAlso sLine <> ";;;;;;;;;;;;;;;;;;;" AndAlso
                       sLine <> ";;;;;;;;;;;;;;;;;;;;" AndAlso sLine <> ";;;;;;;;;;;;;;;;;;;;;" AndAlso sLine <> ";;;;;;;;;;;;;;;;;;;;;;" AndAlso sLine <> ";;;;;;;;;;;;;;;;;;;;;;;" AndAlso
                       sLine <> ";;;;;;;;;;;;;;;;;;;;;;;;" Then

                        If linea >= 7 Then
                            arraytext = Split(sLine, ";")
                            If arraytext.Length < 39 Then
                                arraytext = Split(sLine, ",")
                            End If

                            matricula = Trim(arraytext(5))

                            Try : grasa = If(Trim(arraytext(11)) = "" Or Trim(arraytext(11)) = "-", -1, CDbl(arraytext(11))) : Catch : grasa = -1 : End Try
                            Try : proteina = If(Trim(arraytext(12)) = "" Or Trim(arraytext(12)) = "-", -1, CDbl(arraytext(12))) : Catch : proteina = -1 : End Try
                            Try : lactosa = If(Trim(arraytext(13)) = "" Or Trim(arraytext(13)) = "-", -1, CDbl(arraytext(13))) : Catch : lactosa = -1 : End Try
                            Try : st = If(Trim(arraytext(14)) = "" Or Trim(arraytext(14)) = "-", -1, CDbl(arraytext(14))) : Catch : st = -1 : End Try
                            Try : rc = If(Trim(arraytext(9)) = "" Or Trim(arraytext(9)) = "-", -1, CInt(arraytext(9))) : Catch : rc = -1 : End Try
                            Try : crioscopia = If(Trim(arraytext(15)) = "" Or Trim(arraytext(15)) = "-", -1, CInt(arraytext(15))) : Catch : crioscopia = -1 : End Try
                            Try : urea = If(Trim(arraytext(16)) = "" Or Trim(arraytext(16)) = "-", -1, CInt(arraytext(16))) : Catch : urea = -1 : End Try
                            Try : proteinav = If(Trim(arraytext(18)) = "" Or Trim(arraytext(18)) = "-", -1, CDbl(arraytext(18))) : Catch : proteinav = -1 : End Try
                            Try : caseina = If(Trim(arraytext(19)) = "" Or Trim(arraytext(19)) = "-", -1, CDbl(arraytext(19))) : Catch : caseina = -1 : End Try
                            densidad = -1
                            Try : ph = If(Trim(arraytext(22)) = "" Or Trim(arraytext(22)) = "-", -1, CDbl(arraytext(22))) : Catch : ph = -1 : End Try
                            Try : bhb = If(Trim(arraytext(30)) = "" Or Trim(arraytext(30)) = "-", -1, CDbl(arraytext(30))) : Catch : bhb = -1 : End Try

                            ficha2 = Mid(nombreArchivo, Len(nombreArchivo) - 21, 1)
                            ficha3 = Mid(nombreArchivo, 1, 1)

                            If "abcdefghijkABCDEFGHIJK".IndexOf(ficha2) >= 0 Then
                                ficha = Mid(nombreArchivo, 1, Len(nombreArchivo) - 22)
                            Else
                                ficha = Mid(nombreArchivo, 1, Len(nombreArchivo) - 21)
                            End If

                            If Mid(ficha, 1, 1).ToLower() = "l" Then
                                Dim MyString As String = ficha
                                Dim MyChar As Char() = {"l"c, "L"c}
                                Dim NewString As String = MyString.TrimStart(MyChar)
                                ficha3 = NewString
                            Else
                                ficha3 = ficha
                            End If

                            Dim cc As New dCrioscopia_Control
                            cc.FICHA = ficha3
                            cc.MUESTRA = matricula
                            cc = cc.buscarxfichaxmuestra

                            If Not cc Is Nothing Then
                                Dim res_delta As Integer = cc.DELTA
                                Dim res_crioscopo As Integer = cc.CRIOSCOPO
                                Dim diferencia_cc As Integer = Math.Abs(res_delta - res_crioscopo)
                                If diferencia_cc > 5 Then
                                    crioscopia = res_crioscopo
                                End If
                            End If
                            cc = Nothing

                            Dim fechaoriginal As Date = Now()
                            Dim fecha As String = Format(fechaoriginal, "yyyy-MM-dd")
                            c.FICHA = ficha3
                            c.FECHA = fecha
                            c.EQUIPO = "B6"
                            c.PRODUCTO = producto
                            c.MUESTRA = matricula
                            c.RC = rc
                            c.GRASA = grasa
                            c.PROTEINA = proteina
                            c.LACTOSA = lactosa
                            c.ST = st
                            c.CRIOSCOPIA = crioscopia
                            c.UREA = urea
                            c.PROTEINAV = proteinav
                            c.CASEINA = caseina
                            c.DENSIDAD = densidad
                            c.PH = ph
                            c.BHB = bhb
                            c.guardar()

                            Dim sa2 As New dSolicitudAnalisis
                            sa2.ID = ficha3
                            sa2.actualizarfechaproceso(fecha)
                            sa2 = Nothing
                        End If
                    End If
                End If
                linea += 1
            Loop Until sLine Is Nothing
            objReader.Close()

            'MoverArchivoProcesado(rutaArchivo, nombreArchivo) ' muestra MsgBox

            Dim pi As New dPreinformes
            Dim fechaactual As Date = Now()
            Dim _fecha As String = Format(fechaactual, "yyyy-MM-dd")
            pi.FICHA = ficha3
            pi = pi.buscar
            If pi Is Nothing Then
                Dim pi2 As New dPreinformes
                pi2.FICHA = ficha3
                pi2.TIPO = 1
                pi2.CREADO = 0
                pi2.FECHA = _fecha
                pi2.guardar()
                pi2 = Nothing
            End If
            pi = Nothing

            Dim est As New dEstados
            est.FICHA = ficha3
            est.ESTADO = 4
            est.FECHA = _fecha
            est.guardar2()
            est = Nothing

        End If
    End Sub

    Public Sub RestablecerEstadoFicha(ByVal ficha As String, ByVal tipoInforme As String)
        ' Eliminar registros según tipo de informe
        If tipoInforme.ToUpper() = "CONTROL LECHERO" Then
            Dim c As New dControl()
            c.FICHA = ficha
            c.eliminarxficha()
        ElseIf tipoInforme.ToUpper() = "CALIDAD" Then
            Dim cal As New dCalidad()
            cal.FICHA = ficha
            cal.eliminarxficha()
        End If

        ' Actualizar preinformes: creado = 0
        Dim pi As New dPreinformes()
        pi.FICHA = ficha
        pi = pi.buscar()
        If pi IsNot Nothing Then
            pi.CREADO = 0
            pi.modificar()
        End If
    End Sub

    Private Function VerificarDatosCalidad(ficha As Long) As Boolean
        Dim csm As New dCalidadSolicitudMuestra
        Dim listacsm As New ArrayList
        Dim creapreinforme As Boolean = True

        listacsm = csm.listarporsolicitud(ficha)
        If listacsm Is Nothing OrElse listacsm.Count = 0 Then Return False

        For Each csm In listacsm
            If csm.RB = 1 Then
                Dim ibc As New dIbc
                ibc.FICHA = csm.FICHA
                ibc.MUESTRA = csm.MUESTRA
                ibc = ibc.buscarxfichaxmuestra
                If ibc Is Nothing Then Return False
            End If

            If csm.PSICROTROFOS = 1 Then
                Dim psi As New dPsicrotrofos
                psi.FICHA = csm.FICHA
                psi.MUESTRA = csm.MUESTRA
                psi = psi.buscarxfichaxmuestra
                If psi Is Nothing Then Return False
            End If

            If csm.ESPORULADOS = 1 Then
                Dim esp As New dEsporulados
                esp.FICHA = csm.FICHA
                esp.MUESTRA = csm.MUESTRA
                esp = esp.buscarxfichaxmuestra
                If esp Is Nothing Then Return False
            End If

            If csm.INHIBIDORES = 1 Then
                Dim inh As New dInhibidores
                inh.FICHA = csm.FICHA
                inh.MUESTRA = csm.MUESTRA
                inh = inh.buscarxfichaxmuestra
                If inh Is Nothing Or inh.MARCA = 0 Then Return False
            End If
        Next

        Return creapreinforme
    End Function

    Private Sub GenerarExcelCalidad(archivo As ArchivoSeleccionado)

        Dim idsol As Long = ficha
        Dim lista As New ArrayList()

        ' Aquí armás la lista igual que antes, por ejemplo:
        Dim csm As New dCalidadSolicitudMuestra
        lista = csm.listarporsolicitud(idsol)

        If lista Is Nothing OrElse lista.Count = 0 Then
            MsgBox("No hay datos para generar el preinforme de calidad para la ficha: " & idsol)
            Return
        End If

        Dim x1app As New Excel.Application
        Dim x1libro As Excel.Workbook = x1app.Workbooks.Add
        Dim x1hoja As Excel.Worksheet = x1libro.Sheets(1)
        Dim fila As Integer = 2
        Dim columna As Integer = 1
        Try
            If Not lista Is Nothing AndAlso lista.Count > 0 Then
                For Each csm In lista
                    Dim c As New dCalidad With {.FICHA = idsol, .MUESTRA = Trim(csm.MUESTRA)}
                    c = c.buscarxfichaxmuestra()

                    ' Muestra
                    EscribirCelda(x1hoja, fila, columna, If(csm.MUESTRA <> "", csm.MUESTRA, "-")) : columna += 1

                    ' RC
                    If csm.RC = 1 AndAlso Not c Is Nothing Then
                        EscribirCelda(x1hoja, fila, columna, c.RC) : columna += 1
                    Else
                        EscribirNA(x1hoja, fila, columna) : columna += 1
                    End If

                    ' RB
                    If csm.RB = 1 Then
                        Dim ibc As New dIbc With {.FICHA = idsol, .MUESTRA = Trim(csm.MUESTRA)}
                        ibc = ibc.buscarxfichaxmuestra()
                        EscribirCelda(x1hoja, fila, columna, If(ibc IsNot Nothing, ibc.RB.ToString(), "-")) : columna += 1
                    Else
                        EscribirNA(x1hoja, fila, columna) : columna += 1
                    End If

                    ' Composición: GRASA, PROTEINA, LACTOSA, ST
                    If csm.COMPOSICION = 1 OrElse csm.COMPOSICIONSUERO = 1 Then
                        ' GRASA
                        Dim fueraRangoGrasa = Not c Is Nothing AndAlso (Val(c.GRASA) < 2.5 Or Val(c.GRASA) > 5)
                        EscribirCeldaConFondo(x1hoja, fila, columna, If(Not c Is Nothing, c.GRASA.ToString("##,##0.00"), "-"), fueraRangoGrasa) : columna += 1

                        ' PROTEINA
                        Dim fueraRangoProteina = Not c Is Nothing AndAlso (Val(c.PROTEINA) < 2.5 Or Val(c.PROTEINA) > 4)
                        EscribirCeldaConFondo(x1hoja, fila, columna, If(Not c Is Nothing, c.PROTEINA.ToString("##,##0.00"), "-"), fueraRangoProteina) : columna += 1

                        ' LACTOSA
                        EscribirCelda(x1hoja, fila, columna, If(Not c Is Nothing, c.LACTOSA.ToString("##,##0.00"), "-")) : columna += 1

                        ' ST
                        EscribirCelda(x1hoja, fila, columna, If(Not c Is Nothing, c.ST.ToString("##,##0.00"), "-")) : columna += 1
                    Else
                        For i = 1 To 4
                            EscribirNA(x1hoja, fila, columna) : columna += 1
                        Next
                    End If

                    ' CRIOSCOPIA
                    If (csm.CRIOSCOPIA = 1 OrElse csm.CRIOSCOPIA_CRIOSCOPO = 1) AndAlso Not c Is Nothing AndAlso c.CRIOSCOPIA <> -1 Then
                        Dim valcrio As Double = Val(c.CRIOSCOPIA) * -1 / 1000
                        Dim fueraRangoCrio = (valcrio > -0.512 And valcrio < 0)
                        EscribirCeldaConFondo(x1hoja, fila, columna, valcrio.ToString("##,###0.000"), fueraRangoCrio)
                    Else
                        EscribirNA(x1hoja, fila, columna)
                    End If
                    columna += 1

                    ' UREA
                    If csm.UREA = 1 AndAlso Not c Is Nothing AndAlso c.UREA <> -1 Then
                        Dim valorurea As Double = If(c.EQUIPO = "Bentley600", c.UREA, c.UREA * 0.466)
                        Dim fueraRangoUrea = (valorurea > 20 Or valorurea < 9)
                        EscribirCeldaConFondo(x1hoja, fila, columna, valorurea.ToString("##,##0.00"), fueraRangoUrea)
                    Else
                        EscribirNA(x1hoja, fila, columna)
                    End If
                    columna += 1

                    ' INHIBIDORES
                    Dim inh As New dInhibidores With {.FICHA = idsol, .MUESTRA = Trim(csm.MUESTRA)}
                    inh = inh.buscarxfichaxmuestra()
                    Dim resultadoInh As String = If(inh IsNot Nothing, If(inh.RESULTADO = 0, "Negativo", "Positivo"), "-")
                    EscribirCelda(x1hoja, fila, columna, resultadoInh) : columna += 1

                    ' ESPORULADOS
                    Dim esp As New dEsporulados With {.FICHA = idsol, .MUESTRA = Trim(csm.MUESTRA)}
                    esp = esp.buscarxfichaxmuestra()
                    EscribirCelda(x1hoja, fila, columna, If(esp IsNot Nothing, esp.RESULTADO.ToString(), "-")) : columna += 1

                    ' PSICROTROFOS
                    Dim psi As New dPsicrotrofos With {.FICHA = idsol, .MUESTRA = Trim(csm.MUESTRA)}
                    psi = psi.buscarxfichaxmuestra()
                    EscribirCelda(x1hoja, fila, columna, If(psi IsNot Nothing, psi.PROMEDIO.ToString(), "-")) : columna += 1

                    ' CASEINA
                    If csm.CASEINA = 1 AndAlso Not c Is Nothing AndAlso c.CASEINA <> -1 Then
                        EscribirCelda(x1hoja, fila, columna, c.CASEINA) : columna += 1
                    Else
                        EscribirNA(x1hoja, fila, columna) : columna += 1
                    End If

                    ' AFLATOXINA M1
                    Dim m As New dMicotoxinasLeche With {.FICHA = idsol, .MUESTRA = Trim(csm.MUESTRA)}
                    m = m.buscarxfichaxmuestra()
                    EscribirCelda(x1hoja, fila, columna, If(m IsNot Nothing, m.RESULTADO.ToString(), "-"))

                    ' Reinicio
                    columna = 1
                    fila += 1
                Next
            End If

            ' Pie de página y guardado
            x1hoja.PageSetup.CenterFooter = "Página &P"
            x1app.DisplayAlerts = False
            x1hoja.SaveAs("\\ROBOT\preinformes\CALIDAD\" & idsol & ".xls")

            ' Marcar como creado
            Dim preinf As New dPreinformes With {.FICHA = idsol}
            preinf.marcarcreado()

            ' Limpieza
            x1app.Visible = False
            x1libro.Close()
            x1app.Quit()
            System.Runtime.InteropServices.Marshal.ReleaseComObject(x1hoja)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(x1libro)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(x1app)
            x1hoja = Nothing : x1libro = Nothing : x1app = Nothing

            creartxt2(idsol)

            ' Cierra procesos Excel
            For Each opro As Process In Process.GetProcessesByName("EXCEL")
                opro.Kill()
            Next
        Catch ex As Exception
        Finally
            ' Liberar recursos COM
            If x1hoja IsNot Nothing Then
                Marshal.ReleaseComObject(x1hoja)
                x1hoja = Nothing
            End If
            If x1libro IsNot Nothing Then
                x1libro.Close(False)
                Marshal.ReleaseComObject(x1libro)
                x1libro = Nothing
            End If
            If x1app IsNot Nothing Then
                x1app.Quit()
                Marshal.ReleaseComObject(x1app)
                x1app = Nothing
            End If

            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Sub

    Private Sub creartxt2(ByVal idsol As Long)
        Dim sa As New dSolicitudAnalisis
        sa.ID = idsol
        sa = sa.buscar
        If sa.IDPRODUCTOR = 6299 Or sa.IDPRODUCTOR = 2705 Then
            Dim idficha As Long = idsol
            Dim oSW As New StreamWriter("\\192.168.1.10\e\NET\CALIDAD\" & idficha & ".txt")
            Dim oSW2 As New StreamWriter("\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".txt")
            Dim csm As New dCalidadSolicitudMuestra
            Dim lista As New ArrayList
            lista = csm.listarporsolicitud(idficha)
            Dim s As New dSolicitudAnalisis
            s.ID = idficha
            s = s.buscar
            Dim fecha As String = ""
            If Not s Is Nothing Then
                fecha = s.FECHAINGRESO
            End If
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    Dim Linea As String = ""
                    Linea = ""
                    For Each csm In lista
                        Dim c As New dCalidad
                        Dim finmatricula As String = ""
                        Dim matricula As String = ""
                        Dim largocadena As String = ""
                        c.FICHA = idficha
                        c.MUESTRA = Trim(csm.MUESTRA)
                        c = c.buscarxfichaxmuestra
                        If Not c Is Nothing Then
                            largocadena = c.MUESTRA
                            If largocadena.Length > 1 Then
                                finmatricula = Mid(c.MUESTRA, Len(c.MUESTRA) - 1, 2)
                            End If
                        Else
                            largocadena = Trim(csm.MUESTRA)
                            If largocadena.Length > 1 Then
                                finmatricula = Mid(csm.MUESTRA, Len(csm.MUESTRA) - 1, 2)
                            End If
                        End If
                        'If finmatricula = "T1" Or finmatricula = "T2" Or finmatricula = "T3" Or finmatricula = "T4" Or finmatricula = "T5" Or finmatricula = "T6" Or finmatricula = "T7" Or finmatricula = "T8" Or finmatricula = "T9" Or finmatricula = "t1" Or finmatricula = "t2" Or finmatricula = "t3" Or finmatricula = "t4" Or finmatricula = "t5" Or finmatricula = "t6" Or finmatricula = "t7" Or finmatricula = "t8" Or finmatricula = "t9" Then
                        '    matricula = Mid(csm.MUESTRA, 1, Len(csm.MUESTRA) - 2)
                        'Else
                        '    If Not c Is Nothing Then
                        '        matricula = c.MUESTRA
                        '    Else
                        matricula = csm.MUESTRA
                        '    End If
                        'End If
                        If matricula <> "" Then
                            Linea = Linea & matricula & ";"
                        Else
                            Linea = Linea & "-" & ";"
                        End If
                        Dim ibc As New dIbc
                        ibc.FICHA = idficha
                        If Not c Is Nothing Then
                            ibc.MUESTRA = Trim(c.MUESTRA)
                        Else
                            ibc.MUESTRA = Trim(csm.MUESTRA)
                        End If
                        ibc = ibc.buscarxfichaxmuestra
                        If csm.RB = 1 Then
                            If Not ibc Is Nothing Then
                                If ibc.RB <> -1 Then
                                    Linea = Linea & ibc.RB & ";"
                                Else
                                    Linea = Linea & "-" & ";"
                                End If
                            Else
                                Linea = Linea & "-" & ";"
                            End If
                        Else
                            Linea = Linea & "-" & ";"
                        End If
                        ibc = Nothing
                        If csm.RC = 1 Then
                            If Not c Is Nothing Then
                                If c.RC <> -1 Then
                                    Linea = Linea & c.RC & ";"
                                Else
                                    Linea = Linea & "-" & ";"
                                End If
                            Else
                                Linea = Linea & "-" & ";"
                            End If
                        Else
                            Linea = Linea & "-" & ";"
                        End If
                        If csm.COMPOSICION = 1 Then
                            If Not c Is Nothing Then
                                If c.GRASA <> -1 Then
                                    Linea = Linea & c.GRASA & "; " & c.PROTEINA & "; " & c.LACTOSA & "; " & c.ST & "; " & "-0." & c.CRIOSCOPIA
                                Else
                                    Linea = Linea & "-" & ";" & "-" & ";" & "-" & ";" & "-" & ";" & "-"
                                End If
                            Else
                                Linea = Linea & "-" & ";" & "-" & ";" & "-" & ";" & "-" & ";" & "-"
                            End If
                        Else
                            Linea = Linea & "-" & ";" & "-" & ";" & "-" & ";" & "-" & ";" & "-"
                        End If
                        oSW.WriteLine(Linea)
                        oSW2.WriteLine(Linea)
                        Linea = ""
                    Next
                End If
            End If
            oSW.Flush()
            oSW2.Flush()
        End If
    End Sub

    Private Sub EscribirCelda(ByRef hoja As Excel.Worksheet, ByVal fila As Integer, ByVal columna As Integer, ByVal valor As Object, Optional ByVal tamañoFuente As Integer = 8)
        hoja.Cells(fila, columna).Formula = valor
        hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        hoja.Cells(fila, columna).Font.Size = tamañoFuente
    End Sub
    Private Sub EscribirConColor(ByRef hoja As Excel.Worksheet, ByVal fila As Integer, ByVal columna As Integer, ByVal valor As Object, ByVal min As Double, ByVal max As Double, ByVal formato As String)
        If valor IsNot Nothing Then
            Dim dval As Double = Val(valor)
            If dval < min Or dval > max Then
                hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            End If
            hoja.Cells(fila, columna).Formula = dval.ToString(formato)
        Else
            hoja.Cells(fila, columna).Formula = "-"
        End If
        hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        hoja.Cells(fila, columna).Font.Size = 8
    End Sub
    Private Sub EscribirCeldaConFondo(ByRef hoja As Excel.Worksheet, fila As Integer, columna As Integer, valor As String, fueraDeRango As Boolean)
        hoja.Cells(fila, columna).Formula = valor
        hoja.Cells(fila, columna).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja.Cells(fila, columna).Font.Size = 8
        If fueraDeRango Then
            hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        End If
    End Sub

    Private Sub EscribirNA(ByRef hoja As Excel.Worksheet, fila As Integer, columna As Integer)
        hoja.Cells(fila, columna).Formula = "-"
        hoja.Cells(fila, columna).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        hoja.Cells(fila, columna).Font.Size = 8
    End Sub

    Public Sub PrepararYGenerarExcelControl(idficha As Long)
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim bhb As Integer = 0

        ' Obtener resultados del control lechero por ficha
        Dim c As New dControl
        lista = c.listarporsolicitud(idficha)

        ' Obtener resultados ordenados por RC
        lista2 = c.listarporrc(idficha)

        ' Verificar si tiene BHB asociado
        Dim na As New dNuevoAnalisis
        Dim tieneBhb As Boolean = False
        Dim analisisLista As ArrayList = na.listarporficha2(idficha)
        If Not analisisLista Is Nothing Then
            For Each a As dNuevoAnalisis In analisisLista
                If a.ANALISIS = 158 Then
                    bhb = 1
                    Exit For
                End If
            Next
        End If

    End Sub

End Class