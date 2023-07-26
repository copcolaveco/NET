Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Public Class FormFiltrarProductor
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cargarComboDepartamento()

    End Sub

#End Region
    Public Sub cargarComboDepartamento()
        Dim d As New dDepartamento
        Dim lista As New ArrayList
        lista = d.listar
        ComboDepartamento.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each d In lista
                    ComboDepartamento.Items.Add(d)
                Next
            End If
        End If
    End Sub

    Private Sub CheckDepartamento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckDepartamento.CheckedChanged
        chequearmarcas()
    End Sub
    Private Sub chequearmarcas()
        If CheckDepartamento.Checked = True Then
            ComboDepartamento.Enabled = True
        Else
            ComboDepartamento.Enabled = False
        End If
    End Sub

    Private Sub ButtonFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFiltrar.Click
        If CheckDepartamento.Checked = True Then
            filtrarxdepto()
        End If
    End Sub
    Private Sub filtrarxdepto()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        'x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        'x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        'x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        x1hoja.Cells(1, 1).columnwidth = 6
        x1hoja.Cells(1, 2).columnwidth = 11
        x1hoja.Cells(1, 3).columnwidth = 37
        x1hoja.Cells(1, 4).columnwidth = 35
        x1hoja.Cells(1, 5).columnwidth = 14
        x1hoja.Cells(1, 6).columnwidth = 17
        x1hoja.Cells(1, 7).columnwidth = 13
        x1hoja.Cells(1, 8).columnwidth = 13
        x1hoja.Cells(1, 9).columnwidth = 18
        x1hoja.Cells(1, 10).columnwidth = 22
        x1hoja.Cells(1, 11).columnwidth = 17
        x1hoja.Cells(1, 12).columnwidth = 13
        x1hoja.Cells(1, 13).columnwidth = 12

        Dim iddepto As Integer = 0
        Dim departamento As dDepartamento = CType(ComboDepartamento.SelectedItem, dDepartamento)
        If departamento Is Nothing Then
            iddepto = 999
        Else
            iddepto = departamento.ID
        End If
        Dim p As New dCliente
        Dim lista As New ArrayList
        lista = p.listarxdepartamento(iddepto)
        Dim fila As Integer = 1
        Dim columna As Integer = 1
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Formula = "Listado de productores - " & departamento.NOMBRE
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 2
        x1hoja.Cells(fila, columna).formula = "ID"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Tipo"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Nombre"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Dirección"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Departamento"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Localidad"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Teléfono"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Celular"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Usuario web"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Email"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Razón Social"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "RUT"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "DICOSE"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = 1
        fila = fila + 1
        If Not lista Is Nothing Then
            For Each p In lista
                x1hoja.Cells(fila, columna).Formula = p.ID
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                Dim t As New dTipoUsuario
                t.ID = p.TIPOUSUARIO
                t = t.buscar
                If Not t Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = t.NOMBRE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                End If
                x1hoja.Cells(fila, columna).Formula = p.NOMBRE
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = p.DIRECCION
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                Dim d As New dDepartamento
                d.ID = p.IDDEPARTAMENTO
                d = d.buscar
                If Not d Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = d.NOMBRE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                End If
                Dim l As New dLocalidad
                l.ID = p.IDLOCALIDAD
                l = l.buscar
                If Not l Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = l.NOMBRE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                End If
                x1hoja.Cells(fila, columna).Formula = p.TELEFONO1
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = p.CELULAR
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = p.USUARIO_WEB
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = p.EMAIL1
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = p.FAC_RSOCIAL
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = p.FAC_RUT
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = p.DICOSE
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = 1
                fila = fila + 1
            Next
        End If
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
End Class