Public Class FormRgLab89
    Private _usuario As dUsuario
    Dim _hora As String
    Private media_ As Integer = 0
    Private diferencia_ As Integer = 0
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        Timer1.Enabled = True
        cargarlista()
        cargarCombos()
        limpiar()
        buscarmedias()
        ComboOperador.SelectedItem = Usuario.ID
        ComboOperador.Text = Usuario.NOMBRE
        RadioC1.Checked = True
        TextResultado1.Select()
    End Sub

    Private Sub cargarlista()
        Dim r As New dRgLab89
        Dim lista As New ArrayList
        lista = r.listar
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each r In lista
                    DataGridView1(columna, fila).Value = r.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = r.FECHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = r.MUESTRA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = r.MEDIA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = r.RESULTADO1
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = r.RESULTADO2
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Public Sub cargarCombos()
        Dim u As New dUsuario
        Dim lista As New ArrayList
        lista = u.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each u In lista
                    ComboOperador.Items.Add(u)
                Next
            End If
        End If
    End Sub

    Private Sub buscarmedias()
        Dim cm As New dCrioscopia_Medias
        cm = cm.buscarultimo
        If Not cm Is Nothing Then
            TextC1.Text = cm.C1
            TextC2.Text = cm.C2
        End If
    End Sub
    Public Sub limpiar()
        _hora = Now.ToString("HH:mm")
        TextId.Text = ""
        DateFecha.Value = Now
        TextHora.Text = _hora
        RadioC1.Checked = True
        Textmedia.Text = ""
        Textresultado1.Text = ""
        textresultado2.Text = ""
        ComboOperador.SelectedItem = Usuario.ID
        TextObservaciones.Text = ""
        TextResultado1.Select()
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
        cargarlista()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If TextId.Text <> "" Then
            If MsgBox("El registro será eliminado, ¿desea continuar?", MsgBoxStyle.OkCancel, "Atención") = MsgBoxResult.Ok Then
                Dim r As New dRgLab89
                Dim id As Long = CType(TextId.Text, Long)
                r.ID = id
                If (r.eliminar(Usuario)) Then
                    MsgBox("Registro eliminado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        limpiar()
        cargarlista()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click

        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim hora As String = TextHora.Text.Trim
        Dim muestra As String = ""
        If RadioC1.Checked = True Then
            muestra = "C1"
        Else
            muestra = "C2"
        End If
        Dim media As Integer = Textmedia.Text.Trim
        Dim resultado1 As Integer = Textresultado1.Text
        Dim resultado2 As Integer = Textresultado2.Text
        Dim operador As dUsuario = CType(ComboOperador.SelectedItem, dUsuario)
        Dim observaciones As String = TextObservaciones.Text

        If TextId.Text.Trim.Length > 0 Then
            Dim r As New dRgLab89()
            Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            r.ID = id
            r.FECHA = fec
            r.HORA = hora
            r.MUESTRA = muestra
            r.MEDIA = media
            r.RESULTADO1 = resultado1
            r.RESULTADO2 = resultado2
            If Not operador Is Nothing Then
                r.OPERADOR = operador.ID
            Else
                MsgBox("Falta ingresar el operador")
                ComboOperador.Focus()
                Exit Sub
            End If
            r.OBSERVACIONES = observaciones
            If (r.modificar(Usuario)) Then
                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim r As New dRgLab89()
            'Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            r.FECHA = fec
            r.HORA = hora
            r.MUESTRA = muestra
            r.MEDIA = media
            r.RESULTADO1 = resultado1
            r.RESULTADO2 = resultado2
            If Not operador Is Nothing Then
                r.OPERADOR = operador.ID
            Else
                MsgBox("Falta ingresar el operador")
                ComboOperador.Focus()
                Exit Sub
            End If
            r.OBSERVACIONES = observaciones
            If (r.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        cargarlista()
        limpiar()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Fecha" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim r As New dRgLab89
            id = row.Cells("Id").Value
            r.ID = id
            r = r.buscar
            If Not r Is Nothing Then
                TextId.Text = r.ID
                DateFecha.Value = r.FECHA
                TextHora.Text = r.HORA
                If r.MUESTRA = "C1" Then
                    RadioC1.Checked = True
                Else
                    RadioC2.Checked = True
                End If
                TextMedia.Text = r.MEDIA
                Textresultado1.Text = r.RESULTADO1
                TextResultado2.Text = r.RESULTADO2
                TextDiferencia.Text = r.DIFERENCIA
                Dim op As New dUsuario
                For Each op In ComboOperador.Items
                    If op.ID = r.OPERADOR Then
                        ComboOperador.SelectedItem = op
                        ComboOperador.Text = op.NOMBRE
                        Exit For
                    End If
                Next
                TextObservaciones.Text = r.OBSERVACIONES
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Muestra" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim r As New dRgLab89
            id = row.Cells("Id").Value
            r.ID = id
            r = r.buscar
            If Not r Is Nothing Then
                TextId.Text = r.ID
                DateFecha.Value = r.FECHA
                TextHora.Text = r.HORA
                If r.MUESTRA = "C1" Then
                    RadioC1.Checked = True
                Else
                    RadioC2.Checked = True
                End If
                TextMedia.Text = r.MEDIA
                TextResultado1.Text = r.RESULTADO1
                TextResultado2.Text = r.RESULTADO2
                TextDiferencia.Text = r.DIFERENCIA
                Dim op As New dUsuario
                For Each op In ComboOperador.Items
                    If op.ID = r.OPERADOR Then
                        ComboOperador.SelectedItem = op
                        ComboOperador.Text = op.NOMBRE
                        Exit For
                    End If
                Next
                TextObservaciones.Text = r.OBSERVACIONES
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Media" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim r As New dRgLab89
            id = row.Cells("Id").Value
            r.ID = id
            r = r.buscar
            If Not r Is Nothing Then
                TextId.Text = r.ID
                DateFecha.Value = r.FECHA
                TextHora.Text = r.HORA
                If r.MUESTRA = "C1" Then
                    RadioC1.Checked = True
                Else
                    RadioC2.Checked = True
                End If
                TextMedia.Text = r.MEDIA
                TextResultado1.Text = r.RESULTADO1
                TextResultado2.Text = r.RESULTADO2
                TextDiferencia.Text = r.DIFERENCIA
                Dim op As New dUsuario
                For Each op In ComboOperador.Items
                    If op.ID = r.OPERADOR Then
                        ComboOperador.SelectedItem = op
                        ComboOperador.Text = op.NOMBRE
                        Exit For
                    End If
                Next
                TextObservaciones.Text = r.OBSERVACIONES
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Resultado1" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim r As New dRgLab89
            id = row.Cells("Id").Value
            r.ID = id
            r = r.buscar
            If Not r Is Nothing Then
                TextId.Text = r.ID
                DateFecha.Value = r.FECHA
                TextHora.Text = r.HORA
                If r.MUESTRA = "C1" Then
                    RadioC1.Checked = True
                Else
                    RadioC2.Checked = True
                End If
                TextMedia.Text = r.MEDIA
                TextResultado1.Text = r.RESULTADO1
                TextResultado2.Text = r.RESULTADO2
                TextDiferencia.Text = r.DIFERENCIA
                Dim op As New dUsuario
                For Each op In ComboOperador.Items
                    If op.ID = r.OPERADOR Then
                        ComboOperador.SelectedItem = op
                        ComboOperador.Text = op.NOMBRE
                        Exit For
                    End If
                Next
                TextObservaciones.Text = r.OBSERVACIONES
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Resultado2" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim r As New dRgLab89
            id = row.Cells("Id").Value
            r.ID = id
            r = r.buscar
            If Not r Is Nothing Then
                TextId.Text = r.ID
                DateFecha.Value = r.FECHA
                TextHora.Text = r.HORA
                If r.MUESTRA = "C1" Then
                    RadioC1.Checked = True
                Else
                    RadioC2.Checked = True
                End If
                TextMedia.Text = r.MEDIA
                TextResultado1.Text = r.RESULTADO1
                TextResultado2.Text = r.RESULTADO2
                TextDiferencia.Text = r.DIFERENCIA
                Dim op As New dUsuario
                For Each op In ComboOperador.Items
                    If op.ID = r.OPERADOR Then
                        ComboOperador.SelectedItem = op
                        ComboOperador.Text = op.NOMBRE
                        Exit For
                    End If
                Next
                TextObservaciones.Text = r.OBSERVACIONES
            End If
        End If
    End Sub

    Private Sub TextFicha_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextMedia.TextChanged

    End Sub
    
    Private Sub actualizarhora()
        If TextId.Text = "" Then
            _hora = Now.ToString("HH:mm")
            TextHora.Text = _hora
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        actualizarhora()
    End Sub

    Private Sub ButtonGuardarMedias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardarMedias.Click
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fec As String
        fec = Format(fecha, "yyyy-MM-dd")
        Dim cm As New dCrioscopia_Medias
        Dim c1 As Integer = 0
        Dim c2 As Integer = 0
        If TextC1.Text <> "" Then
            c1 = TextC1.Text
        End If
        If TextC2.Text <> "" Then
            c2 = TextC2.Text
        End If
        cm.FECHA = fec
        cm.C1 = c1
        cm.C2 = c2
        cm.guardar(Usuario)
        buscarmedias()
    End Sub
    Private Sub calcularmedia()
        Dim res1 As Integer = 0
        Dim res2 As Integer = 0
        If TextResultado1.Text <> "" Then
            res1 = TextResultado1.Text
        End If
        If TextResultado2.Text <> "" Then
            res2 = TextResultado2.Text
        End If
        media_ = (res1 + res2) / 2
        TextMedia.Text = media_
    End Sub
    Private Sub calculardiferencia()
        Dim c1 As Integer = 0
        Dim c2 As Integer = 0
        If TextC1.Text <> "" Then
            c1 = TextC1.Text
        End If
        If TextC1.Text <> "" Then
            c2 = TextC2.Text
        End If
        If RadioC1.Checked = True Then
            diferencia_ = media_ - c1
        Else
            diferencia_ = media_ - c2
        End If
        TextDiferencia.Text = diferencia_
    End Sub

    Private Sub TextResultado1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextResultado1.TextChanged
        calcularmedia()
        calculardiferencia()
    End Sub

    Private Sub TextResultado2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextResultado2.TextChanged
        calcularmedia()
        calculardiferencia()
    End Sub

    Private Sub RadioC1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioC1.CheckedChanged
        calcularmedia()
        calculardiferencia()
    End Sub

    Private Sub RadioC2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioC2.CheckedChanged
        calcularmedia()
        calculardiferencia()
    End Sub
End Class