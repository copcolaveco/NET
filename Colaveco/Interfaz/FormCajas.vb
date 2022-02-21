Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public Class FormCajas
#Region "Atributos"
    Private _usuario As dUsuario
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#End Region
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        cargarComboEstado()
        limpiar()
    End Sub
#End Region
    Private Sub cargarComboEstado()
        ComboEstado.Text = "Laboratorio"
    End Sub


    Private Sub cargarlista()
        Dim c As New dCajas
        Dim lista As New ArrayList
        lista = c.listar
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each c In lista
                    DataGridView1(columna, fila).Value = c.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = c.CODIGO
                    columna = columna + 1
                    If c.ESTADO = 1 Then
                        DataGridView1(columna, fila).Value = "Laboratorio"
                        columna = 0
                        fila = fila + 1
                    ElseIf c.ESTADO = 2 Then
                        DataGridView1(columna, fila).Value = "Cliente"
                        columna = 0
                        fila = fila + 1
                    ElseIf c.ESTADO = 3 Then
                        DataGridView1(columna, fila).Value = "Florida"
                        columna = 0
                        fila = fila + 1
                    ElseIf c.ESTADO = 4 Then
                        DataGridView1(columna, fila).Value = "Cardal"
                        columna = 0
                        fila = fila + 1
                    ElseIf c.ESTADO = 5 Then
                        DataGridView1(columna, fila).Value = "Canelones"
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = "Desaparecida"
                        columna = 0
                        fila = fila + 1
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub limpiar()
        TextId.Text = ""
        TextCodigo.Text = ""
        ComboEstado.Text = "Laboratorio"
        RadioCA.Checked = True
        actualizartxt()
        cargarlista()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim codigo As String = TextCodigo.Text.Trim
        If ComboEstado.Text.Trim.Length = 0 Then MsgBox("Seleccione unestado", MsgBoxStyle.Exclamation, "Atención") : ComboEstado.Focus() : Exit Sub
        Dim estado As Integer = 0
        If ComboEstado.Text = "Laboratorio" Then
            estado = 1
        ElseIf ComboEstado.Text = "Cliente" Then
            estado = 2
        ElseIf ComboEstado.Text = "Florida" Then
            estado = 3
        ElseIf ComboEstado.Text = "Cardal" Then
            estado = 4
        ElseIf ComboEstado.Text = "Canelones" Then
            estado = 5
        ElseIf ComboEstado.Text = "Perdida" Then
            estado = 6
        End If

        If TextId.Text <> "" Then
            Dim c As New dCajas
            Dim id As Long = TextId.Text.Trim
            c.ID = id
            c.CODIGO = codigo
            c.ESTADO = estado
            If (c.modificar(Usuario)) Then
                '**************************************************
                Dim cw As New dCajasWeb
                cw.CODIGO = codigo
                cw = cw.buscar()
                If Not cw Is Nothing Then
                    cw.ESTADO = estado
                    cw.CLIENTE = -1
                    cw.MODCOLAVECO = 1
                    cw.MODFLORIDA = 0
                    cw.modificarcaja(Usuario)
                End If
                '**************************************************

                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            MsgBox("Error, debe ingresar la caja correspondiente", MsgBoxStyle.Critical, "Atención")
            'Dim c As New dCajas
            'c.CODIGO = codigo
            'c.ESTADO = estado
            'If (c.guardar(Usuario)) Then
            '    MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            '    limpiar()
            '    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            'End If
        End If



    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Numero" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dCajas
            id = row.Cells("Id").Value
            c.ID = id
            c = c.buscar
            If Not c Is Nothing Then
                TextId.Text = c.ID
                TextCodigo.Text = c.CODIGO
                If c.ESTADO = 1 Then
                    ComboEstado.Text = "Laboratorio"
                ElseIf c.ESTADO = 2 Then
                    ComboEstado.Text = "Cliente"
                ElseIf c.ESTADO = 3 Then
                    ComboEstado.Text = "Florida"
                ElseIf c.ESTADO = 4 Then
                    ComboEstado.Text = "Cardal"
                ElseIf c.ESTADO = 5 Then
                    ComboEstado.Text = "Canelones"
                ElseIf c.ESTADO = 6 Then
                    ComboEstado.Text = "Perdida"
                End If
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Codigo" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dCajas
            id = row.Cells("Id").Value
            c.ID = id
            c = c.buscar
            If Not c Is Nothing Then
                TextId.Text = c.ID
                TextCodigo.Text = c.CODIGO
                If c.ESTADO = 1 Then
                    ComboEstado.Text = "Laboratorio"
                ElseIf c.ESTADO = 2 Then
                    ComboEstado.Text = "Cliente"
                ElseIf c.ESTADO = 3 Then
                    ComboEstado.Text = "Florida"
                ElseIf c.ESTADO = 4 Then
                    ComboEstado.Text = "Cardal"
                ElseIf c.ESTADO = 5 Then
                    ComboEstado.Text = "Canelones"
                End If
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Estado" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dCajas
            id = row.Cells("Id").Value
            c.ID = id
            c = c.buscar
            If Not c Is Nothing Then
                TextId.Text = c.ID
                TextCodigo.Text = c.CODIGO
                If c.ESTADO = 1 Then
                    ComboEstado.Text = "Laboratorio"
                ElseIf c.ESTADO = 2 Then
                    ComboEstado.Text = "Cliente"
                ElseIf c.ESTADO = 3 Then
                    ComboEstado.Text = "Florida"
                ElseIf c.ESTADO = 4 Then
                    ComboEstado.Text = "Cardal"
                ElseIf c.ESTADO = 5 Then
                    ComboEstado.Text = "Canelones"
                End If
            End If
        End If
    End Sub


    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
       
    End Sub


    Private Sub ButtonNueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNueva.Click
        limpiar()
    End Sub

    Private Sub RadioCA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioCA.CheckedChanged
        actualizartxt()
    End Sub
    Private Sub actualizartxt()
        If RadioCA.Checked = True Then
            TextCodigo.Text = "A-"
        ElseIf RadioCL.Checked = True Then
            TextCodigo.Text = "Cons-"
        ElseIf RadioCaja.Checked = True Then
            TextCodigo.Text = "Caja-"
        Else
            TextCodigo.Text = "Caja-F"
        End If
    End Sub

    Private Sub RadioCL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioCL.CheckedChanged
        actualizartxt()
    End Sub

    Private Sub RadioCaja_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioCaja.CheckedChanged
        actualizartxt()
    End Sub

    Private Sub RadioCajaFlorida_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioCajaFlorida.CheckedChanged
        actualizartxt()
    End Sub

    Private Sub TextBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBuscar.TextChanged
        Dim codigo As String = TextBuscar.Text.Trim
        DataGridView1.Rows.Clear()
        If codigo.Length > 0 Then
            Dim c As New dCajas
            Dim lista As New ArrayList
            lista = c.buscarPorCodigo(codigo)
            If Not lista Is Nothing Then 'And lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each c In lista
                    DataGridView1(columna, fila).Value = c.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = c.CODIGO
                    columna = columna + 1
                    If c.ESTADO = 1 Then
                        DataGridView1(columna, fila).Value = "Laboratorio"
                        columna = 0
                        fila = fila + 1
                    ElseIf c.ESTADO = 2 Then
                        DataGridView1(columna, fila).Value = "Cliente"
                        columna = 0
                        fila = fila + 1
                    ElseIf c.ESTADO = 3 Then
                        DataGridView1(columna, fila).Value = "Florida"
                        columna = 0
                        fila = fila + 1
                    ElseIf c.ESTADO = 4 Then
                        DataGridView1(columna, fila).Value = "Cardal"
                        columna = 0
                        fila = fila + 1
                    ElseIf c.ESTADO = 5 Then
                        DataGridView1(columna, fila).Value = "Canelones"
                        columna = 0
                        fila = fila + 1
                    ElseIf c.ESTADO = 6 Then
                        DataGridView1(columna, fila).Value = "Perdida"
                        columna = 0
                        fila = fila + 1
                    End If
                Next
            End If
        Else : DataGridView1.Rows.Clear()
        End If
    End Sub
    Private Sub exportar()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(2)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        x1hoja.Cells(1, 1).columnwidth = 15
        x1hoja.Cells(1, 2).columnwidth = 15
        x1hoja.Cells(1, 3).columnwidth = 50

        Dim c As New dCajas
        Dim lista As New ArrayList
        lista = c.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                Dim fila As Integer = 1
                Dim columna As Integer = 1
                x1hoja.Cells(fila, columna).formula = "LISTADO DE CAJAS"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
                x1hoja.Cells(fila, columna).formula = "Código"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Ubicación"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Cliente"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Fecha"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                fila = fila + 1
                columna = 1
                For Each c In lista
                    x1hoja.Cells(fila, columna).formula = c.CODIGO
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    If c.ESTADO = 1 Then
                        x1hoja.Cells(fila, columna).formula = "Laboratorio"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        'columna = 1
                        'fila = fila + 1
                        columna = columna + 1
                    ElseIf c.ESTADO = 2 Then
                        x1hoja.Cells(fila, columna).formula = "Cliente"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        Dim ec As New dEnvioCajas
                        Dim caja As String = c.CODIGO
                        Dim listaenvio As New ArrayList
                        listaenvio = ec.listarultimoenvio(caja)
                        If Not listaenvio Is Nothing Then
                            For Each ec In listaenvio
                                Dim p As New dCliente
                                p.ID = ec.IDPRODUCTOR
                                p = p.buscar
                                If Not p Is Nothing Then
                                    x1hoja.Cells(fila, columna).formula = p.NOMBRE
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                    p = Nothing
                                End If
                            Next
                            ec = Nothing
                            listaenvio = Nothing
                        End If
                        'columna = 1
                        'fila = fila + 1
                        columna = columna + 1
                    ElseIf c.ESTADO = 3 Then
                        x1hoja.Cells(fila, columna).formula = "Florida"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        'columna = 1
                        'fila = fila + 1
                        columna = columna + 1
                    ElseIf c.ESTADO = 4 Then
                        x1hoja.Cells(fila, columna).formula = "Cardal"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        'columna = 1
                        'fila = fila + 1
                        columna = columna + 1
                    ElseIf c.ESTADO = 5 Then
                        x1hoja.Cells(fila, columna).formula = "Canelones"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        'columna = 1
                        'fila = fila + 1
                        columna = columna + 1
                    ElseIf c.ESTADO = 6 Then
                        x1hoja.Cells(fila, columna).formula = "Perdida"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        'columna = 1
                        'fila = fila + 1
                        columna = columna + 1
                    End If
                    Dim ec2 As New dEnvioCajas
                    ec2.IDCAJA = c.CODIGO
                    ec2 = ec2.buscarultimoenvio
                    If Not ec2 Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = ec2.FECHAENVIO
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        fila = fila + 1
                        columna = 1
                    Else
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        fila = fila + 1
                        columna = 1
                    End If
                    ec2 = Nothing
                Next
            End If
        End If
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub

    Private Sub ButtonExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportar.Click
        exportar()
    End Sub
End Class