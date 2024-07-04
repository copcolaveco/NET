Public Class FormCapacitacion2
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
        cargarfuncionarios()
        cargarevaluacion()
        listartipo()
        cargarlista()
        checkearusuario()
        limpiar()

    End Sub

#End Region
    Private Sub checkearusuario()
        ComboFuncionario2.Enabled = False
        ButtonTodos.Enabled = False
        If Usuario.USUARIO = "MCF" Or Usuario.USUARIO = "CA" Or Usuario.USUARIO = "JMS" Or Usuario.USUARIO = "DF" Then
            ComboFuncionario2.Enabled = True
            ButtonTodos.Enabled = True
        Else
            ComboFuncionario2.Enabled = False
            ButtonTodos.Enabled = False
        End If
    End Sub
    Private Sub cargarlista()
        If Usuario.USUARIO = "MCF" Or Usuario.USUARIO = "CA" Or Usuario.USUARIO = "M" Or Usuario.USUARIO = "JMS" Or Usuario.USUARIO = "DF" Then
            Dim cl As New dCapacitacionLin
            Dim f As New dUsuario
            Dim c As New dCapacitacionCab
            Dim t As New dCapacitacionTipo
            Dim lista As New ArrayList
            lista = cl.listar
            DataGridView1.Rows.Clear()
            If Not lista Is Nothing Then
                DataGridView1.Rows.Add(lista.Count)
            End If
            Dim fila As Integer = 0
            Dim columna As Integer = 1
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each cl In lista
                        DataGridView1(columna, fila).Value = cl.ID
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = cl.DESDE
                        columna = columna + 1
                        f.ID = cl.IDUSUARIO
                        f = f.buscar
                        If Not f Is Nothing Then
                            DataGridView1(columna, fila).Value = f.NOMBRE
                            columna = columna + 1
                        Else
                            DataGridView1(columna, fila).Value = "vacío"
                            columna = columna + 1
                        End If
                        t.ID = cl.TIPO
                        t = t.buscar
                        If Not t Is Nothing Then
                            DataGridView1(columna, fila).Value = t.NOMBRE
                            columna = columna + 1
                        Else
                            DataGridView1(columna, fila).Value = "vacío"
                            columna = columna + 1
                        End If
                        DataGridView1(columna, fila).Value = cl.NOMBRE
                        columna = 1
                        'c.ID = cl.IDCAB
                        'c = c.buscar
                        'If Not c Is Nothing Then
                        '    DataGridView1(columna, fila).Value = c.CAPACITACION
                        '    columna = 0
                        'Else
                        '    DataGridView1(columna, fila).Value = "vacío"
                        '    columna = 0
                        'End If
                        fila = fila + 1
                    Next
                End If
            End If
        Else
            Dim user As Integer = Usuario.ID
            Dim cl As New dCapacitacionLin
            Dim f As New dUsuario
            Dim c As New dCapacitacionCab
            Dim t As New dCapacitacionTipo
            Dim lista As New ArrayList
            lista = cl.listarxusuario(user)
            DataGridView1.Rows.Clear()
            If Not lista Is Nothing Then
                DataGridView1.Rows.Add(lista.Count)
            End If
            Dim fila As Integer = 0
            Dim columna As Integer = 1
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each cl In lista
                        DataGridView1(columna, fila).Value = cl.ID
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = cl.DESDE
                        columna = columna + 1
                        f.ID = cl.IDUSUARIO
                        f = f.buscar
                        If Not f Is Nothing Then
                            DataGridView1(columna, fila).Value = f.NOMBRE
                            columna = columna + 1
                        Else
                            DataGridView1(columna, fila).Value = "vacío"
                            columna = columna + 1
                        End If
                        t.ID = cl.TIPO
                        t = t.buscar
                        If Not t Is Nothing Then
                            DataGridView1(columna, fila).Value = t.NOMBRE
                            columna = columna + 1
                        Else
                            DataGridView1(columna, fila).Value = "vacío"
                            columna = columna + 1
                        End If
                        DataGridView1(columna, fila).Value = cl.NOMBRE
                        columna = 1
                        'c.ID = cl.IDCAB
                        'c = c.buscar
                        'If Not c Is Nothing Then
                        '    DataGridView1(columna, fila).Value = c.CAPACITACION
                        '    columna = 0
                        'Else
                        '    DataGridView1(columna, fila).Value = "vacío"
                        '    columna = 0
                        'End If
                        fila = fila + 1
                    Next
                End If
            End If
        End If
    End Sub
    Private Sub ButtonSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSeleccionar.Click
        Dim v As New FormBuscarCapacitacion
        v.ShowDialog()
        If Not v.Capacitacion Is Nothing Then
            Dim cap As dCapacitacionCab = v.Capacitacion
            TextIdCapacitacion.Text = cap.ID
            TextCapacitacion.Text = cap.CAPACITACION
            TextArea.Text = cap.AREA
            ComboFuncionario.Focus()
        End If
    End Sub
    Private Sub listartipo()
        Dim t As New dCapacitacionTipo
        Dim lista As New ArrayList
        lista = t.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each t In lista
                    ComboTipo.Items.Add(t)
                Next
            End If
        End If
    End Sub
    Public Sub cargarfuncionarios()
        Dim p As New dUsuario
        Dim lista As New ArrayList
        lista = p.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each p In lista
                    ComboFuncionario.Items.Add(p)
                    ComboFuncionario2.Items.Add(p)
                Next
            End If
        End If
    End Sub
    Public Sub cargarevaluacion()
        Dim e As New dCapacitacionEv
        Dim lista As New ArrayList
        lista = e.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each e In lista
                    ComboEvaluacion1.Items.Add(e)
                    ComboEvaluacion2.Items.Add(e)
                Next
            End If
        End If
    End Sub



    Private Sub ButtonVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCompletar.Click
        Dim tipocap As dCapacitacionTipo = CType(ComboTipo.SelectedItem, dCapacitacionTipo)
        Dim func As dUsuario = CType(ComboFuncionario.SelectedItem, dUsuario)
        Dim fechad As Date = DateDesde.Value
        Dim fechah As Date = DateHasta.Value
        Dim hor As String = TextHoras.Text
        If TextId.Text <> "" Then
            idlincapacitacion = TextId.Text.Trim
            Dim v As New FormPlanillaCapacitacion(Usuario, tipocap.ID, func.ID, fechad, fechah, hor)
            v.ShowDialog()
        End If
    End Sub
    Private Sub guardar()
        If TextIdCapacitacion.Text.Trim.Length = 0 Then MsgBox("Debe seleccionar una capacitación", MsgBoxStyle.Exclamation, "Atención") : ButtonSeleccionar.Focus() : Exit Sub
        Dim idcab As Long = TextIdCapacitacion.Text.Trim
        Dim area As Integer = TextArea.Text.Trim
        If ComboTipo.Text.Trim.Length = 0 Then MsgBox("Debe ingresar un tipo de capacitación", MsgBoxStyle.Exclamation, "Atención") : ComboTipo.Focus() : Exit Sub
        Dim tipo As dCapacitacionTipo = CType(ComboTipo.SelectedItem, dCapacitacionTipo)
        Dim nombre As String = ""
        If TextNombre.Text <> "" Then
            nombre = TextNombre.Text.Trim
        Else
            nombre = "Taller interno"
        End If
        Dim descripcion As String = ""
        If TextDescripcion.Text <> "" Then
            descripcion = TextDescripcion.Text.Trim
        End If
        If ComboFuncionario.Text.Trim.Length = 0 Then MsgBox("Debe seleccionar un funcionario", MsgBoxStyle.Exclamation, "Atención") : ComboFuncionario.Focus() : Exit Sub
        Dim funcionario As dUsuario = CType(ComboFuncionario.SelectedItem, dUsuario)
        Dim fechadesde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        If TextHoras.Text.Trim.Length = 0 Then MsgBox("Debe ingresar la cantidad de horas", MsgBoxStyle.Exclamation, "Atención") : TextHoras.Focus() : Exit Sub
        Dim horas As Integer = TextHoras.Text.Trim
        If ComboEvaluacion1.Text.Trim.Length = 0 Then MsgBox("Debe ingresar la evaluación personal", MsgBoxStyle.Exclamation, "Atención") : ComboEvaluacion1.Focus() : Exit Sub
        Dim evaluacion1 As dCapacitacionEv = CType(ComboEvaluacion1.SelectedItem, dCapacitacionEv)
        'If ComboEvaluacion2.Text.Trim.Length = 0 Then MsgBox("Debe ingresar la evaluación de la dirección", MsgBoxStyle.Exclamation, "Atención") : ComboEvaluacion2.Focus() : Exit Sub
        Dim evaluacion2 As dCapacitacionEv = CType(ComboEvaluacion2.SelectedItem, dCapacitacionEv)
        If TextId.Text.Trim.Length > 0 Then
            Dim cl As New dCapacitacionLin
            Dim id As Long = TextId.Text.Trim
            Dim fecdesde As String
            Dim fechasta As String
            fecdesde = Format(fechadesde, "yyyy-MM-dd")
            fechasta = Format(fechahasta, "yyyy-MM-dd")
            cl.ID = id
            cl.IDCAB = idcab
            cl.AREA = area
            cl.TIPO = tipo.ID
            If nombre <> "" Then
                cl.NOMBRE = nombre
            End If
            If descripcion <> "" Then
                cl.DESCRIPCION = descripcion
            End If
            cl.IDUSUARIO = funcionario.ID
            cl.DESDE = fecdesde
            cl.HASTA = fechasta
            cl.HORAS = horas
            cl.EVALUACION1 = evaluacion1.ID
            If Not evaluacion2 Is Nothing Then
                cl.EVALUACION2 = evaluacion2.ID
            Else
                cl.EVALUACION2 = 0
            End If
            If (cl.modificar(Usuario)) Then
                MsgBox("Capacitación modificada", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim cl As New dCapacitacionLin()
            Dim fecdesde As String
            Dim fechasta As String
            fecdesde = Format(fechadesde, "yyyy-MM-dd")
            fechasta = Format(fechahasta, "yyyy-MM-dd")
            cl.IDCAB = idcab
            cl.AREA = area
            cl.TIPO = tipo.ID
            If nombre <> "" Then
                cl.NOMBRE = nombre
            End If
            If descripcion <> "" Then
                cl.DESCRIPCION = descripcion
            End If
            cl.IDUSUARIO = funcionario.ID
            cl.DESDE = fecdesde
            cl.HASTA = fechasta
            cl.HORAS = horas
            cl.EVALUACION1 = evaluacion1.ID
            If Not evaluacion2 Is Nothing Then
                cl.EVALUACION2 = evaluacion2.ID
            Else
                cl.EVALUACION2 = 0
            End If
            If (cl.guardar(Usuario)) Then
                MsgBox("Capacitación guardada", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If

        limpiar()
        cargarlista()
    End Sub
    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub
    Private Sub limpiar()
        cargarlista()
        TextId.Text = ""
        TextIdCapacitacion.Text = ""
        TextCapacitacion.Text = ""
        TextArea.Text = ""
        ComboTipo.Text = ""
        TextNombre.Text = ""
        TextDescripcion.Text = ""
        ComboFuncionario.Text = ""
        DateDesde.Value = Now()
        DateHasta.Value = Now()
        TextHoras.Text = ""
        ComboEvaluacion2.Text = ""
        ComboEvaluacion1.Text = ""
        ButtonSeleccionar.Focus()
    End Sub
    Private Sub limpiar2()
        'cargarlista()
        TextId.Text = ""
        TextIdCapacitacion.Text = ""
        TextCapacitacion.Text = ""
        ComboTipo.Text = ""
        TextNombre.Text = ""
        TextDescripcion.Text = ""
        ComboFuncionario.Text = ""
        DateDesde.Value = Now
        DateHasta.Value = Now
        TextHoras.Text = ""
        ComboEvaluacion2.Text = ""
        ComboEvaluacion1.Text = ""
        ComboFuncionario.Focus()
    End Sub
    Private Sub FormCapacitacion2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "X" Then
            limpiar2()
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim cl As New dCapacitacionLin
            Dim c As New dCapacitacionCab
            Dim t As New dCapacitacionTipo
            Dim f As New dUsuario
            Dim ev As New dCapacitacionEv
            id = row.Cells("Id").Value
            cl.ID = id
            cl = cl.buscar()
            If Not cl Is Nothing Then
                'TextId.Text = cl.ID
                c.ID = cl.IDCAB
                c = c.buscar
                If Not c Is Nothing Then
                    TextIdCapacitacion.Text = c.ID
                    TextCapacitacion.Text = c.CAPACITACION
                End If
                TextArea.Text = cl.AREA
                ComboTipo.SelectedItem = Nothing
                For Each t In ComboTipo.Items
                    If t.ID = cl.TIPO Then
                        ComboTipo.SelectedItem = t
                        Exit For
                    End If
                Next
                TextNombre.Text = cl.NOMBRE
                TextDescripcion.Text = cl.DESCRIPCION
                ComboFuncionario.SelectedItem = Nothing
                'For Each f In ComboFuncionario.Items
                '    If f.ID = cl.IDUSUARIO Then
                '        ComboFuncionario.SelectedItem = f
                '        Exit For
                '    End If
                'Next
                DateDesde.Value = cl.DESDE
                DateHasta.Value = cl.HASTA
                TextHoras.Text = cl.HORAS
                ComboEvaluacion1.SelectedItem = Nothing
                For Each ev In ComboEvaluacion1.Items
                    If ev.ID = cl.EVALUACION1 Then
                        ComboEvaluacion1.SelectedItem = ev
                        Exit For
                    End If
                Next
                ComboEvaluacion2.SelectedItem = Nothing
                For Each ev In ComboEvaluacion2.Items
                    If ev.ID = cl.EVALUACION2 Then
                        ComboEvaluacion2.SelectedItem = ev
                        Exit For
                    End If
                Next
                't.ID = cl.TIPO
                't = t.buscar
                'If Not t Is Nothing Then

                'End If
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Fecha" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim cl As New dCapacitacionLin
            Dim c As New dCapacitacionCab
            Dim t As New dCapacitacionTipo
            Dim f As New dUsuario
            Dim ev As New dCapacitacionEv
            id = row.Cells("Id").Value
            cl.ID = id
            cl = cl.buscar()
            If Not cl Is Nothing Then
                TextId.Text = cl.ID
                c.ID = cl.IDCAB
                c = c.buscar
                If Not c Is Nothing Then
                    TextIdCapacitacion.Text = c.ID
                    TextCapacitacion.Text = c.CAPACITACION
                End If
                TextArea.Text = cl.AREA
                ComboTipo.SelectedItem = Nothing
                For Each t In ComboTipo.Items
                    If t.ID = cl.TIPO Then
                        ComboTipo.SelectedItem = t
                        Exit For
                    End If
                Next
                TextNombre.Text = cl.NOMBRE
                TextDescripcion.Text = cl.DESCRIPCION
                ComboFuncionario.SelectedItem = Nothing
                For Each f In ComboFuncionario.Items
                    If f.ID = cl.IDUSUARIO Then
                        ComboFuncionario.SelectedItem = f
                        Exit For
                    End If
                Next
                DateDesde.Value = cl.DESDE
                DateHasta.Value = cl.HASTA
                TextHoras.Text = cl.HORAS
                ComboEvaluacion1.SelectedItem = Nothing
                For Each ev In ComboEvaluacion1.Items
                    If ev.ID = cl.EVALUACION1 Then
                        ComboEvaluacion1.SelectedItem = ev
                        Exit For
                    End If
                Next
                ComboEvaluacion2.SelectedItem = Nothing
                For Each ev In ComboEvaluacion2.Items
                    If ev.ID = cl.EVALUACION2 Then
                        ComboEvaluacion2.SelectedItem = ev
                        Exit For
                    End If
                Next
                't.ID = cl.TIPO
                't = t.buscar
                'If Not t Is Nothing Then

                'End If
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Funcionario" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim cl As New dCapacitacionLin
            Dim c As New dCapacitacionCab
            Dim t As New dCapacitacionTipo
            Dim f As New dUsuario
            Dim ev As New dCapacitacionEv
            id = row.Cells("Id").Value
            cl.ID = id
            cl = cl.buscar()
            If Not cl Is Nothing Then
                TextId.Text = cl.ID
                c.ID = cl.IDCAB
                c = c.buscar
                If Not c Is Nothing Then
                    TextIdCapacitacion.Text = c.ID
                    TextCapacitacion.Text = c.CAPACITACION
                End If
                TextArea.Text = cl.AREA
                ComboTipo.SelectedItem = Nothing
                For Each t In ComboTipo.Items
                    If t.ID = cl.TIPO Then
                        ComboTipo.SelectedItem = t
                        Exit For
                    End If
                Next
                TextNombre.Text = cl.NOMBRE
                TextDescripcion.Text = cl.DESCRIPCION
                ComboFuncionario.SelectedItem = Nothing
                For Each f In ComboFuncionario.Items
                    If f.ID = cl.IDUSUARIO Then
                        ComboFuncionario.SelectedItem = f
                        Exit For
                    End If
                Next
                DateDesde.Value = cl.DESDE
                DateHasta.Value = cl.HASTA
                TextHoras.Text = cl.HORAS
                ComboEvaluacion1.SelectedItem = Nothing
                For Each ev In ComboEvaluacion1.Items
                    If ev.ID = cl.EVALUACION1 Then
                        ComboEvaluacion1.SelectedItem = ev
                        Exit For
                    End If
                Next
                ComboEvaluacion2.SelectedItem = Nothing
                For Each ev In ComboEvaluacion2.Items
                    If ev.ID = cl.EVALUACION2 Then
                        ComboEvaluacion2.SelectedItem = ev
                        Exit For
                    End If
                Next
                't.ID = cl.TIPO
                't = t.buscar
                'If Not t Is Nothing Then

                'End If
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Tipo" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim cl As New dCapacitacionLin
            Dim c As New dCapacitacionCab
            Dim t As New dCapacitacionTipo
            Dim f As New dUsuario
            Dim ev As New dCapacitacionEv
            id = row.Cells("Id").Value
            cl.ID = id
            cl = cl.buscar()
            If Not cl Is Nothing Then
                TextId.Text = cl.ID
                c.ID = cl.IDCAB
                c = c.buscar
                If Not c Is Nothing Then
                    TextIdCapacitacion.Text = c.ID
                    TextCapacitacion.Text = c.CAPACITACION
                End If
                TextArea.Text = cl.AREA
                ComboTipo.SelectedItem = Nothing
                For Each t In ComboTipo.Items
                    If t.ID = cl.TIPO Then
                        ComboTipo.SelectedItem = t
                        Exit For
                    End If
                Next
                TextNombre.Text = cl.NOMBRE
                TextDescripcion.Text = cl.DESCRIPCION
                ComboFuncionario.SelectedItem = Nothing
                For Each f In ComboFuncionario.Items
                    If f.ID = cl.IDUSUARIO Then
                        ComboFuncionario.SelectedItem = f
                        Exit For
                    End If
                Next
                DateDesde.Value = cl.DESDE
                DateHasta.Value = cl.HASTA
                TextHoras.Text = cl.HORAS
                ComboEvaluacion1.SelectedItem = Nothing
                For Each ev In ComboEvaluacion1.Items
                    If ev.ID = cl.EVALUACION1 Then
                        ComboEvaluacion1.SelectedItem = ev
                        Exit For
                    End If
                Next
                ComboEvaluacion2.SelectedItem = Nothing
                For Each ev In ComboEvaluacion2.Items
                    If ev.ID = cl.EVALUACION2 Then
                        ComboEvaluacion2.SelectedItem = ev
                        Exit For
                    End If
                Next
                't.ID = cl.TIPO
                't = t.buscar
                'If Not t Is Nothing Then

                'End If
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Capacitacion" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim cl As New dCapacitacionLin
            Dim c As New dCapacitacionCab
            Dim t As New dCapacitacionTipo
            Dim f As New dUsuario
            Dim ev As New dCapacitacionEv
            id = row.Cells("Id").Value
            cl.ID = id
            cl = cl.buscar()
            If Not cl Is Nothing Then
                TextId.Text = cl.ID
                c.ID = cl.IDCAB
                c = c.buscar
                If Not c Is Nothing Then
                    TextIdCapacitacion.Text = c.ID
                    TextCapacitacion.Text = c.CAPACITACION
                End If
                TextArea.Text = cl.AREA
                ComboTipo.SelectedItem = Nothing
                For Each t In ComboTipo.Items
                    If t.ID = cl.TIPO Then
                        ComboTipo.SelectedItem = t
                        Exit For
                    End If
                Next
                TextNombre.Text = cl.NOMBRE
                TextDescripcion.Text = cl.DESCRIPCION
                ComboFuncionario.SelectedItem = Nothing
                For Each f In ComboFuncionario.Items
                    If f.ID = cl.IDUSUARIO Then
                        ComboFuncionario.SelectedItem = f
                        Exit For
                    End If
                Next
                DateDesde.Value = cl.DESDE
                DateHasta.Value = cl.HASTA
                TextHoras.Text = cl.HORAS
                ComboEvaluacion1.SelectedItem = Nothing
                For Each ev In ComboEvaluacion1.Items
                    If ev.ID = cl.EVALUACION1 Then
                        ComboEvaluacion1.SelectedItem = ev
                        Exit For
                    End If
                Next
                ComboEvaluacion2.SelectedItem = Nothing
                For Each ev In ComboEvaluacion2.Items
                    If ev.ID = cl.EVALUACION2 Then
                        ComboEvaluacion2.SelectedItem = ev
                        Exit For
                    End If
                Next
                't.ID = cl.TIPO
                't = t.buscar
                'If Not t Is Nothing Then

                'End If
            End If
        End If
    End Sub

    Private Sub ButtonNueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNueva.Click
        limpiar()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If TextId.Text.Length > 0 Then
            Dim cl As New dCapacitacionLin
            Dim id As Long = CType(TextId.Text, Long)
            cl.ID = id
            If (cl.eliminar(Usuario)) Then
                MsgBox("Registro eliminado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        limpiar()
        cargarlista()
    End Sub
    Private Sub listarxfuncionario()
        Dim funcionario As dUsuario = CType(ComboFuncionario2.SelectedItem, dUsuario)
        Dim user As Integer = funcionario.ID
        Dim cl As New dCapacitacionLin
        Dim f As New dUsuario
        Dim c As New dCapacitacionCab
        Dim t As New dCapacitacionTipo
        Dim lista As New ArrayList
        lista = cl.listarxusuario(user)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridView1.Rows.Add(lista.Count)
        End If
        Dim fila As Integer = 0
        Dim columna As Integer = 1
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each cl In lista
                    DataGridView1(columna, fila).Value = cl.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = cl.DESDE
                    columna = columna + 1
                    f.ID = cl.IDUSUARIO
                    f = f.buscar
                    If Not f Is Nothing Then
                        DataGridView1(columna, fila).Value = f.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "vacío"
                        columna = columna + 1
                    End If
                    t.ID = cl.TIPO
                    t = t.buscar
                    If Not t Is Nothing Then
                        DataGridView1(columna, fila).Value = t.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "vacío"
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = cl.NOMBRE
                    columna = 1
                    'c.ID = cl.IDCAB
                    'c = c.buscar
                    'If Not c Is Nothing Then
                    '    DataGridView1(columna, fila).Value = c.CAPACITACION
                    '    columna = 0
                    'Else
                    '    DataGridView1(columna, fila).Value = "vacío"
                    '    columna = 0
                    'End If
                    fila = fila + 1
                Next
            End If
        End If
    End Sub
    Private Sub listartodos()
        Dim cl As New dCapacitacionLin
        Dim f As New dUsuario
        Dim c As New dCapacitacionCab
        Dim t As New dCapacitacionTipo
        Dim lista As New ArrayList
        lista = cl.listar
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridView1.Rows.Add(lista.Count)
        End If
        Dim fila As Integer = 0
        Dim columna As Integer = 1
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each cl In lista
                    DataGridView1(columna, fila).Value = cl.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = cl.DESDE
                    columna = columna + 1
                    f.ID = cl.IDUSUARIO
                    f = f.buscar
                    If Not f Is Nothing Then
                        DataGridView1(columna, fila).Value = f.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "vacío"
                        columna = columna + 1
                    End If
                    t.ID = cl.TIPO
                    t = t.buscar
                    If Not t Is Nothing Then
                        DataGridView1(columna, fila).Value = t.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "vacío"
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = cl.NOMBRE
                    columna = 1
                    'c.ID = cl.IDCAB
                    'c = c.buscar
                    'If Not c Is Nothing Then
                    '    DataGridView1(columna, fila).Value = c.CAPACITACION
                    '    columna = 0
                    'Else
                    '    DataGridView1(columna, fila).Value = "vacío"
                    '    columna = 0
                    'End If
                    fila = fila + 1
                Next
            End If
        End If
    End Sub
    Private Sub ComboFuncionario2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboFuncionario2.SelectedIndexChanged

        listarxfuncionario()
    End Sub

    Private Sub ButtonTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTodos.Click
        listartodos()
    End Sub


    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub ButtonInformes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonInformes.Click
        Dim v As New FormInformesCapacitacion
        v.ShowDialog()
    End Sub
End Class