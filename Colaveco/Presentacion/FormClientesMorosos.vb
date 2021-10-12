Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System
Imports System.IO
Imports System.Collections
Public Class FormClientesMorosos
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
        Usuario = u

    End Sub
#End Region
    Private Sub ButtonBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscar.Click
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
    Private Sub recorroplanilla()

        Dim mor As New dMorosos
        mor.eliminar(Usuario)

        ' *** SI EL ARCHIVO ES XLS **************************************************************************************
        Dim cliente As String = ""
        Dim debe As Integer = 0
        Dim valor90 As Double = 0
        Dim valor60 As Double = 0
        Dim valor30 As Double = 0
        Dim valor As Double = 0
        Dim Arch As String, CantFilas As Integer
        Arch = TextArchivo.Text.Trim
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet

        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)


        CantFilas = x1app.Range("a1").CurrentRegion.Rows.Count

        For i = 1 To CantFilas
            If Trim(x1hoja.Cells(i, 1).formula) <> "" Then
                cliente = Trim(x1hoja.Cells(i, 1).value)
            Else
                cliente = ""
            End If
            valor90 = Val(Trim(x1hoja.Cells(i, 6).formula))
            valor60 = Val(Trim(x1hoja.Cells(i, 7).formula))
            valor30 = Val(Trim(x1hoja.Cells(i, 9).formula))
            valor = Val(Trim(x1hoja.Cells(i, 10).formula))
            If valor90 > 0 Then 'Trim(x1hoja.Cells(i, 6).formula) > 0 Then
                debe = 1
            ElseIf valor60 > 0 Then 'Trim(x1hoja.Cells(i, 7).formula) > 0 Then
                debe = 1
            ElseIf valor30 > 0 Then 'Trim(x1hoja.Cells(i, 9).formula) > 0 Then
                debe = 1
            ElseIf valor > 0 Then 'Trim(x1hoja.Cells(i, 10).formula) > 0 Then
                debe = 1
            Else
                debe = 0
            End If
            
            If debe = 1 Then
                If cliente <> "" Then
                    Dim m As New dMorosos
                    m.CLIENTE = cliente
                    m.DEBE = debe
                    m.guardar(Usuario)
                End If
            End If

        Next

        ' Cierro Excel
        x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing


    End Sub

    Private Sub ButtonProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonProcesar.Click
        If TextArchivo.Text <> "" Then
            recorroplanilla()
            desmarcar_morosos()
            marcodeudores()
            MsgBox("Proceso finalizado.")
        End If
    End Sub
    Private Sub desmarcar_morosos()
        Dim p As New dProductor
        p.desmarcarmorosos(Usuario)
    End Sub
    Private Sub marcodeudores()
        Dim m As New dMorosos
        Dim lista As New ArrayList
        Dim codfigaro As String = ""
        Dim p As New dProductor
        lista = m.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each m In lista
                    codfigaro = m.CLIENTE
                    If codfigaro <> "" Then
                        p.marcarmoroso(codfigaro, Usuario)
                    End If
                Next
            End If
        End If
    End Sub
End Class