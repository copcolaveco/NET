Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public Class FormLicencias
#Region "Atributos"
    Public check_resultado As Integer = 0
    Private _usuario As dUsuario
    Private diasguardados As Integer = 0
    Dim l_usuario As Integer = 0
    Dim l_desde As String = ""
    Dim l_hasta As String = ""
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
        cargarUsuarios()
        cargarLista()
        If Usuario.USUARIO = "MCF" Or Usuario.USUARIO = "DF" Or Usuario.USUARIO = "SA" Then
            Eliminar.Visible = True
        End If
    End Sub
#End Region
    Private Sub cargarUsuarios()
        Dim u As New dUsuario
        Dim lista As New ArrayList
        lista = u.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each u In lista
                    ComboUsuarios.Items.Add(u)
                Next
            End If
        End If
    End Sub
    Private Sub guardar()
        Dim usuario As dUsuario = CType(ComboUsuarios.SelectedItem, dUsuario)
        Dim idusuario As Integer = 0
        Dim fechadesde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim dias As Integer = 0
        If TextDias.Text.Length > 0 Then
            dias = TextDias.Text.Trim
        End If
        If Not usuario Is Nothing Then
            idusuario = usuario.ID
        Else
            MsgBox("No se ha seleccionado usuario", MsgBoxStyle.Exclamation, "Atención") : ComboUsuarios.Focus() : Exit Sub
        End If

        If TextId.Text.Length > 0 Then
            Dim l As New dLicencias
            Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim fecdesde As String
            Dim fechasta As String
            fecdesde = Format(fechadesde, "yyyy-MM-dd")
            fechasta = Format(fechahasta, "yyyy-MM-dd")
            l.ID = id
            l.IDUSUARIO = idusuario
            l.DESDE = fecdesde
            l.HASTA = fechasta
            l.DIAS = dias
            If (l.modificar(usuario)) Then
                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim l As New dLicencias
            Dim fecdesde As String
            Dim fechasta As String
            fecdesde = Format(fechadesde, "yyyy-MM-dd")
            fechasta = Format(fechahasta, "yyyy-MM-dd")
            l.IDUSUARIO = idusuario
            l.DESDE = fecdesde
            l.HASTA = fechasta
            l.DIAS = dias
            If (l.guardar(usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        cargarLista()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        If ComboUsuarios.Text <> "" Then
            If TextId.Text.Length > 0 Then
                Dim ano As Integer = 0
                Dim usuario As dUsuario = CType(ComboUsuarios.SelectedItem, dUsuario)
                Dim idusuario As Integer = usuario.ID
                Dim fechadesde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
                Dim fecdesde As String = Format(fechadesde, "yyyy-MM-dd")
                ano = fechadesde.Year
                Dim l As New dLicencias
                Dim diastomados As Integer = 0
                Dim diasdelicencia As Integer = 0
                Dim lista As New ArrayList
                lista = l.listarxanoxusuario(ano, idusuario)
                If Not lista Is Nothing Then
                    If lista.Count > 0 Then
                        For Each l In lista
                            diastomados = diastomados + l.DIAS
                        Next
                    End If
                End If
                diastomados = diastomados + Val(TextDias.Text.Trim)
                Dim la As New dLicenciaAnual
                la.ANO = ano
                la.FUNCIONARIO = idusuario
                la = la.buscarxanoxusuario
                diasdelicencia = la.DIAS
                diastomados = diastomados - diasguardados
                If diastomados > diasdelicencia Then
                    MsgBox("Ha superado los diás de licencia para este año")
                    Exit Sub
                End If
                guardar()
            Else
                Dim ano As Integer = 0
                Dim usuario As dUsuario = CType(ComboUsuarios.SelectedItem, dUsuario)
                Dim idusuario As Integer = usuario.ID
                Dim fechadesde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
                Dim fecdesde As String = Format(fechadesde, "yyyy-MM-dd")
                ano = fechadesde.Year
                Dim l As New dLicencias
                Dim diastomados As Integer = 0
                Dim diasdelicencia As Integer = 0
                Dim lista As New ArrayList
                lista = l.listarxanoxusuario(ano, idusuario)
                If Not lista Is Nothing Then
                    If lista.Count > 0 Then
                        For Each l In lista
                            diastomados = diastomados + l.DIAS
                        Next
                    End If
                End If
                diastomados = diastomados + Val(TextDias.Text.Trim)
                Dim la As New dLicenciaAnual
                la.ANO = ano
                la.FUNCIONARIO = idusuario
                la = la.buscarxanoxusuario
                diasdelicencia = la.DIAS
                If diastomados > diasdelicencia Then
                    MsgBox("Ha superado los diás de licencia para este año")
                    Exit Sub
                End If
                guardar()
            End If
        Else
            MsgBox("Seleccione un nombre")
        End If

    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        ComboUsuarios.SelectedItem = False
        ComboUsuarios.Text = ""
        TextDiasCorrespondientes.Text = ""
        TextDiasRestantes.Text = ""
        DateDesde.Value = Now
        DateHasta.Value = Now
        ComboUsuarios.Focus()
    End Sub
    Private Sub cargarLista()
        Dim l As New dLicencias
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        lista = l.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridView1.Rows.Clear()
                DataGridView1.Rows.Add(lista.Count)
                For Each l In lista
                    If l.APROBADA = 0 Then
                        DataGridView1(columna, fila).Value = l.ID
                        columna = columna + 1
                        Dim u As New dUsuario
                        u.ID = l.IDUSUARIO
                        u = u.buscar
                        DataGridView1(columna, fila).Value = u.NOMBRE
                        DataGridView1(columna, fila).Style.BackColor = Color.Red
                        DataGridView1(columna, fila).Style.ForeColor = Color.White
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = l.DESDE
                        DataGridView1(columna, fila).Style.BackColor = Color.Red
                        DataGridView1(columna, fila).Style.ForeColor = Color.White
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = l.HASTA
                        DataGridView1(columna, fila).Style.BackColor = Color.Red
                        DataGridView1(columna, fila).Style.ForeColor = Color.White
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = l.DIAS
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = False
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = l.ID
                        columna = columna + 1
                        Dim u As New dUsuario
                        u.ID = l.IDUSUARIO
                        u = u.buscar
                        DataGridView1(columna, fila).Value = u.NOMBRE
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = l.DESDE
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = l.HASTA
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = l.DIAS
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = True
                        columna = 0
                        fila = fila + 1
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'If e.ColumnIndex = DataGridView1.Columns(5).Index Then
        '    check_resultado = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
        '    If check_resultado = 0 Then
        '        DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
        '    Else
        '        DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True
        '    End If
        'End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Nombre" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim l As New dLicencias
            id = row.Cells("Id").Value
            l.ID = id
            l = l.buscar
            If Not l Is Nothing Then
                TextId.Text = l.ID
                Dim u As dUsuario
                ComboUsuarios.SelectedItem = Nothing
                For Each u In ComboUsuarios.Items
                    If u.ID = l.IDUSUARIO Then
                        ComboUsuarios.SelectedItem = u
                        Exit For
                    End If
                Next
                DateDesde.Value = l.DESDE
                DateHasta.Value = l.HASTA
                '**********************************************************************
                Dim ano As Integer = 0
                Dim usuario As dUsuario = CType(ComboUsuarios.SelectedItem, dUsuario)
                Dim idusuario As Integer = usuario.ID
                Dim fechadesde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
                Dim fecdesde As String = Format(fechadesde, "yyyy-MM-dd")
                ano = fechadesde.Year
                Dim li As New dLicencias
                Dim diastomados As Integer = 0
                Dim diasdelicencia As Integer = 0
                Dim diasrestantes As Integer = 0
                Dim lista As New ArrayList
                lista = li.listarxanoxusuario(ano, idusuario)
                If Not lista Is Nothing Then
                    If lista.Count > 0 Then
                        For Each li In lista
                            diastomados = diastomados + li.DIAS
                        Next
                    End If
                End If
                diastomados = diastomados + Val(TextDias.Text.Trim)
                Dim la As New dLicenciaAnual
                la.ANO = ano
                la.FUNCIONARIO = idusuario
                la = la.buscarxanoxusuario
                diasdelicencia = la.DIAS
                diastomados = diastomados - diasguardados
                diasrestantes = diasdelicencia - diastomados
                TextDiasCorrespondientes.Text = diasdelicencia
                TextDiasRestantes.Text = diasrestantes
                'If diastomados > diasdelicencia Then
                '    MsgBox("Ha superado los diás de licencia para este año")
                '    Exit Sub
                'End If
                '**********************************************************************

            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Desde" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim l As New dLicencias
            id = row.Cells("Id").Value
            l.ID = id
            l = l.buscar
            If Not l Is Nothing Then
                TextId.Text = l.ID
                Dim u As dUsuario
                ComboUsuarios.SelectedItem = Nothing
                For Each u In ComboUsuarios.Items
                    If u.ID = l.IDUSUARIO Then
                        ComboUsuarios.SelectedItem = u
                        Exit For
                    End If
                Next
                DateDesde.Value = l.DESDE
                DateHasta.Value = l.HASTA
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Hasta" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim l As New dLicencias
            id = row.Cells("Id").Value
            l.ID = id
            l = l.buscar
            If Not l Is Nothing Then
                TextId.Text = l.ID
                Dim u As dUsuario
                ComboUsuarios.SelectedItem = Nothing
                For Each u In ComboUsuarios.Items
                    If u.ID = l.IDUSUARIO Then
                        ComboUsuarios.SelectedItem = u
                        Exit For
                    End If
                Next
                DateDesde.Value = l.DESDE
                DateHasta.Value = l.HASTA
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Aprobada" Then
            If Usuario.USUARIO = "MCF" Or Usuario.USUARIO = "PB" Then
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim id As Long = 0
                Dim l As New dLicencias
                l.ID = row.Cells("Id").Value
                l = l.buscar
                If l.APROBADA = 0 Then
                    l.marcaraprobada()
                    cargarLista()
                Else
                    l.desmarcaraprobada()
                    cargarLista()
                End If
            Else
                MsgBox("Esta acción no esta permitida")
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Imprimir" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim l As New dLicencias
            l.ID = row.Cells("Id").Value
            l = l.buscar
            If l.APROBADA = 1 Then
                l_usuario = l.IDUSUARIO
                l_desde = l.DESDE
                l_hasta = l.HASTA
                imprimir_licencia()
            Else
                MsgBox("La licencia seleccionada aún no está aprobada.")
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Eliminar" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim dias As Long = 0
            Dim usuarioId As Long = 0
            Dim l As New dLicencias
            l.ID = row.Cells("Id").Value
            l = l.buscar
            If (l.eliminar(Usuario)) Then
                cargarLista()
                MsgBox("Licencia eliminada.")
            Else
                MsgBox("La licencia seleccionada no se pudo eliminar.")
            End If
          
        End If
    End Sub
    Private Sub imprimir_licencia()
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

        Dim fila = 1
        Dim columna = 1

        x1hoja.Cells(fila, columna).formula = "COMPROBANTE DE APROBACIÓN DE LICENCIA"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 12
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = Now
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 2
        x1hoja.Cells(fila, columna).formula = "Este documento aprueba el pago del salario vacacional al siguiente funcionario/a:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        Dim u As New dUsuario
        u.ID = l_usuario
        u = u.buscar
        x1hoja.Cells(fila, columna).formula = u.NOMBRE
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Licencia aprobada desde " & l_desde & " hasta " & l_hasta & "."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 4
        x1hoja.Cells(fila, columna).formula = "Firma:  ______________________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10

        'Poner Titulos
        x1hoja.Shapes.AddPicture("c:\Debug\aprobada.jpg", _
         Microsoft.Office.Core.MsoTriState.msoFalse, _
         Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 150, 177, 50)

        Dim hoy As Date = Now
        Dim _dia As Integer = 0
        Dim _mes As Integer = 0
        Dim _ano As Integer = 0
        _dia = hoy.Day
        _mes = hoy.Month
        _ano = hoy.Year

        'Dim paginas As Integer = x1hoja.PageSetup.pages.count
        'x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        x1hoja.SaveAs("\\192.168.1.10\E\NET\LICENCIAS\" & u.NOMBRE & "_" & _dia & _mes & _ano & ".xls")
       


        x1app.Visible = True
        x1libro.PrintPreview()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub DateDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateDesde.ValueChanged
        calculardias()
    End Sub

    Private Sub DateHasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateHasta.ValueChanged
        calculardias()
    End Sub
    Private Sub calculardias()
        Dim totaldias As Integer = 0
        If TextId.Text.Length > 0 Then

            Dim desde As Date
            Dim hasta As Date
            Dim dias As TimeSpan

            Dim desde2 As Date
            Dim hasta2 As Date
            desde = DateDesde.Value.ToString("yyyy-MM-dd")
            hasta = DateHasta.Value.ToString("yyyy-MM-dd")
            desde2 = DateDesde.Value.ToString("yyyy-MM-dd")
            hasta2 = DateHasta.Value.ToString("yyyy-MM-dd")
            dias = hasta - desde
            totaldias = totaldias + dias.Days
            Do While desde2 <= hasta2
                If desde2.DayOfWeek = DayOfWeek.Sunday Then
                    totaldias = totaldias - 1
                End If
                Dim lista As New ArrayList
                Dim f As New dFeriados
                lista = f.listar
                If Not lista Is Nothing Then
                    If lista.Count > 0 Then
                        For Each f In lista
                            If desde2 = f.FECHA Then
                                totaldias = totaldias - 1
                            End If
                        Next
                    End If
                End If
                lista = Nothing
                f = Nothing
                desde2 = desde2.AddDays(1)
            Loop

        Else
            diasguardados = 0
            Dim desde As Date
            Dim hasta As Date
            Dim dias As TimeSpan
            Dim desde2 As Date
            Dim hasta2 As Date
            desde = DateDesde.Value.ToString("yyyy-MM-dd")
            hasta = DateHasta.Value.ToString("yyyy-MM-dd")
            desde2 = DateDesde.Value.ToString("yyyy-MM-dd")
            hasta2 = DateHasta.Value.ToString("yyyy-MM-dd")
            dias = hasta - desde
            totaldias = totaldias + dias.Days
            Do While desde2 <= hasta2
                If desde2.DayOfWeek = DayOfWeek.Sunday Then
                    totaldias = totaldias - 1
                End If
                Dim lista As New ArrayList
                Dim f As New dFeriados
                lista = f.listar
                If Not lista Is Nothing Then
                    If lista.Count > 0 Then
                        For Each f In lista
                            If desde2 = f.FECHA Then
                                totaldias = totaldias - 1
                            End If
                        Next
                    End If
                End If
                lista = Nothing
                f = Nothing
                desde2 = desde2.AddDays(1)
            Loop

        End If

        TextDias.Text = totaldias + 1
        diasguardados = TextDias.Text
    End Sub

    Private Sub ComboUsuarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboUsuarios.SelectedIndexChanged
        Dim ano As Integer = 0
        Dim usuario As dUsuario = CType(ComboUsuarios.SelectedItem, dUsuario)
        Dim idusuario As Integer = usuario.ID
        Dim fechadesde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String = Format(fechadesde, "yyyy-MM-dd")
        ano = fechadesde.Year
        Dim li As New dLicencias
        Dim diastomados As Integer = 0
        Dim diasdelicencia As Integer = 0
        Dim diasrestantes As Integer = 0
        Dim lista As New ArrayList
        lista = li.listarxanoxusuario(ano, idusuario)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each li In lista
                    diastomados = diastomados + li.DIAS
                Next
            End If
        End If
        diastomados = diastomados + Val(TextDias.Text.Trim)
        Dim la As New dLicenciaAnual
        la.ANO = ano
        la.FUNCIONARIO = idusuario
        la = la.buscarxanoxusuario
        diasdelicencia = la.DIAS
        diastomados = diastomados - diasguardados
        diasrestantes = diasdelicencia - diastomados
        TextDiasCorrespondientes.Text = diasdelicencia
        TextDiasRestantes.Text = diasrestantes
    End Sub

End Class