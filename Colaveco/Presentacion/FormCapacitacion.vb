Public Class FormCapacitacion
    Private _anio As Integer
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
        calcularano()
        listarcapacitacion()
        listararea()
        limpiar()
        'ingresarano()

    End Sub

#End Region

    'Private Sub ingresarano()
    '    Dim fecha As Date = Now
    '    Dim year As String = fecha.ToString("yyyy-MM-dd")
    '    Dim year2 As String = Mid(year, 1, 4)
    '    ComboAno.Text = year2
    'End Sub
    Private Sub calcularano()
        Dim hoy As Date = Now
        Dim ano As Integer = 0
        ano = hoy.Year
        _anio = hoy.Year
        NumericAno.Value = ano
    End Sub

    Private Sub listararea()
        Dim a As New dAreas
        Dim lista As New ArrayList
        lista = a.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each a In lista
                    ComboArea.Items.Add(a)
                Next
            End If
        End If
    End Sub
    Private Sub listarcapacitacion()
        Dim c As New dCapacitacionCab
        Dim a As New dAreas
        Dim t As New dCapacitacionTipo
        Dim lista As New ArrayList
        lista = c.listarxano(_anio)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridView1.Rows.Add(lista.Count)
        End If
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    DataGridView1(columna, fila).Value = c.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = c.ANO
                    columna = columna + 1
                    a.ID = c.AREA
                    a = a.buscar
                    If Not a Is Nothing Then
                        DataGridView1(columna, fila).Value = a.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "vacío"
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = c.OBJETIVOS
                    columna = 0
                    fila = fila + 1
                Next
            End If
        End If
    End Sub
    Private Sub ButtonCompletar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCompletar.Click
        Dim v As New FormCapacitacion2(Usuario)
        v.ShowDialog()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim ano As String = NumericAno.Value
        If ComboArea.Text.Trim.Length = 0 Then MsgBox("Debe ingresar el área", MsgBoxStyle.Exclamation, "Atención") : ComboArea.Focus() : Exit Sub
        Dim area As dAreas = CType(ComboArea.SelectedItem, dAreas)
        Dim objetivos As String = ""
        If TextObjetivos.Text <> "" Then
            objetivos = TextObjetivos.Text.Trim
        End If
        Dim capacitacion As String = ""
        If TextCapacitacion.Text <> "" Then
            capacitacion = TextCapacitacion.Text.Trim
        End If

        If TextId.Text.Trim.Length > 0 Then
            Dim c As New dCapacitacionCab
            Dim id As Long = TextId.Text.Trim
            c.ID = id
            c.ANO = ano
            c.AREA = area.ID
            c.OBJETIVOS = objetivos
            c.CAPACITACION = capacitacion
            If (c.modificar(Usuario)) Then
                MsgBox("Capacitación modificada", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim c As New dCapacitacionCab()
            c.ANO = ano
            c.AREA = area.ID
            c.OBJETIVOS = objetivos
            c.CAPACITACION = capacitacion
            If (c.guardar(Usuario)) Then
                MsgBox("Capacitación guardada", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If

        limpiar()

    End Sub
    Private Sub limpiar()
        calcularano()
        listarcapacitacion()
        TextId.Text = ""
        ComboArea.Text = ""
        TextObjetivos.Text = ""
        TextCapacitacion.Text = ""
        ComboArea.Focus()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If TextId.Text.Length > 0 Then
            Dim c As New dCapacitacionCab
            Dim id As Long = CType(TextId.Text, Long)
            c.ID = id
            If (c.eliminar(Usuario)) Then
                MsgBox("Registro eliminado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        limpiar()
        listarcapacitacion()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Ano" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dCapacitacionCab
            Dim a As New dAreas
            Dim t As New dCapacitacionTipo
            id = row.Cells("Id").Value
            c.ID = id
            c = c.buscar()
            If Not c Is Nothing Then
                TextId.Text = c.ID
                NumericAno.Value = c.ANO
                a.ID = c.AREA
                a = a.buscar
                ComboArea.Text = a.NOMBRE
                TextObjetivos.Text = c.OBJETIVOS
                TextCapacitacion.Text = c.CAPACITACION
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Area" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dCapacitacionCab
            Dim a As New dAreas
            Dim t As New dCapacitacionTipo
            id = row.Cells("Id").Value
            c.ID = id
            c = c.buscar()
            If Not c Is Nothing Then
                TextId.Text = c.ID
                NumericAno.Value = c.ANO
                a.ID = c.AREA
                a = a.buscar
                ComboArea.Text = a.NOMBRE
                TextObjetivos.Text = c.OBJETIVOS
                TextCapacitacion.Text = c.CAPACITACION
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Objetivos" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dCapacitacionCab
            Dim a As New dAreas
            Dim t As New dCapacitacionTipo
            id = row.Cells("Id").Value
            c.ID = id
            c = c.buscar()
            If Not c Is Nothing Then
                TextId.Text = c.ID
                NumericAno.Value = c.ANO
                a.ID = c.AREA
                a = a.buscar
                ComboArea.Text = a.NOMBRE
                TextObjetivos.Text = c.OBJETIVOS
                TextCapacitacion.Text = c.CAPACITACION
            End If
        End If

    End Sub


    Private Sub NumericAno_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericAno.ValueChanged
        _anio = NumericAno.Value
        listarcapacitacion()
    End Sub

    Private Sub ButtonCopia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCopia.Click
        Dim ano As String = NumericAno.Value
        ano = ano + 1
        If ComboArea.Text.Trim.Length = 0 Then MsgBox("Debe ingresar el área", MsgBoxStyle.Exclamation, "Atención") : ComboArea.Focus() : Exit Sub
        Dim area As dAreas = CType(ComboArea.SelectedItem, dAreas)
        Dim objetivos As String = ""
        If TextObjetivos.Text <> "" Then
            objetivos = TextObjetivos.Text.Trim
        End If
        Dim capacitacion As String = ""
        If TextCapacitacion.Text <> "" Then
            capacitacion = TextCapacitacion.Text.Trim
        End If

        Dim c As New dCapacitacionCab()
        c.ANO = ano
        c.AREA = area.ID
        c.OBJETIVOS = objetivos
        c.CAPACITACION = capacitacion
        If (c.guardar(Usuario)) Then
            MsgBox("Capacitación guardada", MsgBoxStyle.Information, "Atención")
        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        End If

        limpiar()
    End Sub
End Class