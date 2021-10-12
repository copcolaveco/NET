Public Class FormEstadisticas_Calidad
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
        cargarLista()
        limpiar()
    End Sub

#End Region
    Private Sub cargarlista()
        Dim ec As New dEstadisticaCalidad
        Dim lista As New ArrayList
        lista = ec.listar
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each ec In lista
                    DataGridView1(columna, fila).Value = ec.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ec.PERIODO
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ec.RB
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ec.RC
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ec.GR
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ec.PR
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ec.LA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ec.ST
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ec.CR
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ec.UR
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        TextPeriodo.Text = ""
        TextRB.Text = ""
        TextRB2.Text = ""
        TextRC.Text = ""
        TextRC2.Text = ""
        TextGR.Text = ""
        TextGR2.Text = ""
        TextPR.Text = ""
        TextPR2.Text = ""
        TextLA.Text = ""
        TextLA2.Text = ""
        TextST.Text = ""
        TextST2.Text = ""
        TextCR.Text = ""
        TextCR2.Text = ""
        TextUR.Text = ""
        TextUR2.Text = ""
        cargarlista()
        TextPeriodo.Focus()
    End Sub
    Private Sub guardar()
        If TextPeriodo.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el período", MsgBoxStyle.Exclamation, "Atención") : TextPeriodo.Focus() : Exit Sub
        Dim periodo As String = TextPeriodo.Text.Trim
        Dim rb As Double = TextRB.Text
        Dim rb2 As Integer = TextRB2.Text
        Dim rc As Double = TextRC.Text
        Dim rc2 As Integer = TextRC2.Text
        Dim gr As Double = TextGR.Text
        Dim gr2 As Integer = TextGR2.Text
        Dim pr As Double = TextPR.Text
        Dim pr2 As Integer = TextPR2.Text
        Dim la As Double = TextLA.Text
        Dim la2 As Integer = TextLA2.Text
        Dim st As Double = TextST.Text
        Dim st2 As Integer = TextST2.Text
        Dim cr As Double = TextCR.Text
        Dim cr2 As Integer = TextCR2.Text
        Dim ur As Double = TextUR.Text
        Dim ur2 As Integer = TextUR2.Text
        If TextId.Text <> "" Then
            Dim ec As New dEstadisticaCalidad
            Dim id As Long = TextId.Text.Trim
            ec.ID = id
            ec.PERIODO = periodo
            ec.RB = rb
            ec.RB_M = rb2
            ec.RC = rc
            ec.RC_M = rc2
            ec.GR = gr
            ec.GR_M = gr2
            ec.PR = pr
            ec.PR_M = pr2
            ec.LA = la
            ec.LA_M = la2
            ec.ST = st
            ec.ST_M = st2
            ec.CR = cr
            ec.CR_M = cr2
            ec.UR = ur
            ec.UR_M = ur2
            If (ec.modificar(Usuario)) Then
                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim ec As New dEstadisticaCalidad
            ec.PERIODO = periodo
            ec.RB = rb
            ec.RB_M = rb2
            ec.RC = rc
            ec.RC_M = rc2
            ec.GR = gr
            ec.GR_M = gr2
            ec.PR = pr
            ec.PR_M = pr2
            ec.LA = la
            ec.LA_M = la2
            ec.ST = st
            ec.ST_M = st2
            ec.CR = cr
            ec.CR_M = cr2
            ec.UR = ur
            ec.UR_M = ur2
            If (ec.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Id" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ec As New dEstadisticaCalidad
            id = row.Cells("Id").Value
            ec.ID = id
            ec = ec.buscar
            If Not ec Is Nothing Then
                TextId.Text = ec.ID
                TextPeriodo.Text = ec.PERIODO
                TextRB.Text = ec.RB
                TextRB2.Text = ec.RB_M
                TextRC.Text = ec.RC
                TextRC2.Text = ec.RC_M
                TextGR.Text = ec.GR
                TextGR2.Text = ec.GR_M
                TextPR.Text = ec.PR
                TextPR2.Text = ec.PR_M
                TextLA.Text = ec.LA
                TextLA2.Text = ec.LA_M
                TextST.Text = ec.ST
                TextST2.Text = ec.ST_M
                TextCR.Text = ec.CR
                TextCR2.Text = ec.CR_M
                TextUR.Text = ec.UR
                TextUR2.Text = ec.UR_M
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Fecha" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ec As New dEstadisticaCalidad
            id = row.Cells("Id").Value
            ec.ID = id
            ec = ec.buscar
            If Not ec Is Nothing Then
                TextId.Text = ec.ID
                TextPeriodo.Text = ec.PERIODO
                TextRB.Text = ec.RB
                TextRB2.Text = ec.RB_M
                TextRC.Text = ec.RC
                TextRC2.Text = ec.RC_M
                TextGR.Text = ec.GR
                TextGR2.Text = ec.GR_M
                TextPR.Text = ec.PR
                TextPR2.Text = ec.PR_M
                TextLA.Text = ec.LA
                TextLA2.Text = ec.LA_M
                TextST.Text = ec.ST
                TextST2.Text = ec.ST_M
                TextCR.Text = ec.CR
                TextCR2.Text = ec.CR_M
                TextUR.Text = ec.UR
                TextUR2.Text = ec.UR_M
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "RB" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ec As New dEstadisticaCalidad
            id = row.Cells("Id").Value
            ec.ID = id
            ec = ec.buscar
            If Not ec Is Nothing Then
                TextId.Text = ec.ID
                TextPeriodo.Text = ec.PERIODO
                TextRB.Text = ec.RB
                TextRB2.Text = ec.RB_M
                TextRC.Text = ec.RC
                TextRC2.Text = ec.RC_M
                TextGR.Text = ec.GR
                TextGR2.Text = ec.GR_M
                TextPR.Text = ec.PR
                TextPR2.Text = ec.PR_M
                TextLA.Text = ec.LA
                TextLA2.Text = ec.LA_M
                TextST.Text = ec.ST
                TextST2.Text = ec.ST_M
                TextCR.Text = ec.CR
                TextCR2.Text = ec.CR_M
                TextUR.Text = ec.UR
                TextUR2.Text = ec.UR_M
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "RC" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ec As New dEstadisticaCalidad
            id = row.Cells("Id").Value
            ec.ID = id
            ec = ec.buscar
            If Not ec Is Nothing Then
                TextId.Text = ec.ID
                TextPeriodo.Text = ec.PERIODO
                TextRB.Text = ec.RB
                TextRB2.Text = ec.RB_M
                TextRC.Text = ec.RC
                TextRC2.Text = ec.RC_M
                TextGR.Text = ec.GR
                TextGR2.Text = ec.GR_M
                TextPR.Text = ec.PR
                TextPR2.Text = ec.PR_M
                TextLA.Text = ec.LA
                TextLA2.Text = ec.LA_M
                TextST.Text = ec.ST
                TextST2.Text = ec.ST_M
                TextCR.Text = ec.CR
                TextCR2.Text = ec.CR_M
                TextUR.Text = ec.UR
                TextUR2.Text = ec.UR_M
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Grasa" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ec As New dEstadisticaCalidad
            id = row.Cells("Id").Value
            ec.ID = id
            ec = ec.buscar
            If Not ec Is Nothing Then
                TextId.Text = ec.ID
                TextPeriodo.Text = ec.PERIODO
                TextRB.Text = ec.RB
                TextRB2.Text = ec.RB_M
                TextRC.Text = ec.RC
                TextRC2.Text = ec.RC_M
                TextGR.Text = ec.GR
                TextGR2.Text = ec.GR_M
                TextPR.Text = ec.PR
                TextPR2.Text = ec.PR_M
                TextLA.Text = ec.LA
                TextLA2.Text = ec.LA_M
                TextST.Text = ec.ST
                TextST2.Text = ec.ST_M
                TextCR.Text = ec.CR
                TextCR2.Text = ec.CR_M
                TextUR.Text = ec.UR
                TextUR2.Text = ec.UR_M
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Proteina" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ec As New dEstadisticaCalidad
            id = row.Cells("Id").Value
            ec.ID = id
            ec = ec.buscar
            If Not ec Is Nothing Then
                TextId.Text = ec.ID
                TextPeriodo.Text = ec.PERIODO
                TextRB.Text = ec.RB
                TextRB2.Text = ec.RB_M
                TextRC.Text = ec.RC
                TextRC2.Text = ec.RC_M
                TextGR.Text = ec.GR
                TextGR2.Text = ec.GR_M
                TextPR.Text = ec.PR
                TextPR2.Text = ec.PR_M
                TextLA.Text = ec.LA
                TextLA2.Text = ec.LA_M
                TextST.Text = ec.ST
                TextST2.Text = ec.ST_M
                TextCR.Text = ec.CR
                TextCR2.Text = ec.CR_M
                TextUR.Text = ec.UR
                TextUR2.Text = ec.UR_M
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Lactosa" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ec As New dEstadisticaCalidad
            id = row.Cells("Id").Value
            ec.ID = id
            ec = ec.buscar
            If Not ec Is Nothing Then
                TextId.Text = ec.ID
                TextPeriodo.Text = ec.PERIODO
                TextRB.Text = ec.RB
                TextRB2.Text = ec.RB_M
                TextRC.Text = ec.RC
                TextRC2.Text = ec.RC_M
                TextGR.Text = ec.GR
                TextGR2.Text = ec.GR_M
                TextPR.Text = ec.PR
                TextPR2.Text = ec.PR_M
                TextLA.Text = ec.LA
                TextLA2.Text = ec.LA_M
                TextST.Text = ec.ST
                TextST2.Text = ec.ST_M
                TextCR.Text = ec.CR
                TextCR2.Text = ec.CR_M
                TextUR.Text = ec.UR
                TextUR2.Text = ec.UR_M
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "ST" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ec As New dEstadisticaCalidad
            id = row.Cells("Id").Value
            ec.ID = id
            ec = ec.buscar
            If Not ec Is Nothing Then
                TextId.Text = ec.ID
                TextPeriodo.Text = ec.PERIODO
                TextRB.Text = ec.RB
                TextRB2.Text = ec.RB_M
                TextRC.Text = ec.RC
                TextRC2.Text = ec.RC_M
                TextGR.Text = ec.GR
                TextGR2.Text = ec.GR_M
                TextPR.Text = ec.PR
                TextPR2.Text = ec.PR_M
                TextLA.Text = ec.LA
                TextLA2.Text = ec.LA_M
                TextST.Text = ec.ST
                TextST2.Text = ec.ST_M
                TextCR.Text = ec.CR
                TextCR2.Text = ec.CR_M
                TextUR.Text = ec.UR
                TextUR2.Text = ec.UR_M
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Crioscopia" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ec As New dEstadisticaCalidad
            id = row.Cells("Id").Value
            ec.ID = id
            ec = ec.buscar
            If Not ec Is Nothing Then
                TextId.Text = ec.ID
                TextPeriodo.Text = ec.PERIODO
                TextRB.Text = ec.RB
                TextRB2.Text = ec.RB_M
                TextRC.Text = ec.RC
                TextRC2.Text = ec.RC_M
                TextGR.Text = ec.GR
                TextGR2.Text = ec.GR_M
                TextPR.Text = ec.PR
                TextPR2.Text = ec.PR_M
                TextLA.Text = ec.LA
                TextLA2.Text = ec.LA_M
                TextST.Text = ec.ST
                TextST2.Text = ec.ST_M
                TextCR.Text = ec.CR
                TextCR2.Text = ec.CR_M
                TextUR.Text = ec.UR
                TextUR2.Text = ec.UR_M
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Urea" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ec As New dEstadisticaCalidad
            id = row.Cells("Id").Value
            ec.ID = id
            ec = ec.buscar
            If Not ec Is Nothing Then
                TextId.Text = ec.ID
                TextPeriodo.Text = ec.PERIODO
                TextRB.Text = ec.RB
                TextRB2.Text = ec.RB_M
                TextRC.Text = ec.RC
                TextRC2.Text = ec.RC_M
                TextGR.Text = ec.GR
                TextGR2.Text = ec.GR_M
                TextPR.Text = ec.PR
                TextPR2.Text = ec.PR_M
                TextLA.Text = ec.LA
                TextLA2.Text = ec.LA_M
                TextST.Text = ec.ST
                TextST2.Text = ec.ST_M
                TextCR.Text = ec.CR
                TextCR2.Text = ec.CR_M
                TextUR.Text = ec.UR
                TextUR2.Text = ec.UR_M
            End If
        End If
    End Sub
    Private Sub TextPeriodo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextPeriodo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextRB.Focus()
        End If
    End Sub
    Private Sub TextRB_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextRB.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextRB2.Focus()
        End If
    End Sub
    Private Sub TextRB2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextRB2.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextRC.Focus()
        End If
    End Sub
    Private Sub TextRC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextRC.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextRC2.Focus()
        End If
    End Sub
    Private Sub TextRC2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextRC2.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextGR.Focus()
        End If
    End Sub
    Private Sub TextGR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextGR.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextGR2.Focus()
        End If
    End Sub
    Private Sub TextGR2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextGR2.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextPR.Focus()
        End If
    End Sub
    Private Sub TextPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextPR.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextPR2.Focus()
        End If
    End Sub
    Private Sub TextPR2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextPR2.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextLA.Focus()
        End If
    End Sub
    Private Sub TextLA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextLA.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextLA2.Focus()
        End If
    End Sub
End Class