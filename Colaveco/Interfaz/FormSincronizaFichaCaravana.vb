Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System
Imports System.IO
Imports System.Collections
Public Class FormSincronizaFichaCaravana
    Private _usuario As dUsuario
    Dim id_sol As Long = 0
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Label3.Text = ""
    End Sub
#End Region

    Private Sub ButtonSeleccionarArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSeleccionarArchivo.Click
        Dim fichero As String
        Dim dlAbrir As New System.Windows.Forms.OpenFileDialog

        dlAbrir.Filter = "Archivos de Excel (*.xls)|*.xls|" & _
            "Archivos de log (*.log)|*.log|" & _
            "Todos los archivos (*.*)|*.*"
        dlAbrir.Multiselect = False
        dlAbrir.CheckFileExists = False
        dlAbrir.Title = "Selección de fichero"
        dlAbrir.ShowDialog()
        If dlAbrir.FileName <> "" Then
            fichero = dlAbrir.FileName
            TextArchivo.Text = fichero
        End If
    End Sub

    Private Sub ButtonSincronizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSincronizar.Click
        'sincronizarcaravanas()
        actualizarcaravanas()
        preinforme_control(id_sol)
    End Sub
    Private Sub actualizarcaravanas()
        Label3.Text = ""
        If TextFicha.Text.Trim.Length = 0 Then MsgBox("Ingrese el número de ficha.", MsgBoxStyle.Exclamation, "Atención") : TextFicha.Focus() : Exit Sub
        If TextArchivo.Text.Trim.Length = 0 Then MsgBox("Seleccione el archivo excel a procesar.", MsgBoxStyle.Exclamation, "Atención") : TextArchivo.Focus() : Exit Sub
        Dim ficha As String = ""
        ficha = TextFicha.Text.Trim
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        Dim ruta As String = TextArchivo.Text.Trim
        linea = 1
        Dim objReader As New StreamReader(ruta)
        Dim sLine As String = ""
        Dim numero As String = ""
        Dim caravana As String = ""

        Dim c As New dCaravanas
        Dim c2 As New dCaravanas
        c2.FICHA = ficha
        c2.eliminarxficha(Usuario)
        Dim Arch As String, CantFilas As Integer
        Arch = ruta
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        Dim bandera As Integer = 0
        CantFilas = x1app.Range("a1").CurrentRegion.Rows.Count
        For i = 1 To CantFilas
            If Trim(x1hoja.Cells(i, 1).formula) <> "" Then
                numero = x1hoja.Cells(i, 1).value
            End If
            If Trim(x1hoja.Cells(i, 2).formula) <> "" Then
                caravana = x1hoja.Cells(i, 2).value
            End If

            id_sol = ficha
            c.FICHA = ficha
            c.NUMERO = numero
            c.CARAVANA = caravana
            c.guardar(Usuario)
        Next
        c = Nothing
        ' Cierro Excel
        x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
        objReader.Close()

        Dim proceso As System.Diagnostics.Process()
        proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")
        For Each opro As System.Diagnostics.Process In proceso
            'antes de iniciar el proceso obtengo la fecha en que inicie el 
            'proceso para detener todos los procesos que excel que inicio
            'mi código durante el proceso
            opro.Kill()
        Next

        Dim ca As New dCaravanas
        Dim lista As New ArrayList
        lista = ca.listarxficha(ficha)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each ca In lista
                    Dim co As New dControl
                    co.modificar2(ca.FICHA, ca.NUMERO, ca.CARAVANA)
                    co = Nothing
                Next
            End If
        End If
       
    End Sub
    'Private Sub preinforme_control(ByVal id_sol As Long)
    '    Dim x1app As Microsoft.Office.Interop.Excel.Application
    '    Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
    '    Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
    '    x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
    '    x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
    '    x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
    '    Dim c As New dControl
    '    Dim i As New dIbc
    '    Dim sa As New dSolicitudAnalisis
    '    Dim pro As New dCliente
    '    Dim tec As New dTecnicos
    '    Dim lista As New ArrayList
    '    Dim lista2 As New ArrayList
    '    Dim lista3 As New ArrayList
    '    '*****************************
    '    Dim idsol As Long = id_sol 'ficha
    '    sa.ID = idsol
    '    sa = sa.buscar
    '    Dim fila As Integer
    '    Dim columna As Integer
    '    fila = 1
    '    columna = 2

    '    '*** ENCABEZADO ********************************************************************************
    '    '***********************************************************************************************

    '    x1hoja.Cells(1, 1).columnwidth = 5
    '    x1hoja.Cells(1, 2).columnwidth = 5
    '    x1hoja.Cells(1, 3).columnwidth = 5
    '    x1hoja.Cells(1, 4).columnwidth = 5
    '    x1hoja.Cells(1, 5).columnwidth = 5
    '    x1hoja.Cells(1, 6).columnwidth = 5
    '    x1hoja.Cells(1, 7).columnwidth = 5
    '    x1hoja.Cells(1, 8).columnwidth = 3
    '    x1hoja.Cells(1, 9).columnwidth = 5
    '    x1hoja.Cells(1, 10).columnwidth = 5
    '    x1hoja.Cells(1, 11).columnwidth = 5
    '    x1hoja.Cells(1, 12).columnwidth = 5
    '    x1hoja.Cells(1, 13).columnwidth = 5
    '    x1hoja.Cells(1, 14).columnwidth = 5
    '    x1hoja.Cells(1, 15).columnwidth = 5
    '    x1hoja.Range("A1", "D1").Merge()

    '    fila = 15
    '    columna = 1
    '    '*** FIN DEL ENCABEZADO ***********************************************************************************
    '    '**********************************************************************************************************
    '    lista = c.listarporsolicitud(idsol)
    '    lista2 = c.listarporrc(idsol)

    '    x1hoja.Cells(fila, columna).Formula = "Listado ordenado por identificación"
    '    x1hoja.Cells(fila, columna).Font.Bold = True
    '    x1hoja.Cells(fila, columna).Font.Size = 8
    '    columna = columna + 7
    '    x1hoja.Cells(fila, columna).Formula = "Listado ordenado decreciente por Recuento celular"
    '    x1hoja.Cells(fila, columna).Font.Bold = True
    '    x1hoja.Cells(fila, columna).Font.Size = 8
    '    fila = fila + 1
    '    columna = 1
    '    Dim filaguia As Integer = fila
    '    x1hoja.Cells(fila, columna).Formula = "Ident."
    '    x1hoja.Cells(fila, columna).Font.Bold = True
    '    x1hoja.Cells(fila, columna).Font.Size = 8
    '    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
    '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
    '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '    columna = columna + 1
    '    x1hoja.Cells(fila, columna).Formula = "Rc"
    '    x1hoja.Cells(fila, columna).Font.Bold = True
    '    x1hoja.Cells(fila, columna).Font.Size = 8
    '    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
    '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
    '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '    columna = columna + 1
    '    x1hoja.Cells(fila, columna).Formula = "Gr"
    '    x1hoja.Cells(fila, columna).Font.Bold = True
    '    x1hoja.Cells(fila, columna).Font.Size = 8
    '    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
    '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
    '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '    columna = columna + 1
    '    x1hoja.Cells(fila, columna).Formula = "Pr"
    '    x1hoja.Cells(fila, columna).Font.Bold = True
    '    x1hoja.Cells(fila, columna).Font.Size = 8
    '    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
    '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
    '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '    columna = columna + 1
    '    x1hoja.Cells(fila, columna).Formula = "Lc*"
    '    x1hoja.Cells(fila, columna).Font.Bold = True
    '    x1hoja.Cells(fila, columna).Font.Size = 8
    '    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
    '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
    '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '    columna = columna + 1
    '    x1hoja.Cells(fila, columna).Formula = "MUN*"
    '    x1hoja.Cells(fila, columna).Font.Bold = True
    '    x1hoja.Cells(fila, columna).Font.Size = 8
    '    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
    '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
    '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '    columna = columna + 1
    '    x1hoja.Cells(fila, columna).Formula = "Caseina*"
    '    x1hoja.Cells(fila, columna).Font.Bold = True
    '    x1hoja.Cells(fila, columna).Font.Size = 6
    '    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
    '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
    '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '    columna = 1
    '    fila = fila + 1
    '    If Not lista Is Nothing Then
    '        If lista.Count > 0 Then
    '            For Each c In lista
    '                If c.MUESTRA <> "" Then
    '                    x1hoja.Cells(fila, columna).formula = Trim(c.MUESTRA)
    '                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                    x1hoja.Cells(fila, columna).Font.Size = 8
    '                    columna = columna + 1
    '                Else
    '                    x1hoja.Cells(fila, columna).formula = "-"
    '                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                    x1hoja.Cells(fila, columna).Font.Size = 8
    '                    columna = columna + 1
    '                End If
    '                If c.RC = -1 Then
    '                    x1hoja.Cells(fila, columna).formula = ""
    '                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                    x1hoja.Cells(fila, columna).Font.Size = 8
    '                    columna = columna + 1
    '                Else
    '                    If c.RC < 30 Then
    '                        x1hoja.Cells(fila, columna).formula = "30"
    '                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                        x1hoja.Cells(fila, columna).Font.Size = 8
    '                        columna = columna + 1
    '                    Else
    '                        x1hoja.Cells(fila, columna).formula = c.RC
    '                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                        x1hoja.Cells(fila, columna).Font.Size = 8
    '                        columna = columna + 1
    '                    End If
    '                End If
    '                If c.GRASA = -1 Or c.GRASA = 0 Then
    '                    columna = columna - 1
    '                    x1hoja.Cells(fila, columna).formula = ""
    '                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                    x1hoja.Cells(fila, columna).Font.Size = 8
    '                    columna = columna + 1

    '                    x1hoja.Cells(fila, columna).formula = "MUESTRA NO APTA **"
    '                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                    x1hoja.Cells(fila, columna).Font.Size = 8
    '                    columna = columna + 1
    '                Else
    '                    Dim valgrasa = Val(c.GRASA)
    '                    If valgrasa < 2 Or valgrasa > 5.5 Then
    '                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
    '                    End If
    '                    x1hoja.Cells(fila, columna).formula = c.GRASA
    '                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                    x1hoja.Cells(fila, columna).Font.Size = 8
    '                    columna = columna + 1
    '                End If
    '                If c.PROTEINA = -1 Or c.PROTEINA = 0 Then
    '                    x1hoja.Cells(fila, columna).formula = ""
    '                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                    x1hoja.Cells(fila, columna).Font.Size = 8
    '                    columna = columna + 1
    '                Else
    '                    Dim valproteina = Val(c.PROTEINA)
    '                    If valproteina < 2 Or valproteina > 4.5 Then
    '                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
    '                    End If
    '                    x1hoja.Cells(fila, columna).formula = c.PROTEINA
    '                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                    x1hoja.Cells(fila, columna).Font.Size = 8
    '                    columna = columna + 1
    '                End If
    '                If c.LACTOSA = -1 Or c.LACTOSA = 0 Then
    '                    x1hoja.Cells(fila, columna).formula = ""
    '                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                    x1hoja.Cells(fila, columna).Font.Size = 8
    '                    columna = columna + 1
    '                Else
    '                    x1hoja.Cells(fila, columna).formula = c.LACTOSA
    '                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                    x1hoja.Cells(fila, columna).Font.Size = 8
    '                    columna = columna + 1
    '                End If
    '                Dim cs As New dControlSolicitud
    '                cs.FICHA = idsol
    '                cs = cs.buscar
    '                If Not cs Is Nothing Then
    '                    If cs.UREA = 1 Then
    '                        If c.UREA = -1 Or c.UREA = 0 Then
    '                            x1hoja.Cells(fila, columna).formula = "-"
    '                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                            x1hoja.Cells(fila, columna).Font.Size = 8
    '                            columna = columna + 1
    '                        Else
    '                            Dim valorurea As Integer
    '                            valorurea = c.UREA * 0.466
    '                            x1hoja.Cells(fila, columna).formula = FormatNumber(valorurea, 0)
    '                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                            x1hoja.Cells(fila, columna).Font.Size = 8
    '                            columna = columna + 1
    '                        End If
    '                    Else
    '                        x1hoja.Cells(fila, columna).formula = "-"
    '                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                        x1hoja.Cells(fila, columna).Font.Size = 8
    '                        columna = columna + 1
    '                    End If
    '                    If cs.CASEINA = 1 Then
    '                        If c.CASEINA = -1 Or c.UREA = 0 Then
    '                            x1hoja.Cells(fila, columna).formula = "-"
    '                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                            x1hoja.Cells(fila, columna).Font.Size = 8
    '                            columna = columna + 1
    '                        Else
    '                            x1hoja.Cells(fila, columna).formula = c.CASEINA
    '                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                            x1hoja.Cells(fila, columna).Font.Size = 8
    '                            columna = columna + 1
    '                        End If
    '                    Else
    '                        x1hoja.Cells(fila, columna).formula = "-"
    '                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                        x1hoja.Cells(fila, columna).Font.Size = 8
    '                        columna = columna + 1
    '                    End If
    '                Else
    '                    x1hoja.Cells(fila, columna).formula = "-"
    '                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                    x1hoja.Cells(fila, columna).Font.Size = 8
    '                    columna = columna + 1
    '                End If
    '                cs = Nothing
    '                columna = 1
    '                fila = fila + 1
    '            Next
    '            'Referencias
    '            fila = fila + 1
    '            columna = 1
    '        End If
    '        '****** ORDENADO POR RC ************************************************************************
    '        Dim libreinfeccion As Integer = 0
    '        Dim posibleinfeccion As Integer = 0
    '        Dim probableinfeccion As Integer = 0
    '        fila = filaguia
    '        columna = 9
    '        x1hoja.Cells(fila, columna).Formula = "Ident."
    '        x1hoja.Cells(fila, columna).Font.Bold = True
    '        x1hoja.Cells(fila, columna).Font.Size = 8
    '        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
    '        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
    '        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '        columna = columna + 1
    '        x1hoja.Cells(fila, columna).Formula = "Rc"
    '        x1hoja.Cells(fila, columna).Font.Bold = True
    '        x1hoja.Cells(fila, columna).Font.Size = 8
    '        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
    '        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
    '        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '        columna = columna + 1
    '        x1hoja.Cells(fila, columna).Formula = "Gr"
    '        x1hoja.Cells(fila, columna).Font.Bold = True
    '        x1hoja.Cells(fila, columna).Font.Size = 8
    '        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
    '        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
    '        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '        columna = columna + 1
    '        x1hoja.Cells(fila, columna).Formula = "Pr"
    '        x1hoja.Cells(fila, columna).Font.Bold = True
    '        x1hoja.Cells(fila, columna).Font.Size = 8
    '        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
    '        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
    '        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '        columna = columna + 1
    '        x1hoja.Cells(fila, columna).Formula = "Lc*"
    '        x1hoja.Cells(fila, columna).Font.Bold = True
    '        x1hoja.Cells(fila, columna).Font.Size = 8
    '        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
    '        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
    '        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '        columna = columna + 1
    '        x1hoja.Cells(fila, columna).Formula = "MUN*"
    '        x1hoja.Cells(fila, columna).Font.Bold = True
    '        x1hoja.Cells(fila, columna).Font.Size = 8
    '        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
    '        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
    '        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '        columna = columna + 1
    '        x1hoja.Cells(fila, columna).Formula = "Caseina*"
    '        x1hoja.Cells(fila, columna).Font.Bold = True
    '        x1hoja.Cells(fila, columna).Font.Size = 6
    '        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
    '        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
    '        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '        columna = 9
    '        fila = fila + 1
    '        If Not lista2 Is Nothing Then
    '            If lista2.Count > 0 Then
    '                For Each c In lista2
    '                    If c.MUESTRA <> "" Then
    '                        x1hoja.Cells(fila, columna).formula = Trim(c.MUESTRA)
    '                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                        x1hoja.Cells(fila, columna).Font.Size = 8
    '                        columna = columna + 1
    '                    Else
    '                        x1hoja.Cells(fila, columna).formula = "-"
    '                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                        x1hoja.Cells(fila, columna).Font.Size = 8
    '                        columna = columna + 1
    '                    End If
    '                    If c.RC = -1 Then
    '                        x1hoja.Cells(fila, columna).formula = ""
    '                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                        x1hoja.Cells(fila, columna).Font.Size = 8
    '                        columna = columna + 1
    '                    Else
    '                        If c.RC < 30 Then
    '                            x1hoja.Cells(fila, columna).formula = "30"
    '                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                            x1hoja.Cells(fila, columna).Font.Size = 8
    '                            columna = columna + 1
    '                        Else
    '                            x1hoja.Cells(fila, columna).formula = c.RC
    '                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                            x1hoja.Cells(fila, columna).Font.Size = 8
    '                            columna = columna + 1
    '                        End If
    '                    End If
    '                    If c.GRASA = -1 Or c.GRASA = 0 Then
    '                        columna = columna - 1
    '                        x1hoja.Cells(fila, columna).formula = ""
    '                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                        x1hoja.Cells(fila, columna).Font.Size = 8
    '                        columna = columna + 1
    '                        x1hoja.Cells(fila, columna).formula = "MUESTRA NO APTA **"
    '                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                        x1hoja.Cells(fila, columna).Font.Size = 8
    '                        columna = columna + 1
    '                    Else
    '                        Dim valgrasa = Val(c.GRASA)
    '                        If valgrasa < 2 Or valgrasa > 5.5 Then
    '                            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
    '                        End If
    '                        x1hoja.Cells(fila, columna).formula = c.GRASA
    '                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                        x1hoja.Cells(fila, columna).Font.Size = 8
    '                        columna = columna + 1
    '                    End If
    '                    If c.PROTEINA = -1 Or c.PROTEINA = 0 Then
    '                        x1hoja.Cells(fila, columna).formula = ""
    '                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                        x1hoja.Cells(fila, columna).Font.Size = 8
    '                        columna = columna + 1
    '                    Else
    '                        Dim valproteina = Val(c.PROTEINA)
    '                        If valproteina < 2 Or valproteina > 4.5 Then
    '                            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
    '                        End If
    '                        x1hoja.Cells(fila, columna).formula = c.PROTEINA
    '                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                        x1hoja.Cells(fila, columna).Font.Size = 8
    '                        columna = columna + 1
    '                    End If
    '                    If c.LACTOSA = -1 Or c.LACTOSA = 0 Then
    '                        x1hoja.Cells(fila, columna).formula = ""
    '                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                        x1hoja.Cells(fila, columna).Font.Size = 8
    '                        columna = columna + 1
    '                    Else
    '                        x1hoja.Cells(fila, columna).formula = c.LACTOSA
    '                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                        x1hoja.Cells(fila, columna).Font.Size = 8
    '                        columna = columna + 1
    '                    End If
    '                    Dim cs As New dControlSolicitud
    '                    cs.FICHA = idsol
    '                    cs = cs.buscar
    '                    If Not cs Is Nothing Then
    '                        If cs.UREA = 1 Then
    '                            If c.UREA = -1 Or c.UREA = 0 Then
    '                                x1hoja.Cells(fila, columna).formula = "-"
    '                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                                x1hoja.Cells(fila, columna).Font.Size = 8
    '                                columna = columna + 1
    '                            Else
    '                                Dim valorurea As Integer
    '                                valorurea = c.UREA * 0.466
    '                                x1hoja.Cells(fila, columna).formula = FormatNumber(valorurea, 0)
    '                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                                x1hoja.Cells(fila, columna).Font.Size = 8
    '                                columna = columna + 1
    '                            End If
    '                        Else
    '                            x1hoja.Cells(fila, columna).formula = "-"
    '                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                            x1hoja.Cells(fila, columna).Font.Size = 8
    '                            columna = columna + 1
    '                        End If
    '                        If cs.CASEINA = 1 Then
    '                            If c.CASEINA = -1 Or c.CASEINA = 0 Then
    '                                x1hoja.Cells(fila, columna).formula = "-"
    '                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                                x1hoja.Cells(fila, columna).Font.Size = 8
    '                                columna = columna + 1
    '                            Else
    '                                x1hoja.Cells(fila, columna).formula = c.CASEINA
    '                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                                x1hoja.Cells(fila, columna).Font.Size = 8
    '                                columna = columna + 1
    '                            End If
    '                        Else
    '                            x1hoja.Cells(fila, columna).formula = "-"
    '                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                            x1hoja.Cells(fila, columna).Font.Size = 8
    '                            columna = columna + 1
    '                        End If
    '                    Else
    '                        x1hoja.Cells(fila, columna).formula = "-"
    '                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
    '                        x1hoja.Cells(fila, columna).Font.Size = 8
    '                        columna = columna + 1
    '                    End If
    '                    cs = Nothing
    '                    columna = 9
    '                    fila = fila + 1
    '                Next
    '                'Referencias
    '                fila = fila + 1
    '                columna = 1
    '            End If

    '        End If
    '    End If
    '    'GUARDA EL ARCHIVO DE EXCEL
    '    x1hoja.PageSetup.CenterFooter = "Página &P"
    '    x1hoja.SaveAs("\\ROBOT\PREINFORMES\CONTROL\" & idsol & ".xls")
    '    'Marcar como creado
    '    Dim preinf As New dPreinformes
    '    preinf.FICHA = idsol
    '    preinf.marcarcreado()
    '    preinf = Nothing
    '    x1app.Visible = False
    '    x1libro.Close()
    '    x1app = Nothing
    '    x1libro = Nothing
    '    x1hoja = Nothing

    '    Dim proceso As System.Diagnostics.Process()
    '    proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")
    '    For Each opro As System.Diagnostics.Process In proceso
    '        'antes de iniciar el proceso obtengo la fecha en que inicie el 
    '        'proceso para detener todos los procesos que excel que inicio
    '        'mi código durante el proceso
    '        opro.Kill()
    '    Next

    'End Sub
    Private Sub preinforme_control(ByVal id_sol As Long)
        Dim proceso1 As System.Diagnostics.Process()
        proceso1 = System.Diagnostics.Process.GetProcessesByName("EXCEL")
        For Each opro As System.Diagnostics.Process In proceso1
            'antes de iniciar el proceso obtengo la fecha en que inicie el 
            'proceso para detener todos los procesos que excel que inicio
            'mi código durante el proceso
            opro.Kill()
        Next

        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        Dim c As New dControl
        Dim i As New dIbc
        Dim sa As New dSolicitudAnalisis
        Dim pro As New dCliente
        Dim tec As New dTecnicos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        '*****************************
        Dim idsol As Long = id_sol 'ficha
        sa.ID = idsol
        sa = sa.buscar
        '************************************************
        Dim cc As New dClienteConvenio
        Dim listacc As New ArrayList
        Dim bhb As Integer = 0
        listacc = cc.listarporcliente(sa.IDPRODUCTOR)
        If Not listacc Is Nothing Then
            For Each cc In listacc
                If cc.CONVENIO = 2 Then
                    bhb = 1
                End If
            Next
        End If
        '**************************************************
        Dim fila As Integer
        Dim columna As Integer
        fila = 1
        columna = 2
        '*** ENCABEZADO ********************************************************************************
        '***********************************************************************************************
        x1hoja.Cells(1, 1).columnwidth = 5
        x1hoja.Cells(1, 2).columnwidth = 5
        x1hoja.Cells(1, 3).columnwidth = 5
        x1hoja.Cells(1, 4).columnwidth = 5
        x1hoja.Cells(1, 5).columnwidth = 5
        x1hoja.Cells(1, 6).columnwidth = 5
        x1hoja.Cells(1, 7).columnwidth = 5
        x1hoja.Cells(1, 8).columnwidth = 3
        x1hoja.Cells(1, 9).columnwidth = 5
        x1hoja.Cells(1, 10).columnwidth = 5
        x1hoja.Cells(1, 11).columnwidth = 5
        x1hoja.Cells(1, 12).columnwidth = 5
        x1hoja.Cells(1, 13).columnwidth = 5
        x1hoja.Cells(1, 14).columnwidth = 5
        x1hoja.Cells(1, 15).columnwidth = 5
        x1hoja.Range("A1", "D1").Merge()
        fila = 15
        columna = 1
        '*** FIN DEL ENCABEZADO ***********************************************************************************
        '**********************************************************************************************************
        lista = c.listarporsolicitud(idsol)
        lista2 = c.listarporrc(idsol)
        x1hoja.Cells(fila, columna).Formula = "Listado ordenado por identificación"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 8
        x1hoja.Cells(fila, columna).Formula = "Listado ordenado decreciente por Recuento celular"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1
        Dim filaguia As Integer = fila
        x1hoja.Cells(fila, columna).Formula = "Ident."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "RCS"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Gr"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Pr"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Lac*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "MUN*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        If bhb = 0 Then
            x1hoja.Cells(fila, columna).Formula = "Cas*"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            columna = 1
        Else
            x1hoja.Cells(fila, columna).Formula = "BHB"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            columna = 1
        End If
        fila = fila + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("A17", "A18").Merge()
        x1hoja.Range("A17", "A18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("A17", "A18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("A17", "A18").WrapText = True
        x1hoja.Cells(fila, columna).formula = ""
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("B17", "B18").Merge()
        x1hoja.Range("B17", "B18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("B17", "B18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("B17", "B18").WrapText = True
        x1hoja.Cells(fila, columna).formula = "x 1.000 cel/mL"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("C17", "C18").Merge()
        x1hoja.Range("C17", "C18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("C17", "C18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("C17", "C18").WrapText = True
        x1hoja.Cells(fila, columna).formula = "g/100mL"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("D17", "D18").Merge()
        x1hoja.Range("D17", "D18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("D17", "D18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("D17", "D18").WrapText = True
        x1hoja.Cells(fila, columna).formula = "g/100mL"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("E17", "E18").Merge()
        x1hoja.Range("E17", "E18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("E17", "E18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("E17", "E18").WrapText = True
        x1hoja.Cells(fila, columna).formula = "g/100mL"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("F17", "F18").Merge()
        x1hoja.Range("F17", "F18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("F17", "F18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("F17", "F18").WrapText = True
        x1hoja.Cells(fila, columna).formula = "mg/dL"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        If bhb = 0 Then
            x1hoja.Cells(1, 1).RowHeight = 18
            x1hoja.Range("G17", "G18").Merge()
            x1hoja.Range("G17", "G18").Borders.Color = RGB(0, 0, 0)
            x1hoja.Range("G17", "G18").Interior.Color = RGB(192, 192, 192)
            x1hoja.Range("G17", "G18").WrapText = True
            x1hoja.Cells(fila, columna).formula = "g/100mL"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 6
            columna = 1
        Else
            x1hoja.Cells(1, 1).RowHeight = 18
            x1hoja.Range("G17", "G18").Merge()
            x1hoja.Range("G17", "G18").Borders.Color = RGB(0, 0, 0)
            x1hoja.Range("G17", "G18").Interior.Color = RGB(192, 192, 192)
            x1hoja.Range("G17", "G18").WrapText = True
            x1hoja.Cells(fila, columna).formula = "mmol/L"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 6
            columna = 1
        End If
        fila = fila + 2
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    If c.MUESTRA <> "" Then
                        x1hoja.Cells(fila, columna).formula = Trim(c.MUESTRA)
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If c.RC = -1 Then
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Else
                        If c.RC < 30 Then
                            x1hoja.Cells(fila, columna).formula = "30"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = c.RC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                    End If
                    If c.GRASA = -1 Or c.GRASA = 0 Then
                        columna = columna - 1
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "MUESTRA NO APTA **"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Else
                        Dim valgrasa = Val(c.GRASA)
                        If valgrasa < 2.0 Or valgrasa > 5.5 Then
                            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        End If
                        x1hoja.Cells(fila, columna).formula = c.GRASA.ToString("##,##0.00")
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If c.PROTEINA = -1 Or c.PROTEINA = 0 Then
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Else
                        Dim valproteina = Val(c.PROTEINA)
                        If valproteina < 2.0 Or valproteina > 4.5 Then
                            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        End If
                        x1hoja.Cells(fila, columna).formula = c.PROTEINA.ToString("##,##0.00")
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If c.LACTOSA = -1 Or c.LACTOSA = 0 Then
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = c.LACTOSA.ToString("##,##0.00")
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    'Dim cs As New dControlSolicitud
                    'cs.FICHA = idsol
                    'cs = cs.buscar
                    Dim na As New dNuevoAnalisis
                    Dim listana As New ArrayList
                    Dim _urea As Integer = 0
                    Dim _caseina As Integer = 0
                    listana = na.listarporficha2(idsol)
                    If Not listana Is Nothing Then
                        For Each na In listana
                            If na.ANALISIS = 117 Then
                                _urea = 1
                            End If
                            If na.ANALISIS = 157 Then
                                _caseina = 1
                            End If
                            If na.ANALISIS = 158 Then
                                _caseina = 1
                                _urea = 1
                            End If
                        Next
                    End If
                    'If Not cs Is Nothing Then
                    If _urea = 1 Then
                        If c.UREA = -1 Or c.UREA = 0 Then
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            Dim valorurea As Integer
                            valorurea = c.UREA * 0.466
                            If valorurea > 20 Or valorurea < 9 Then
                                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                            End If
                            x1hoja.Cells(fila, columna).formula = FormatNumber(valorurea, 0)
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If _caseina = 1 Then
                        If c.CASEINA = -1 Or c.UREA = 0 Then
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = c.CASEINA.ToString("##,##0.00")
                            x1hoja.Cells(fila, columna).NumberFormat = "#.00"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                    Else
                        If bhb = 1 Then
                            Dim valbhb As String = ""
                            valbhb = c.BHB.ToString("##,##0.00")
                            If c.BHB < 0.07 Then
                                valbhb = "<0.07"
                            End If
                            If c.BHB > 0.27 Then
                                valbhb = ">0.27"
                            End If
                            x1hoja.Cells(fila, columna).formula = valbhb 'c.BHB.ToString("##,##0.00")
                            x1hoja.Cells(fila, columna).NumberFormat = "#.00"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    na = Nothing
                    columna = 1
                    fila = fila + 1
                Next
                'Referencias
                fila = fila + 1
                columna = 1
            End If
            '****** ORDENADO POR RC ************************************************************************
            Dim libreinfeccion As Integer = 0
            Dim posibleinfeccion As Integer = 0
            Dim probableinfeccion As Integer = 0
            fila = filaguia
            columna = 9
            x1hoja.Cells(fila, columna).Formula = "Ident."
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "RCS"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Gr"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Pr"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Lac*"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "MUN*"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            columna = columna + 1
            If bhb = 0 Then
                x1hoja.Cells(fila, columna).Formula = "Cas*"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                columna = 1
            Else
                x1hoja.Cells(fila, columna).Formula = "BHB"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                columna = 1
            End If
            columna = 9
            fila = fila + 1
            x1hoja.Cells(1, 1).RowHeight = 18
            x1hoja.Range("I17", "I18").Merge()
            x1hoja.Range("I17", "I18").Borders.Color = RGB(0, 0, 0)
            x1hoja.Range("I17", "I18").Interior.Color = RGB(192, 192, 192)
            x1hoja.Range("I17", "I18").WrapText = True
            x1hoja.Cells(fila, columna).formula = ""
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 6
            columna = columna + 1
            x1hoja.Cells(1, 1).RowHeight = 18
            x1hoja.Range("J17", "J18").Merge()
            x1hoja.Range("J17", "J18").Borders.Color = RGB(0, 0, 0)
            x1hoja.Range("J17", "J18").Interior.Color = RGB(192, 192, 192)
            x1hoja.Range("J17", "J18").WrapText = True
            x1hoja.Cells(fila, columna).formula = "x 1.000 cel/mL"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 6
            columna = columna + 1
            x1hoja.Cells(1, 1).RowHeight = 18
            x1hoja.Range("K17", "K18").Merge()
            x1hoja.Range("K17", "K18").Borders.Color = RGB(0, 0, 0)
            x1hoja.Range("K17", "K18").Interior.Color = RGB(192, 192, 192)
            x1hoja.Range("K17", "K18").WrapText = True
            x1hoja.Cells(fila, columna).formula = "g/100mL"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 6
            columna = columna + 1
            x1hoja.Cells(1, 1).RowHeight = 18
            x1hoja.Range("L17", "L18").Merge()
            x1hoja.Range("L17", "L18").Borders.Color = RGB(0, 0, 0)
            x1hoja.Range("L17", "L18").Interior.Color = RGB(192, 192, 192)
            x1hoja.Range("L17", "L18").WrapText = True
            x1hoja.Cells(fila, columna).formula = "g/100mL"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 6
            columna = columna + 1
            x1hoja.Cells(1, 1).RowHeight = 18
            x1hoja.Range("M17", "M18").Merge()
            x1hoja.Range("M17", "M18").Borders.Color = RGB(0, 0, 0)
            x1hoja.Range("M17", "M18").Interior.Color = RGB(192, 192, 192)
            x1hoja.Range("M17", "M18").WrapText = True
            x1hoja.Cells(fila, columna).formula = "g/100mL"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 6
            columna = columna + 1
            x1hoja.Cells(1, 1).RowHeight = 18
            x1hoja.Range("N17", "N18").Merge()
            x1hoja.Range("N17", "N18").Borders.Color = RGB(0, 0, 0)
            x1hoja.Range("N17", "N18").Interior.Color = RGB(192, 192, 192)
            x1hoja.Range("N17", "N18").WrapText = True
            x1hoja.Cells(fila, columna).formula = "mg/dL"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 6
            columna = columna + 1
            If bhb = 0 Then
                x1hoja.Cells(1, 1).RowHeight = 18
                x1hoja.Range("O17", "O18").Merge()
                x1hoja.Range("O17", "O18").Borders.Color = RGB(0, 0, 0)
                x1hoja.Range("O17", "O18").Interior.Color = RGB(192, 192, 192)
                x1hoja.Range("O17", "O18").WrapText = True
                x1hoja.Cells(fila, columna).formula = "g/100mL"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 6
                columna = 1
            Else
                x1hoja.Cells(1, 1).RowHeight = 18
                x1hoja.Range("O17", "O18").Merge()
                x1hoja.Range("O17", "O18").Borders.Color = RGB(0, 0, 0)
                x1hoja.Range("O17", "O18").Interior.Color = RGB(192, 192, 192)
                x1hoja.Range("O17", "O18").WrapText = True
                x1hoja.Cells(fila, columna).formula = "mmol/L"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 6
                columna = 1
            End If
            columna = 9
            fila = fila + 2
            If Not lista2 Is Nothing Then
                If lista2.Count > 0 Then
                    For Each c In lista2
                        If c.MUESTRA <> "" Then
                            x1hoja.Cells(fila, columna).formula = Trim(c.MUESTRA)
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                        If c.RC = -1 Then
                            x1hoja.Cells(fila, columna).formula = ""
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            If c.RC < 30 Then
                                x1hoja.Cells(fila, columna).formula = "30"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = c.RC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            End If
                        End If
                        If c.GRASA = -1 Or c.GRASA = 0 Then
                            columna = columna - 1
                            x1hoja.Cells(fila, columna).formula = ""
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).formula = "MUESTRA NO APTA **"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            Dim valgrasa = Val(c.GRASA)
                            If valgrasa < 2.0 Or valgrasa > 5.5 Then
                                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                            End If
                            x1hoja.Cells(fila, columna).formula = c.GRASA.ToString("##,##0.00")
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                        If c.PROTEINA = -1 Or c.PROTEINA = 0 Then
                            x1hoja.Cells(fila, columna).formula = ""
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            Dim valproteina = Val(c.PROTEINA)
                            If valproteina < 2.0 Or valproteina > 4.5 Then
                                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                            End If
                            x1hoja.Cells(fila, columna).formula = c.PROTEINA.ToString("##,##0.00")
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                        If c.LACTOSA = -1 Or c.LACTOSA = 0 Then
                            x1hoja.Cells(fila, columna).formula = ""
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = c.LACTOSA.ToString("##,##0.00")
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                        'Dim cs As New dControlSolicitud
                        'cs.FICHA = idsol
                        'cs = cs.buscar
                        Dim na2 As New dNuevoAnalisis
                        Dim listana2 As New ArrayList
                        Dim _urea As Integer = 0
                        Dim _caseina As Integer = 0
                        listana2 = na2.listarporficha2(idsol)
                        If Not listana2 Is Nothing Then
                            For Each na2 In listana2
                                If na2.ANALISIS = 117 Then
                                    _urea = 1
                                End If
                                If na2.ANALISIS = 157 Then
                                    _caseina = 1
                                End If
                                If na2.ANALISIS = 158 Then
                                    _caseina = 1
                                    _urea = 1
                                End If

                            Next
                        End If
                        'If Not cs Is Nothing Then
                        If _urea = 1 Then
                            If c.UREA = -1 Or c.UREA = 0 Then
                                x1hoja.Cells(fila, columna).formula = "-"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            Else
                                Dim valorurea As Integer
                                valorurea = c.UREA * 0.466
                                If valorurea > 20 Or valorurea < 9 Then
                                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                                End If
                                x1hoja.Cells(fila, columna).formula = FormatNumber(valorurea, 0)
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            End If
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                        If _caseina = 1 Then
                            If c.CASEINA = -1 Or c.UREA = 0 Then
                                x1hoja.Cells(fila, columna).formula = "-"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = c.CASEINA.ToString("##,##0.00")
                                x1hoja.Cells(fila, columna).NumberFormat = "#.00"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            End If
                        Else
                            If bhb = 1 Then
                                Dim valbhb As String = ""
                                valbhb = c.BHB.ToString("##,##0.00")
                                If c.BHB < 0.07 Then
                                    valbhb = "<0.07"
                                End If
                                If c.BHB > 0.27 Then
                                    valbhb = ">0.27"
                                End If
                                x1hoja.Cells(fila, columna).formula = valbhb 'c.BHB.ToString("##,##0.00")
                                x1hoja.Cells(fila, columna).NumberFormat = "#.00"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            End If
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                        na2 = Nothing
                        columna = 9
                        fila = fila + 1
                    Next
                    'Referencias
                    fila = fila + 1
                    columna = 1
                End If
            End If
        End If
        'GUARDA EL ARCHIVO DE EXCEL
        x1app.DisplayAlerts = False 'NO PREGUNTA SI EL ARCHIVO EXISTE
        x1hoja.PageSetup.CenterFooter = "Página &P"
        x1hoja.SaveAs("\\ROBOT\PREINFORMES\CONTROL\" & idsol & ".xls")
        'x1hoja.SaveAs("\\ROBOT\PREINFORMES\CONTROL\" & "p" & idsol & ".xls")
        'Marcar como creado
        Dim preinf As New dPreinformes
        preinf.FICHA = idsol
        preinf.marcarcreado()
        preinf = Nothing
        x1app.Visible = False
        x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing

        Dim proceso As System.Diagnostics.Process()
        proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")
        For Each opro As System.Diagnostics.Process In proceso
            'antes de iniciar el proceso obtengo la fecha en que inicie el 
            'proceso para detener todos los procesos que excel que inicio
            'mi código durante el proceso
            opro.Kill()
        Next
        Dim v As New FormGraficasRC(idsol)
        v.Show()
        Label3.Text = "Listo!"
        TextFicha.Text = ""
        TextArchivo.Text = ""
    End Sub
    Private Sub sincronizarcaravanas()
        Label3.Text = ""
        If TextFicha.Text.Trim.Length = 0 Then MsgBox("Ingrese el número de ficha.", MsgBoxStyle.Exclamation, "Atención") : TextFicha.Focus() : Exit Sub
        If TextArchivo.Text.Trim.Length = 0 Then MsgBox("Seleccione el archivo excel a procesar.", MsgBoxStyle.Exclamation, "Atención") : TextArchivo.Focus() : Exit Sub
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        Dim ruta As String = TextArchivo.Text.Trim
        linea = 1
        Dim objReader As New StreamReader(ruta)
        Dim sLine As String = ""

        Dim id As String = ""
        Dim caravana As String = ""
        Dim ficha As String = ""

        Dim c As New dControl()
        Dim Arch As String, CantFilas As Integer
        Arch = ruta
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet

        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        Dim bandera As Integer = 0

        CantFilas = x1app.Range("a1").CurrentRegion.Rows.Count

        For i = 1 To CantFilas
            If Trim(x1hoja.Cells(i, 1).formula) <> "" Then
                id = x1hoja.Cells(i, 1).value
            End If
            If Trim(x1hoja.Cells(i, 2).formula) <> "" Then
                caravana = x1hoja.Cells(i, 2).value
            End If


            ficha = TextFicha.Text.Trim

            c.modificar2(ficha, id, caravana)

        Next

        ' Cierro Excel
        x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
        objReader.Close()

        Dim proceso As System.Diagnostics.Process()
        proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")

        For Each opro As System.Diagnostics.Process In proceso
            'antes de iniciar el proceso obtengo la fecha en que inicie el 
            'proceso para detener todos los procesos que excel que inicio
            'mi código durante el proceso
            opro.Kill()
        Next
        Label3.Text = "Listo!"
        TextFicha.Text = ""
        TextArchivo.Text = ""
    End Sub
End Class