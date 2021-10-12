Public Class FormControlGrasaProteina
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
        DateFecha.Value = Now
        TextOperador.Text = Usuario.NOMBRE
        cargarlista()
        TextBentleyG.Focus()
    End Sub
#End Region
    Private Sub cargarlista()
       
        Dim c As New dControlGrasaProteina
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
                    DataGridView1(columna, fila).Value = c.FECHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = c.BENTLEYG
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = c.DELTAG
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = c.ROSEGOTTLIEBG
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = c.GERBERG
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = c.BENTLEYP
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = c.DELTAP
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = c.DUMASP
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = c.KJELDAHP
                    columna = columna + 1
                    Dim u As New dUsuario
                    u.ID = c.OPERADOR
                    u = u.buscar
                    DataGridView1(columna, fila).Value = u.NOMBRE
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Private Sub guardar()
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim bentleyg As Double = -1
        Dim deltag As Double = -1
        Dim rosegottliebg As Double = -1
        Dim gerberg As Double = -1
        Dim bentleyp As Double = -1
        Dim deltap As Double = -1
        Dim dumasp As Double = -1
        Dim kjeldahp As Double = -1
        Dim usu As Integer = Usuario.ID
        If TextBentleyG.Text <> "" Then
            bentleyg = TextBentleyG.Text.Trim
        End If
        If TextDeltaG.Text <> "" Then
            deltag = TextDeltaG.Text.Trim
        End If
        If TextRoseGottliebG.Text <> "" Then
            rosegottliebg = TextRoseGottliebG.Text.Trim
        End If
        If TextGerberG.Text <> "" Then
            gerberg = TextBentleyG.Text.Trim
        End If
        If TextBentleyP.Text <> "" Then
            bentleyp = TextBentleyP.Text.Trim
        End If
        If TextDeltaP.Text <> "" Then
            deltap = TextDeltaP.Text.Trim
        End If
        If TextDumasP.Text <> "" Then
            dumasp = TextDumasP.Text.Trim
        End If
        If TextKjeldahP.Text <> "" Then
            kjeldahp = TextBentleyP.Text.Trim
        End If

        If TextId.Text.Trim.Length > 0 Then
            Dim c As New dControlGrasaProteina
            Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            c.ID = id
            c.FECHA = fec
            c.BENTLEYG = bentleyg
            c.DELTAG = deltag
            c.ROSEGOTTLIEBG = rosegottliebg
            c.GERBERG = gerberg
            c.BENTLEYP = bentleyp
            c.DELTAP = deltap
            c.DUMASP = dumasp
            c.KJELDAHP = kjeldahp
            c.OPERADOR = usu
            If (c.modificar(Usuario)) Then
                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim c As New dControlGrasaProteina
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            c.FECHA = fec
            c.BENTLEYG = bentleyg
            c.DELTAG = deltag
            c.ROSEGOTTLIEBG = rosegottliebg
            c.GERBERG = gerberg
            c.BENTLEYP = bentleyp
            c.DELTAP = deltap
            c.DUMASP = dumasp
            c.KJELDAHP = kjeldahp
            c.OPERADOR = usu
            If (c.guardar(Usuario)) Then
                'MsgBox("Pedido guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        cargarlista()
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        TextBentleyG.Text = ""
        TextDeltaG.Text = ""
        TextRoseGottliebG.Text = ""
        TextGerberG.Text = ""
        TextBentleyP.Text = ""
        TextDeltaP.Text = ""
        TextDumasP.Text = ""
        TextKjeldahP.Text = ""
        TextBentleyG.Focus()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Fecha" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dControlGrasaProteina
            id = row.Cells("Id").Value
            c.ID = id
            c = c.buscar
            If Not c Is Nothing Then
                TextId.Text = c.ID
                DateFecha.Value = c.FECHA
                TextBentleyG.Text = c.BENTLEYG
                TextDeltaG.Text = c.DELTAG
                TextRoseGottliebG.Text = c.ROSEGOTTLIEBG
                TextGerberG.Text = c.GERBERG
                TextBentleyP.Text = c.BENTLEYP
                TextDeltaP.Text = c.DELTAP
                TextDumasP.Text = c.DUMASP
                TextKjeldahP.Text = c.KJELDAHP
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "BentleyG" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dControlGrasaProteina
            id = row.Cells("Id").Value
            c.ID = id
            c = c.buscar
            If Not c Is Nothing Then
                TextId.Text = c.ID
                DateFecha.Value = c.FECHA
                TextBentleyG.Text = c.BENTLEYG
                TextDeltaG.Text = c.DELTAG
                TextRoseGottliebG.Text = c.ROSEGOTTLIEBG
                TextGerberG.Text = c.GERBERG
                TextBentleyP.Text = c.BENTLEYP
                TextDeltaP.Text = c.DELTAP
                TextDumasP.Text = c.DUMASP
                TextKjeldahP.Text = c.KJELDAHP
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "DeltaG" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dControlGrasaProteina
            id = row.Cells("Id").Value
            c.ID = id
            c = c.buscar
            If Not c Is Nothing Then
                TextId.Text = c.ID
                DateFecha.Value = c.FECHA
                TextBentleyG.Text = c.BENTLEYG
                TextDeltaG.Text = c.DELTAG
                TextRoseGottliebG.Text = c.ROSEGOTTLIEBG
                TextGerberG.Text = c.GERBERG
                TextBentleyP.Text = c.BENTLEYP
                TextDeltaP.Text = c.DELTAP
                TextDumasP.Text = c.DUMASP
                TextKjeldahP.Text = c.KJELDAHP
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "RoseGottliebG" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dControlGrasaProteina
            id = row.Cells("Id").Value
            c.ID = id
            c = c.buscar
            If Not c Is Nothing Then
                TextId.Text = c.ID
                DateFecha.Value = c.FECHA
                TextBentleyG.Text = c.BENTLEYG
                TextDeltaG.Text = c.DELTAG
                TextRoseGottliebG.Text = c.ROSEGOTTLIEBG
                TextGerberG.Text = c.GERBERG
                TextBentleyP.Text = c.BENTLEYP
                TextDeltaP.Text = c.DELTAP
                TextDumasP.Text = c.DUMASP
                TextKjeldahP.Text = c.KJELDAHP
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "GerberG" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dControlGrasaProteina
            id = row.Cells("Id").Value
            c.ID = id
            c = c.buscar
            If Not c Is Nothing Then
                TextId.Text = c.ID
                DateFecha.Value = c.FECHA
                TextBentleyG.Text = c.BENTLEYG
                TextDeltaG.Text = c.DELTAG
                TextRoseGottliebG.Text = c.ROSEGOTTLIEBG
                TextGerberG.Text = c.GERBERG
                TextBentleyP.Text = c.BENTLEYP
                TextDeltaP.Text = c.DELTAP
                TextDumasP.Text = c.DUMASP
                TextKjeldahP.Text = c.KJELDAHP
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "BentleyP" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dControlGrasaProteina
            id = row.Cells("Id").Value
            c.ID = id
            c = c.buscar
            If Not c Is Nothing Then
                TextId.Text = c.ID
                DateFecha.Value = c.FECHA
                TextBentleyG.Text = c.BENTLEYG
                TextDeltaG.Text = c.DELTAG
                TextRoseGottliebG.Text = c.ROSEGOTTLIEBG
                TextGerberG.Text = c.GERBERG
                TextBentleyP.Text = c.BENTLEYP
                TextDeltaP.Text = c.DELTAP
                TextDumasP.Text = c.DUMASP
                TextKjeldahP.Text = c.KJELDAHP
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "DeltaP" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dControlGrasaProteina
            id = row.Cells("Id").Value
            c.ID = id
            c = c.buscar
            If Not c Is Nothing Then
                TextId.Text = c.ID
                DateFecha.Value = c.FECHA
                TextBentleyG.Text = c.BENTLEYG
                TextDeltaG.Text = c.DELTAG
                TextRoseGottliebG.Text = c.ROSEGOTTLIEBG
                TextGerberG.Text = c.GERBERG
                TextBentleyP.Text = c.BENTLEYP
                TextDeltaP.Text = c.DELTAP
                TextDumasP.Text = c.DUMASP
                TextKjeldahP.Text = c.KJELDAHP
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "DumasP" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dControlGrasaProteina
            id = row.Cells("Id").Value
            c.ID = id
            c = c.buscar
            If Not c Is Nothing Then
                TextId.Text = c.ID
                DateFecha.Value = c.FECHA
                TextBentleyG.Text = c.BENTLEYG
                TextDeltaG.Text = c.DELTAG
                TextRoseGottliebG.Text = c.ROSEGOTTLIEBG
                TextGerberG.Text = c.GERBERG
                TextBentleyP.Text = c.BENTLEYP
                TextDeltaP.Text = c.DELTAP
                TextDumasP.Text = c.DUMASP
                TextKjeldahP.Text = c.KJELDAHP
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "KjeldahP" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dControlGrasaProteina
            id = row.Cells("Id").Value
            c.ID = id
            c = c.buscar
            If Not c Is Nothing Then
                TextId.Text = c.ID
                DateFecha.Value = c.FECHA
                TextBentleyG.Text = c.BENTLEYG
                TextDeltaG.Text = c.DELTAG
                TextRoseGottliebG.Text = c.ROSEGOTTLIEBG
                TextGerberG.Text = c.GERBERG
                TextBentleyP.Text = c.BENTLEYP
                TextDeltaP.Text = c.DELTAP
                TextDumasP.Text = c.DUMASP
                TextKjeldahP.Text = c.KJELDAHP
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Operador" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dControlGrasaProteina
            id = row.Cells("Id").Value
            c.ID = id
            c = c.buscar
            If Not c Is Nothing Then
                TextId.Text = c.ID
                DateFecha.Value = c.FECHA
                TextBentleyG.Text = c.BENTLEYG
                TextDeltaG.Text = c.DELTAG
                TextRoseGottliebG.Text = c.ROSEGOTTLIEBG
                TextGerberG.Text = c.GERBERG
                TextBentleyP.Text = c.BENTLEYP
                TextDeltaP.Text = c.DELTAP
                TextDumasP.Text = c.DUMASP
                TextKjeldahP.Text = c.KJELDAHP
            End If
        End If
    End Sub

    Private Sub TextBentleyG_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBentleyG.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextDeltaG.Focus()
        End If
    End Sub

    Private Sub TextBentleyG_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBentleyG.TextChanged

    End Sub

    Private Sub TextDeltaG_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextDeltaG.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextRoseGottliebG.Focus()
        End If
    End Sub

    Private Sub TextDeltaG_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextDeltaG.TextChanged

    End Sub

    Private Sub TextRoseGottliebG_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextRoseGottliebG.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextGerberG.Focus()
        End If
    End Sub

   

    Private Sub TextGerberG_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextGerberG.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextBentleyP.Focus()
        End If
    End Sub

   

    Private Sub TextBentleyP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBentleyP.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextDeltaP.Focus()
        End If
    End Sub

    Private Sub TextBentleyP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBentleyP.TextChanged

    End Sub

    Private Sub TextDeltaP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextDeltaP.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextDumasP.Focus()
        End If
    End Sub

    Private Sub TextDeltaP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextDeltaP.TextChanged

    End Sub

    Private Sub TextDumasP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextDumasP.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextKjeldahP.Focus()
        End If
    End Sub

    Private Sub TextDumasP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextDumasP.TextChanged

    End Sub

    Private Sub TextKjeldahP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextKjeldahP.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            ButtonGuardar.Focus()
        End If
    End Sub

    Private Sub TextKjeldahP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextKjeldahP.TextChanged

    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If TextId.Text <> "" Then
            Dim id As Long = TextId.Text.Trim
            Dim c As New dControlGrasaProteina
            c.ID = id
            If (c.eliminar(Usuario)) Then
                MsgBox("Registro eliminado", MsgBoxStyle.Information, "Atención")
                cargarlista()
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
End Class