Public Class FormSecale
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
        RadioColaveco.Checked = True
        cargarlista()
        TextMuestra.Focus()
    End Sub
#End Region
    Private Sub cargarlista()
        Dim s As New dSecale
        Dim lista As New ArrayList
        lista = s.listar

        DataGridView1.Rows.Clear()
        'ListPendientes.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each s In lista
                    DataGridView1(columna, fila).Value = s.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = s.FECHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = s.EMPRESA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = s.MUESTRA
                    columna = columna + 1
                    If s.GRASA <> -1 Then
                        DataGridView1(columna, fila).Value = s.GRASA
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If s.PROTEINA <> -1 Then
                        DataGridView1(columna, fila).Value = s.PROTEINA
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If s.LACTOSA <> -1 Then
                        DataGridView1(columna, fila).Value = s.LACTOSA
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If s.ST <> -1 Then
                        DataGridView1(columna, fila).Value = s.ST
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If s.RC <> -1 Then
                        DataGridView1(columna, fila).Value = s.RC
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If s.RB <> -1 Then
                        DataGridView1(columna, fila).Value = s.RB
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If s.RBPETRI <> -1 Then
                        DataGridView1(columna, fila).Value = s.RBPETRI
                        columna = 0
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = 0
                    End If
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Private Sub guardar()
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim empresa As String = ""
        If RadioColaveco.Checked = True Then
            empresa = "Colaveco"
        Else
            empresa = "Secale"
        End If
        Dim muestra As String = ""
        If TextMuestra.Text <> "" Then
            muestra = TextMuestra.Text.Trim
        End If

        Dim grasa As Double = -1
        If TextGrasa.Text <> "" Then
            grasa = TextGrasa.Text.Trim
        End If

        Dim proteina As Double = -1
        If TextProteina.Text <> "" Then
            proteina = TextProteina.Text.Trim
        End If
        Dim lactosa As Double = -1
        If TextLactosa.Text <> "" Then
            lactosa = TextLactosa.Text.Trim
        End If
        Dim st As Double = -1
        If TextST.Text <> "" Then
            st = TextST.Text.Trim
        End If
        Dim rc As Long = -1
        If TextRC.Text <> "" Then
            rc = TextRC.Text.Trim
        End If
        Dim rb As Long = -1
        If TextRB.Text <> "" Then
            rb = TextRB.Text.Trim
        End If
        Dim rbpetri As Long = -1
        If TextRBPetri.Text <> "" Then
            rbpetri = TextRBPetri.Text.Trim
        End If
        
        If TextId.Text.Trim.Length > 0 Then
            Dim s As New dSecale()
            Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            s.ID = id
            s.FECHA = fec
            s.EMPRESA = empresa
            s.MUESTRA = muestra
            s.GRASA = grasa
            s.PROTEINA = proteina
            s.LACTOSA = lactosa
            s.ST = st
            s.RC = rc
            s.RB = rb
            s.RBPETRI = rbpetri
            If (s.modificar(Usuario)) Then
                'MsgBox("pedido modificado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim s As New dSecale()
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            s.FECHA = fec
            s.EMPRESA = empresa
            s.MUESTRA = muestra
            s.GRASA = grasa
            s.PROTEINA = proteina
            s.LACTOSA = lactosa
            s.ST = st
            s.RC = rc
            s.RB = rb
            s.RBPETRI = rbpetri
            If (s.guardar(Usuario)) Then
                'MsgBox("Pedido guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        cargarlista()
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        TextMuestra.Text = ""
        TextGrasa.Text = ""
        TextProteina.Text = ""
        TextLactosa.Text = ""
        TextST.Text = ""
        TextRC.Text = ""
        TextRB.Text = ""
        TextRBPetri.Text = ""
        TextMuestra.Focus()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
    End Sub

    Private Sub TextMuestra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextMuestra.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextGrasa.Focus()
        End If
    End Sub

    Private Sub TextMuestra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextMuestra.TextChanged

    End Sub

    Private Sub TextGrasa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextGrasa.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextProteina.Focus()
        End If
    End Sub

    Private Sub TextGrasa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextGrasa.TextChanged

    End Sub

    Private Sub TextProteina_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextProteina.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextLactosa.Focus()
        End If
    End Sub

    Private Sub TextProteina_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextProteina.TextChanged

    End Sub

    Private Sub TextLactosa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextLactosa.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextST.Focus()
        End If
    End Sub

    Private Sub TextLactosa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextLactosa.TextChanged

    End Sub

    Private Sub TextST_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextST.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextRC.Focus()
        End If
    End Sub

    Private Sub TextST_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextST.TextChanged

    End Sub

    Private Sub TextRC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextRC.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextRB.Focus()
        End If
    End Sub

    Private Sub TextRC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextRC.TextChanged

    End Sub

    Private Sub TextRB_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextRB.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextRBPetri.Focus()
        End If
    End Sub

    Private Sub TextRB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextRB.TextChanged

    End Sub

    Private Sub TextRBPetri_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextRBPetri.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            ButtonGuardar.Focus()
        End If
    End Sub

    Private Sub TextRBPetri_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextRBPetri.TextChanged

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Fecha" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim s As New dSecale
            id = row.Cells("Id").Value
            s.ID = id
            s = s.buscar
            If Not s Is Nothing Then
                TextId.Text = s.ID
                DateFecha.Value = s.FECHA
                If s.EMPRESA = "Colaveco" Then
                    RadioColaveco.Checked = True
                Else
                    RadioSecale.Checked = True
                End If
                TextMuestra.Text = s.MUESTRA
                If s.GRASA <> -1 Then
                    TextGrasa.Text = s.GRASA
                Else
                    TextGrasa.Text = ""
                End If
                If s.PROTEINA <> -1 Then
                    TextProteina.Text = s.PROTEINA
                Else
                    TextProteina.Text = ""
                End If
                If s.LACTOSA <> -1 Then
                    TextLactosa.Text = s.LACTOSA
                Else
                    TextLactosa.Text = ""
                End If
                If s.ST <> -1 Then
                    TextST.Text = s.ST
                Else
                    TextST.Text = ""
                End If
                If s.RC <> -1 Then
                    TextRC.Text = s.RC
                Else
                    TextRC.Text = ""
                End If
                If s.RB <> -1 Then
                    TextRB.Text = s.RB
                Else
                    TextRB.Text = ""
                End If
                If s.RBPETRI <> -1 Then
                    TextRBPetri.Text = s.RBPETRI
                Else
                    TextRBPetri.Text = ""
                End If
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Empresa" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim s As New dSecale
            id = row.Cells("Id").Value
            s.ID = id
            s = s.buscar
            If Not s Is Nothing Then
                TextId.Text = s.ID
                DateFecha.Value = s.FECHA
                If s.EMPRESA = "Colaveco" Then
                    RadioColaveco.Checked = True
                Else
                    RadioSecale.Checked = True
                End If
                TextMuestra.Text = s.MUESTRA
                If s.GRASA <> -1 Then
                    TextGrasa.Text = s.GRASA
                Else
                    TextGrasa.Text = ""
                End If
                If s.PROTEINA <> -1 Then
                    TextProteina.Text = s.PROTEINA
                Else
                    TextProteina.Text = ""
                End If
                If s.LACTOSA <> -1 Then
                    TextLactosa.Text = s.LACTOSA
                Else
                    TextLactosa.Text = ""
                End If
                If s.ST <> -1 Then
                    TextST.Text = s.ST
                Else
                    TextST.Text = ""
                End If
                If s.RC <> -1 Then
                    TextRC.Text = s.RC
                Else
                    TextRC.Text = ""
                End If
                If s.RB <> -1 Then
                    TextRB.Text = s.RB
                Else
                    TextRB.Text = ""
                End If
                If s.RBPETRI <> -1 Then
                    TextRBPetri.Text = s.RBPETRI
                Else
                    TextRBPetri.Text = ""
                End If
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Muestra" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim s As New dSecale
            id = row.Cells("Id").Value
            s.ID = id
            s = s.buscar
            If Not s Is Nothing Then
                TextId.Text = s.ID
                DateFecha.Value = s.FECHA
                If s.EMPRESA = "Colaveco" Then
                    RadioColaveco.Checked = True
                Else
                    RadioSecale.Checked = True
                End If
                TextMuestra.Text = s.MUESTRA
                If s.GRASA <> -1 Then
                    TextGrasa.Text = s.GRASA
                Else
                    TextGrasa.Text = ""
                End If
                If s.PROTEINA <> -1 Then
                    TextProteina.Text = s.PROTEINA
                Else
                    TextProteina.Text = ""
                End If
                If s.LACTOSA <> -1 Then
                    TextLactosa.Text = s.LACTOSA
                Else
                    TextLactosa.Text = ""
                End If
                If s.ST <> -1 Then
                    TextST.Text = s.ST
                Else
                    TextST.Text = ""
                End If
                If s.RC <> -1 Then
                    TextRC.Text = s.RC
                Else
                    TextRC.Text = ""
                End If
                If s.RB <> -1 Then
                    TextRB.Text = s.RB
                Else
                    TextRB.Text = ""
                End If
                If s.RBPETRI <> -1 Then
                    TextRBPetri.Text = s.RBPETRI
                Else
                    TextRBPetri.Text = ""
                End If
            End If
            ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Grasa" Then
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim id As Long = 0
                Dim s As New dSecale
                id = row.Cells("Id").Value
                s.ID = id
                s = s.buscar
                If Not s Is Nothing Then
                    TextId.Text = s.ID
                    DateFecha.Value = s.FECHA
                    If s.EMPRESA = "Colaveco" Then
                        RadioColaveco.Checked = True
                    Else
                        RadioSecale.Checked = True
                    End If
                    TextMuestra.Text = s.MUESTRA
                    If s.GRASA <> -1 Then
                        TextGrasa.Text = s.GRASA
                    Else
                        TextGrasa.Text = ""
                    End If
                    If s.PROTEINA <> -1 Then
                        TextProteina.Text = s.PROTEINA
                    Else
                        TextProteina.Text = ""
                    End If
                    If s.LACTOSA <> -1 Then
                        TextLactosa.Text = s.LACTOSA
                    Else
                        TextLactosa.Text = ""
                    End If
                    If s.ST <> -1 Then
                        TextST.Text = s.ST
                    Else
                        TextST.Text = ""
                    End If
                    If s.RC <> -1 Then
                        TextRC.Text = s.RC
                    Else
                        TextRC.Text = ""
                    End If
                    If s.RB <> -1 Then
                        TextRB.Text = s.RB
                    Else
                        TextRB.Text = ""
                    End If
                    If s.RBPETRI <> -1 Then
                        TextRBPetri.Text = s.RBPETRI
                    Else
                        TextRBPetri.Text = ""
                End If
            End If
                ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Proteina" Then
                    Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                    Dim id As Long = 0
                    Dim s As New dSecale
                    id = row.Cells("Id").Value
                    s.ID = id
                    s = s.buscar
                    If Not s Is Nothing Then
                        TextId.Text = s.ID
                        DateFecha.Value = s.FECHA
                        If s.EMPRESA = "Colaveco" Then
                            RadioColaveco.Checked = True
                        Else
                            RadioSecale.Checked = True
                        End If
                        TextMuestra.Text = s.MUESTRA
                        If s.GRASA <> -1 Then
                            TextGrasa.Text = s.GRASA
                        Else
                            TextGrasa.Text = ""
                        End If
                        If s.PROTEINA <> -1 Then
                            TextProteina.Text = s.PROTEINA
                        Else
                            TextProteina.Text = ""
                        End If
                        If s.LACTOSA <> -1 Then
                            TextLactosa.Text = s.LACTOSA
                        Else
                            TextLactosa.Text = ""
                        End If
                        If s.ST <> -1 Then
                            TextST.Text = s.ST
                        Else
                            TextST.Text = ""
                        End If
                        If s.RC <> -1 Then
                            TextRC.Text = s.RC
                        Else
                            TextRC.Text = ""
                        End If
                        If s.RB <> -1 Then
                            TextRB.Text = s.RB
                        Else
                            TextRB.Text = ""
                        End If
                        If s.RBPETRI <> -1 Then
                            TextRBPetri.Text = s.RBPETRI
                        Else
                            TextRBPetri.Text = ""
                        End If
                    End If
                ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Lactosa" Then
                    Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                    Dim id As Long = 0
                    Dim s As New dSecale
                    id = row.Cells("Id").Value
                    s.ID = id
                    s = s.buscar
                    If Not s Is Nothing Then
                        TextId.Text = s.ID
                        DateFecha.Value = s.FECHA
                        If s.EMPRESA = "Colaveco" Then
                            RadioColaveco.Checked = True
                        Else
                            RadioSecale.Checked = True
                        End If
                        TextMuestra.Text = s.MUESTRA
                        If s.GRASA <> -1 Then
                            TextGrasa.Text = s.GRASA
                        Else
                            TextGrasa.Text = ""
                        End If
                        If s.PROTEINA <> -1 Then
                            TextProteina.Text = s.PROTEINA
                        Else
                            TextProteina.Text = ""
                        End If
                        If s.LACTOSA <> -1 Then
                            TextLactosa.Text = s.LACTOSA
                        Else
                            TextLactosa.Text = ""
                        End If
                        If s.ST <> -1 Then
                            TextST.Text = s.ST
                        Else
                            TextST.Text = ""
                        End If
                        If s.RC <> -1 Then
                            TextRC.Text = s.RC
                        Else
                            TextRC.Text = ""
                        End If
                        If s.RB <> -1 Then
                            TextRB.Text = s.RB
                        Else
                            TextRB.Text = ""
                        End If
                        If s.RBPETRI <> -1 Then
                            TextRBPetri.Text = s.RBPETRI
                        Else
                            TextRBPetri.Text = ""
                        End If
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "SolTotales" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim s As New dSecale
            id = row.Cells("Id").Value
            s.ID = id
            s = s.buscar
            If Not s Is Nothing Then
                TextId.Text = s.ID
                DateFecha.Value = s.FECHA
                If s.EMPRESA = "Colaveco" Then
                    RadioColaveco.Checked = True
                Else
                    RadioSecale.Checked = True
                End If
                TextMuestra.Text = s.MUESTRA
                If s.GRASA <> -1 Then
                    TextGrasa.Text = s.GRASA
                Else
                    TextGrasa.Text = ""
                End If
                If s.PROTEINA <> -1 Then
                    TextProteina.Text = s.PROTEINA
                Else
                    TextProteina.Text = ""
                End If
                If s.LACTOSA <> -1 Then
                    TextLactosa.Text = s.LACTOSA
                Else
                    TextLactosa.Text = ""
                End If
                If s.ST <> -1 Then
                    TextST.Text = s.ST
                Else
                    TextST.Text = ""
                End If
                If s.RC <> -1 Then
                    TextRC.Text = s.RC
                Else
                    TextRC.Text = ""
                End If
                If s.RB <> -1 Then
                    TextRB.Text = s.RB
                Else
                    TextRB.Text = ""
                End If
                If s.RBPETRI <> -1 Then
                    TextRBPetri.Text = s.RBPETRI
                Else
                    TextRBPetri.Text = ""
                End If
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "RC" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim s As New dSecale
            id = row.Cells("Id").Value
            s.ID = id
            s = s.buscar
            If Not s Is Nothing Then
                TextId.Text = s.ID
                DateFecha.Value = s.FECHA
                If s.EMPRESA = "Colaveco" Then
                    RadioColaveco.Checked = True
                Else
                    RadioSecale.Checked = True
                End If
                TextMuestra.Text = s.MUESTRA
                If s.GRASA <> -1 Then
                    TextGrasa.Text = s.GRASA
                Else
                    TextGrasa.Text = ""
                End If
                If s.PROTEINA <> -1 Then
                    TextProteina.Text = s.PROTEINA
                Else
                    TextProteina.Text = ""
                End If
                If s.LACTOSA <> -1 Then
                    TextLactosa.Text = s.LACTOSA
                Else
                    TextLactosa.Text = ""
                End If
                If s.ST <> -1 Then
                    TextST.Text = s.ST
                Else
                    TextST.Text = ""
                End If
                If s.RC <> -1 Then
                    TextRC.Text = s.RC
                Else
                    TextRC.Text = ""
                End If
                If s.RB <> -1 Then
                    TextRB.Text = s.RB
                Else
                    TextRB.Text = ""
                End If
                If s.RBPETRI <> -1 Then
                    TextRBPetri.Text = s.RBPETRI
                Else
                    TextRBPetri.Text = ""
                End If
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "RB" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim s As New dSecale
            id = row.Cells("Id").Value
            s.ID = id
            s = s.buscar
            If Not s Is Nothing Then
                TextId.Text = s.ID
                DateFecha.Value = s.FECHA
                If s.EMPRESA = "Colaveco" Then
                    RadioColaveco.Checked = True
                Else
                    RadioSecale.Checked = True
                End If
                TextMuestra.Text = s.MUESTRA
                If s.GRASA <> -1 Then
                    TextGrasa.Text = s.GRASA
                Else
                    TextGrasa.Text = ""
                End If
                If s.PROTEINA <> -1 Then
                    TextProteina.Text = s.PROTEINA
                Else
                    TextProteina.Text = ""
                End If
                If s.LACTOSA <> -1 Then
                    TextLactosa.Text = s.LACTOSA
                Else
                    TextLactosa.Text = ""
                End If
                If s.ST <> -1 Then
                    TextST.Text = s.ST
                Else
                    TextST.Text = ""
                End If
                If s.RC <> -1 Then
                    TextRC.Text = s.RC
                Else
                    TextRC.Text = ""
                End If
                If s.RB <> -1 Then
                    TextRB.Text = s.RB
                Else
                    TextRB.Text = ""
                End If
                If s.RBPETRI <> -1 Then
                    TextRBPetri.Text = s.RBPETRI
                Else
                    TextRBPetri.Text = ""
                End If
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "RB2" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim s As New dSecale
            id = row.Cells("Id").Value
            s.ID = id
            s = s.buscar
            If Not s Is Nothing Then
                TextId.Text = s.ID
                DateFecha.Value = s.FECHA
                If s.EMPRESA = "Colaveco" Then
                    RadioColaveco.Checked = True
                Else
                    RadioSecale.Checked = True
                End If
                TextMuestra.Text = s.MUESTRA
                If s.GRASA <> -1 Then
                    TextGrasa.Text = s.GRASA
                Else
                    TextGrasa.Text = ""
                End If
                If s.PROTEINA <> -1 Then
                    TextProteina.Text = s.PROTEINA
                Else
                    TextProteina.Text = ""
                End If
                If s.LACTOSA <> -1 Then
                    TextLactosa.Text = s.LACTOSA
                Else
                    TextLactosa.Text = ""
                End If
                If s.ST <> -1 Then
                    TextST.Text = s.ST
                Else
                    TextST.Text = ""
                End If
                If s.RC <> -1 Then
                    TextRC.Text = s.RC
                Else
                    TextRC.Text = ""
                End If
                If s.RB <> -1 Then
                    TextRB.Text = s.RB
                Else
                    TextRB.Text = ""
                End If
                If s.RBPETRI <> -1 Then
                    TextRBPetri.Text = s.RBPETRI
                Else
                    TextRBPetri.Text = ""
                End If
            End If
                End If
    End Sub
End Class