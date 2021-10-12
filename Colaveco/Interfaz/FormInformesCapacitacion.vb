Public Class FormInformesCapacitacion
#Region "Atributos"
   
#End Region
#Region "Constructores"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cargarpordefecto()
        cargarfuncionarios()
        cargarareas()

    End Sub

#End Region
    Private Sub cargarfuncionarios()
        Dim p As New dUsuario
        Dim lista As New ArrayList
        lista = p.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each p In lista
                    ComboFuncionarios.Items.Add(p)
                Next
            End If
        End If
    End Sub
    Private Sub cargarareas()
        Dim a As New dAreas
        Dim lista As New ArrayList
        lista = a.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each a In lista
                    ComboAreas.Items.Add(a)
                Next
            End If
        End If
    End Sub
    Private Sub cargarpordefecto()
        RadioTodos.Checked = True
        ComboFuncionarios.Enabled = False
        ComboAreas.Enabled = False
    End Sub
    Private Sub seleccionar()
        If RadioTodos.Checked = True Then
            RadioFuncionario.Checked = False
            RadioArea.Checked = False
            ComboFuncionarios.Enabled = False
            ComboAreas.Enabled = False
        ElseIf RadioFuncionario.Checked = True Then
            RadioTodos.Checked = False
            RadioArea.Checked = False
            ComboFuncionarios.Enabled = True
            ComboAreas.Enabled = False
        ElseIf RadioArea.Checked = True Then
            RadioTodos.Checked = False
            RadioFuncionario.Checked = False
            ComboFuncionarios.Enabled = False
            ComboAreas.Enabled = True
        End If
    End Sub

    Private Sub RadioTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioTodos.CheckedChanged
        seleccionar()
    End Sub

    Private Sub RadioFuncionario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioFuncionario.CheckedChanged
        seleccionar()
    End Sub

    Private Sub RadioArea_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioArea.CheckedChanged
        seleccionar()
    End Sub

    Private Sub ButtonListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListar.Click
        If RadioTodos.Checked = True Then
            listartodos()
        ElseIf RadioFuncionario.Checked = True Then
            listarxfuncionario()
        ElseIf RadioArea.Checked = True Then
            listarxarea()
        End If
    End Sub
    Private Sub listartodos()
        Dim cl As New dCapacitacionLin
        Dim lista As New ArrayList
        Dim curso As Integer = 0
        Dim tallere As Integer = 0
        Dim congreso As Integer = 0
        Dim talleri As Integer = 0
        Dim entrenamiento As Integer = 0
        Dim seminario As Integer = 0
        Dim horas As Integer = 0
        Dim totalhoras As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = cl.listarxfecha(fecdesde, fechasta)
        DataGridView1.Rows.Clear()
        DataGridView1.Rows.Add(7)
        'ListPendientes.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each cl In lista
                    horas = Val(cl.HORAS)
                    If cl.TIPO = 1 Then
                        curso = curso + horas
                    ElseIf cl.TIPO = 2 Then
                        tallere = tallere + horas
                    ElseIf cl.TIPO = 3 Then
                        congreso = congreso + horas
                    ElseIf cl.TIPO = 4 Then
                        talleri = talleri + horas
                    ElseIf cl.TIPO = 5 Then
                        entrenamiento = entrenamiento + horas
                    ElseIf cl.TIPO = 6 Then
                        seminario = seminario + horas
                    End If
                Next
            End If
            totalhoras = curso + tallere + talleri + congreso + entrenamiento + seminario
            DataGridView1(0, 0).Value = "Curso"
            DataGridView1(1, 0).Value = curso
            DataGridView1(0, 1).Value = "Taller externo"
            DataGridView1(1, 1).Value = tallere
            DataGridView1(0, 2).Value = "Congreso"
            DataGridView1(1, 2).Value = congreso
            DataGridView1(0, 3).Value = "Taller interno"
            DataGridView1(1, 3).Value = talleri
            DataGridView1(0, 4).Value = "Entrenamiento"
            DataGridView1(1, 4).Value = entrenamiento
            DataGridView1(0, 5).Value = "Seminario"
            DataGridView1(1, 5).Value = seminario
            DataGridView1(0, 6).Value = "Total horas"
            DataGridView1(1, 6).Value = totalhoras
        End If
    End Sub
    Private Sub listarxfuncionario()
        Dim cl As New dCapacitacionLin
        If ComboFuncionarios.Text.Trim.Length = 0 Then MsgBox("Debe seleccionar un funcionario", MsgBoxStyle.Exclamation, "Atención") : ComboFuncionarios.Focus() : Exit Sub
        Dim funcionario As dUsuario = CType(ComboFuncionarios.SelectedItem, dUsuario)
        Dim user As Integer = funcionario.ID
        Dim lista As New ArrayList
        Dim curso As Integer = 0
        Dim tallere As Integer = 0
        Dim congreso As Integer = 0
        Dim talleri As Integer = 0
        Dim entrenamiento As Integer = 0
        Dim seminario As Integer = 0
        Dim horas As Integer = 0
        Dim totalhoras As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = cl.listarxfechaxusuario(fecdesde, fechasta, user)
        DataGridView1.Rows.Clear()
        DataGridView1.Rows.Add(7)
        'ListPendientes.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each cl In lista
                    horas = Val(cl.HORAS)
                    If cl.TIPO = 1 Then
                        curso = curso + horas
                    ElseIf cl.TIPO = 2 Then
                        tallere = tallere + horas
                    ElseIf cl.TIPO = 3 Then
                        congreso = congreso + horas
                    ElseIf cl.TIPO = 4 Then
                        talleri = talleri + horas
                    ElseIf cl.TIPO = 5 Then
                        entrenamiento = entrenamiento + horas
                    ElseIf cl.TIPO = 6 Then
                        seminario = seminario + horas
                    End If
                Next
            End If
            totalhoras = curso + tallere + talleri + congreso + entrenamiento + seminario
            DataGridView1(0, 0).Value = "Curso"
            DataGridView1(1, 0).Value = curso
            DataGridView1(0, 1).Value = "Taller externo"
            DataGridView1(1, 1).Value = tallere
            DataGridView1(0, 2).Value = "Congreso"
            DataGridView1(1, 2).Value = congreso
            DataGridView1(0, 3).Value = "Taller interno"
            DataGridView1(1, 3).Value = talleri
            DataGridView1(0, 4).Value = "Entrenamiento"
            DataGridView1(1, 4).Value = entrenamiento
            DataGridView1(0, 5).Value = "Seminario"
            DataGridView1(1, 5).Value = seminario
            DataGridView1(0, 6).Value = "Total horas"
            DataGridView1(1, 6).Value = totalhoras
        End If
    End Sub
    Private Sub listarxarea()
        Dim cl As New dCapacitacionLin
        If ComboAreas.Text.Trim.Length = 0 Then MsgBox("Debe seleccionar un área", MsgBoxStyle.Exclamation, "Atención") : ComboAreas.Focus() : Exit Sub
        Dim idarea As dAreas = CType(ComboAreas.SelectedItem, dAreas)
        Dim area As Integer = idarea.ID
        Dim lista As New ArrayList
        Dim curso As Integer = 0
        Dim tallere As Integer = 0
        Dim congreso As Integer = 0
        Dim talleri As Integer = 0
        Dim entrenamiento As Integer = 0
        Dim seminario As Integer = 0
        Dim horas As Integer = 0
        Dim totalhoras As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = cl.listarxfechaxarea(fecdesde, fechasta, area)
        DataGridView1.Rows.Clear()
        DataGridView1.Rows.Add(7)
        'ListPendientes.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each cl In lista
                    horas = Val(cl.HORAS)
                    If cl.TIPO = 1 Then
                        curso = curso + horas
                    ElseIf cl.TIPO = 2 Then
                        tallere = tallere + horas
                    ElseIf cl.TIPO = 3 Then
                        congreso = congreso + horas
                    ElseIf cl.TIPO = 4 Then
                        talleri = talleri + horas
                    ElseIf cl.TIPO = 5 Then
                        entrenamiento = entrenamiento + horas
                    ElseIf cl.TIPO = 6 Then
                        seminario = seminario + horas
                    End If
                Next
            End If
            totalhoras = curso + tallere + talleri + congreso + entrenamiento
            DataGridView1(0, 0).Value = "Curso"
            DataGridView1(1, 0).Value = curso
            DataGridView1(0, 1).Value = "Taller externo"
            DataGridView1(1, 1).Value = tallere
            DataGridView1(0, 2).Value = "Congreso"
            DataGridView1(1, 2).Value = congreso
            DataGridView1(0, 3).Value = "Taller interno"
            DataGridView1(1, 3).Value = talleri
            DataGridView1(0, 4).Value = "Entrenamiento"
            DataGridView1(1, 4).Value = entrenamiento
            DataGridView1(0, 5).Value = "Seminario"
            DataGridView1(1, 5).Value = seminario
            DataGridView1(0, 6).Value = "Total horas"
            DataGridView1(1, 6).Value = totalhoras
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class