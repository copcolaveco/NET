Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System
Imports System.IO
Imports System.Collections
Public Class FormSincronizaFichaCaravana
    Private _usuario As dUsuario
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
    End Sub
    Private Sub actualizarcaravanas()
        Label3.Text = ""
        If TextFicha.Text.Trim.Length = 0 Then MsgBox("Ingrese el número de ficha.", MsgBoxStyle.Exclamation, "Atención") : TextFicha.Focus() : Exit Sub
        If TextArchivo.Text.Trim.Length = 0 Then MsgBox("Seleccione el archivo excel a procesar.", MsgBoxStyle.Exclamation, "Atención") : TextArchivo.Focus() : Exit Sub
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        Dim ruta As String = TextArchivo.Text.Trim
        linea = 1
        Dim objReader As New StreamReader(ruta)
        Dim sLine As String = ""

        Dim numero As String = ""
        Dim caravana As String = ""
        Dim ficha As String = ""

        Dim c As New dCaravanas
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
            ficha = TextFicha.Text.Trim

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
        lista = ca.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each ca In lista
                    Dim co As New dControl
                    co.modificar2(ca.FICHA, ca.NUMERO, ca.CARAVANA)
                    co = Nothing
                Next
            End If
        End If


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