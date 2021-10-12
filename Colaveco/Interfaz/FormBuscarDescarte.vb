Public Class FormBuscarDescarte
    Private _descarte As dDescarteMuestras
    Public Property Descarte() As dDescarteMuestras
        Get
            Return _descarte
        End Get
        Set(ByVal value As dDescarteMuestras)
            _descarte = value
        End Set
    End Property
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        RadioButtonProductor.Checked = True
        deshabilitarfecha()
        deshabilitarficha()
    End Sub
    Private Sub ButtonSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSeleccionar.Click
        Dim v As New FormBuscarCliente
        v.ShowDialog()
        If Not v.Cliente Is Nothing Then
            Dim cli As dCliente = v.Cliente
            TextIdProductor.Text = cli.ID
            TextProductor.Text = cli.NOMBRE
            ButtonBuscar.Focus()
        End If
    End Sub
    Private Sub deshabilitarfecha()
        DateDesde.Enabled = False
        DateHasta.Enabled = False
    End Sub
    Private Sub deshabilitarficha()
        TextFicha.Enabled = False
    End Sub
    Private Sub deshabilitarproductor()
        TextIdProductor.Enabled = False
        TextProductor.Enabled = False
        ButtonSeleccionar.Enabled = False
    End Sub
    Private Sub habilitarfecha()
        DateDesde.Enabled = True
        DateHasta.Enabled = True
    End Sub
    Private Sub habilitarficha()
        TextFicha.Enabled = True
    End Sub
    Private Sub habilitarproductor()
        TextIdProductor.Enabled = True
        TextProductor.Enabled = True
        ButtonSeleccionar.Enabled = True
    End Sub

    Private Sub RadioButtonProductor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonProductor.CheckedChanged
        habilitarproductor()
        deshabilitarfecha()
        deshabilitarficha()
    End Sub

    Private Sub RadioButtonFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonFecha.CheckedChanged
        habilitarfecha()
        deshabilitarproductor()
        deshabilitarficha()
    End Sub

    Private Sub RadioButtonFicha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonFicha.CheckedChanged
        habilitarficha()
        deshabilitarfecha()
        deshabilitarproductor()
    End Sub

    Private Sub ButtonBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscar.Click

        If RadioButtonProductor.Checked = True Then
            If TextIdProductor.Text.Trim.Length > 0 Then
                Dim descarte As New dDescarteMuestras
                Dim texto As Long = TextIdProductor.Text.Trim
                Dim lista As New ArrayList
                lista = descarte.listarporproductor(texto)
                ListResultados.Items.Clear()
                If Not lista Is Nothing Then
                    If lista.Count > 0 Then
                        For Each a In lista
                            ListResultados().Items.Add(a)
                        Next
                    End If
                End If
            End If
        End If
        If RadioButtonFecha.Checked = True Then
            If DateDesde.Text.Trim.Length > 0 And DateHasta.Text.Trim.Length > 0 Then
                Dim descarte As New dDescarteMuestras
                Dim desde As Date = DateDesde.value.ToString("yyyy-MM-dd")
                Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
                Dim fechadesde As String
                fechadesde = Format(desde, "yyyy-MM-dd")
                Dim fechahasta As String
                fechahasta = Format(hasta, "yyyy-MM-dd")
                'Dim hasta As String = DateHasta.Text.Trim

                Dim lista As New ArrayList
                lista = descarte.listarporfecha(fechadesde, fechahasta)
                ListResultados.Items.Clear()
                If Not lista Is Nothing Then
                    If lista.Count > 0 Then
                        For Each a In lista
                            ListResultados().Items.Add(a)
                        Next
                    End If
                End If
            End If
        End If
        If RadioButtonFicha.Checked = True Then
            If TextFicha.Text.Trim.Length > 0 Then
                Dim descarte As New dDescarteMuestras
                Dim texto As Long = TextFicha.Text.Trim
                Dim lista As New ArrayList
                lista = descarte.listarporficha(texto)
                ListResultados.Items.Clear()
                If Not lista Is Nothing Then
                    If lista.Count > 0 Then
                        For Each a In lista
                            ListResultados().Items.Add(a)
                        Next
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ListResultados_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListResultados.SelectedIndexChanged
        If ListResultados.SelectedItems.Count = 1 Then
            Dim desc As dDescarteMuestras = CType(ListResultados.SelectedItem, dDescarteMuestras)
            Descarte = desc
        End If
        Me.Close()
    End Sub
End Class