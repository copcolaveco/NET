Imports Microsoft.Office.Interop.Excel

Public Class FormAccionCorrectiva
    Private _usuario As dUsuario
    Private num_ As Long
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
    Public Sub New(ByVal u As dUsuario, ByVal _num As Long)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        num_ = _num
        cargarComboResponsable()
        If num_ <> 0 Then
            cargarLista2()
        Else
            cargarLista()
        End If
        limpiar()
        TextNumero.Text = num_
        TextCausa.Focus()
    End Sub
    Public Sub cargarComboResponsable()
        Dim u As New dUsuario
        Dim lista As New ArrayList
        lista = u.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each u In lista
                    ComboResponsable.Items.Add(u)
                Next
            End If
        End If
    End Sub
    Public Sub cargarLista()
        Dim ac As New dAccionCorrectiva
        Dim lista As New ArrayList
        lista = ac.listar
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each ac In lista
                    DataGridView1(columna, fila).Value = ac.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ac.NUMERO
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ac.CAUSA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ac.ACCION
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Public Sub cargarLista2()
        Dim ac As New dAccionCorrectiva
        Dim lista As New ArrayList
        lista = ac.listarxnum(num_)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each ac In lista
                    DataGridView1(columna, fila).Value = ac.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ac.NUMERO
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ac.CAUSA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ac.ACCION
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Public Sub limpiar()
        TextId.Text = ""
        TextNumero.Text = ""
        TextCausa.Text = ""
        TextAccion.Text = ""
        ComboPlan.Text = ""
        ComboPlan.SelectedItem = Nothing
        DatePlazo.Value = Now
        ComboResponsable.Text = ""
        ComboResponsable.SelectedItem = Nothing
        TextCriterios.Text = ""
        ComboEficaz.Text = ""
        ComboEficaz.SelectedItem = Nothing
        DateEvaluacion.Value = "01-01-1900"
        ComboEstado.Text = ""
        ComboEstado.SelectedItem = Nothing
        TextCausa.Focus()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Numero" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ac As New dAccionCorrectiva
            id = row.Cells("Id").Value
            ac.ID = id
            ac = ac.buscar
            If Not ac Is Nothing Then
                TextId.Text = ac.ID
                TextNumero.Text = ac.NUMERO
                TextCausa.Text = ac.CAUSA
                TextAccion.Text = ac.ACCION
                If ac.PLAN = 1 Then
                    ComboPlan.Text = "Si"
                Else
                    ComboPlan.Text = "No"
                End If
                DatePlazo.Value = ac.PLAZO
                ComboResponsable.SelectedItem = Nothing
                Dim u As dUsuario
                For Each u In ComboResponsable.Items
                    If u.ID = ac.RESPONSABLE Then
                        ComboResponsable.SelectedItem = u
                        Exit For
                    End If
                Next
                TextCriterios.Text = ac.CRITERIOS
                ComboEficaz.Text = ac.EFICAZ
                DateEvaluacion.Value = ac.FECHAEVALUACION
                If ac.ESTADO = 1 Then
                    ComboEstado.Text = "Abierta"
                Else
                    ComboEstado.Text = "Cerrada"
                End If
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Causa" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ac As New dAccionCorrectiva
            id = row.Cells("Id").Value
            ac.ID = id
            ac = ac.buscar
            If Not ac Is Nothing Then
                TextId.Text = ac.ID
                TextNumero.Text = ac.NUMERO
                TextCausa.Text = ac.CAUSA
                TextAccion.Text = ac.ACCION
                If ac.PLAN = 1 Then
                    ComboPlan.Text = "Si"
                Else
                    ComboPlan.Text = "No"
                End If
                DatePlazo.Value = ac.PLAZO
                ComboResponsable.SelectedItem = Nothing
                Dim u As dUsuario
                For Each u In ComboResponsable.Items
                    If u.ID = ac.RESPONSABLE Then
                        ComboResponsable.SelectedItem = u
                        Exit For
                    End If
                Next
                TextCriterios.Text = ac.CRITERIOS
                ComboEficaz.Text = ac.EFICAZ
                DateEvaluacion.Value = ac.FECHAEVALUACION
                If ac.ESTADO = 1 Then
                    ComboEstado.Text = "Abierta"
                Else
                    ComboEstado.Text = "Cerrada"
                End If
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Accion" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ac As New dAccionCorrectiva
            id = row.Cells("Id").Value
            ac.ID = id
            ac = ac.buscar
            If Not ac Is Nothing Then
                TextId.Text = ac.ID
                TextNumero.Text = ac.NUMERO
                TextCausa.Text = ac.CAUSA
                TextAccion.Text = ac.ACCION
                If ac.PLAN = 1 Then
                    ComboPlan.Text = "Si"
                Else
                    ComboPlan.Text = "No"
                End If
                DatePlazo.Value = ac.PLAZO
                ComboResponsable.SelectedItem = Nothing
                Dim u As dUsuario
                For Each u In ComboResponsable.Items
                    If u.ID = ac.RESPONSABLE Then
                        ComboResponsable.SelectedItem = u
                        Exit For
                    End If
                Next
                TextCriterios.Text = ac.CRITERIOS
                ComboEficaz.Text = ac.EFICAZ
                DateEvaluacion.Value = ac.FECHAEVALUACION
                If ac.ESTADO = 1 Then
                    ComboEstado.Text = "Abierta"
                Else
                    ComboEstado.Text = "Cerrada"
                End If
            End If
        End If
    End Sub


    Private Sub ButtonPlan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPlan.Click
        Dim idac As Long = 0
        idac = TextId.Text.Trim
        If idac = 0 Then
            MsgBox("Antes debe guardar la acción correctiva!")
            Exit Sub
        Else
            Dim v As New FormPlanAC(Usuario, idac)
            v.Show()
        End If

    End Sub

    Private Sub ButtonNueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNueva.Click
        limpiar()
        cargarLista()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If TextId.Text <> "" Then
            If Usuario.USUARIO = "CA" Then
                If MsgBox("El registro será eliminado, ¿desea continuar?", MsgBoxStyle.OkCancel, "Atención") = MsgBoxResult.Ok Then
                    Dim ac As New dAccionCorrectiva
                    Dim id As Long = CType(TextId.Text, Long)
                    ac.ID = id
                    If (ac.eliminar(Usuario)) Then
                        MsgBox("Registro eliminado", MsgBoxStyle.Information, "Atención")
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                End If
            Else
                MsgBox("No tiene permisos para modificar el registro.", MsgBoxStyle.Information, "Atención")
            End If
        End If
        limpiar()
        cargarLista()
    End Sub
    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim numero As Long = TextNumero.Text.Trim
        Dim causa As String = TextCausa.Text.Trim
        Dim accion As String = TextAccion.Text.Trim
        Dim plan As Integer = 0
        If ComboPlan.Text <> "" Then
            If ComboPlan.Text = "Si" Then
                plan = 1
            Else
                plan = 0
            End If
        Else
            MsgBox("Debe seleccionar si hay plan o no!")
            Exit Sub
            ComboPlan.Focus()
        End If
        Dim plazo As Date = DatePlazo.Value.ToString("yyyy-MM-dd")
        Dim idresponsable As dUsuario = CType(ComboResponsable.SelectedItem, dUsuario)
        If ComboResponsable.Text = "" Then
            MsgBox("Debe seleccionar un responsable!")
            Exit Sub
            ComboResponsable.Focus()
        End If
        Dim criterios As String = TextCriterios.Text.Trim
        Dim eficaz As String = 0
        If ComboEficaz.Text <> "" Then
            eficaz = ComboEficaz.Text
        Else
            MsgBox("Debe seleccionar si es eficaz o no!")
            Exit Sub
            ComboEficaz.Focus()
        End If
        Dim fechaevaluacion As Date = DateEvaluacion.Value.ToString("yyyy-MM-dd")
        Dim estado As Integer = 0
        If ComboEstado.Text <> "" Then
            If ComboEstado.Text = "Abierta" Then
                estado = 1
            Else
                estado = 0
            End If
        Else
            MsgBox("Debe seleccionar el estado!")
            Exit Sub
            ComboEstado.Focus()
        End If
        If TextId.Text.Trim.Length > 0 Then
            Dim ac As New dAccionCorrectiva
            Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim fecplazo As String
            Dim feceval As String
            fecplazo = Format(plazo, "yyyy-MM-dd")
            feceval = Format(fechaevaluacion, "yyyy-MM-dd")
            ac.ID = id
            ac.NUMERO = numero
            ac.CAUSA = causa
            ac.ACCION = accion
            ac.PLAN = plan
            ac.PLAZO = fecplazo
            ac.RESPONSABLE = idresponsable.ID
            ac.CRITERIOS = criterios
            ac.EFICAZ = eficaz
            ac.FECHAEVALUACION = feceval
            ac.ESTADO = estado
            If Usuario.USUARIO = "CA" Then
                If (ac.modificar(Usuario)) Then
                    MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                MsgBox("No tiene permisos para modificar el registro.", MsgBoxStyle.Information, "Atención")
            End If
        Else
            Dim ac As New dAccionCorrectiva
            'Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim fecplazo As String
            Dim feceval As String
            fecplazo = Format(plazo, "yyyy-MM-dd")
            feceval = Format(fechaevaluacion, "yyyy-MM-dd")
            ac.NUMERO = numero
            ac.CAUSA = causa
            ac.ACCION = accion
            ac.PLAN = plan
            ac.PLAZO = fecplazo
            ac.RESPONSABLE = idresponsable.ID
            ac.CRITERIOS = criterios
            ac.EFICAZ = eficaz
            ac.FECHAEVALUACION = feceval
            ac.ESTADO = estado
            If (ac.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        cargarLista()
        limpiar()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub btnExportExl_Click(sender As Object, e As EventArgs) Handles btnExportExl.Click


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

        Dim ac As New dAccionCorrectiva
        Dim lista As New ArrayList
        lista = ac.listar

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 1
                Dim columna As Integer = 1

                x1hoja.Cells(1, 1).columnwidth = 20
                x1hoja.Cells(1, 2).columnwidth = 29
                x1hoja.Cells(1, 3).columnwidth = 34

                x1hoja.Cells(fila, columna).formula = "Id"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Número"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Causa"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Acción"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Plan"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Plazo"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Responsable"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Criterios"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Eficaz"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Fecha evaluzación"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Estado"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "RG.CC.37 ID"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "RG.CC.37 Descripción"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1


                columna = 1
                fila = fila + 1

                For Each ac In lista

                    x1hoja.Cells(fila, columna).formula = ac.ID
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    columna = columna + 1

                    x1hoja.Cells(fila, columna).formula = ac.NUMERO
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    columna = columna + 1

                    x1hoja.Cells(fila, columna).formula = ac.CAUSA
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    columna = columna + 1

                    x1hoja.Cells(fila, columna).formula = ac.ACCION
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    columna = columna + 1

                    x1hoja.Cells(fila, columna).formula = ac.PLAN
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    columna = columna + 1

                    x1hoja.Cells(fila, columna).formula = ac.PLAZO
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    columna = columna + 1

                    Dim usuario As New dUsuario
                    usuario.ID = ac.RESPONSABLE
                    usuario = usuario.buscar

                    If Not usuario Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = usuario.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = " - "
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        columna = columna + 1
                    End If

                    x1hoja.Cells(fila, columna).formula = ac.CRITERIOS
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    columna = columna + 1

                    x1hoja.Cells(fila, columna).formula = ac.EFICAZ
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    columna = columna + 1

                    x1hoja.Cells(fila, columna).formula = ac.FECHAEVALUACION
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    columna = columna + 1

                    x1hoja.Cells(fila, columna).formula = ac.ESTADO
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    columna = columna + 1

                    Dim reclamo As New dReclamos
                    reclamo.ID = ac.NUMERO
                    reclamo = reclamo.buscar

                    If Not reclamo Is Nothing Then
                        If reclamo.ID > 0 Then
                            x1hoja.Cells(fila, columna).formula = reclamo.ID
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            x1hoja.Cells(fila, columna).WrapText = True
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = " - "
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            x1hoja.Cells(fila, columna).WrapText = True
                            columna = columna + 1
                        End If

                        If Not reclamo.DESCRIPCION Is Nothing Then
                            x1hoja.Cells(fila, columna).formula = reclamo.DESCRIPCION
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            x1hoja.Cells(fila, columna).WrapText = True
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = " - "
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            x1hoja.Cells(fila, columna).WrapText = True
                            columna = columna + 1
                        End If
                    End If
                    

                    columna = 1
                    fila = fila + 1

                Next
            End If
        End If

        x1app.Visible = True
        'x1libro.PrintPreview()

        'x1hoja.PrintOut()
        'x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
End Class