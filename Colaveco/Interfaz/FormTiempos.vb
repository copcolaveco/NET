Public Class FormTiempos
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
        limpiar()
        listartiempos()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u

    End Sub
#End Region
    Private Sub listartiempos()
        Dim t As New dTiempos
        Dim lista As New ArrayList
        lista = t.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each t In lista
                    TextControl.Text = t.CONTROL
                    TextCalidad.Text = t.CALIDAD
                    TextAgua.Text = t.AGUA
                    TextAntibiograma.Text = t.ANTIBIOGRAMA
                    TextPal.Text = t.PAL
                    TextParasitologia.Text = t.PARASITOLOGIA
                    TextProductos.Text = t.PRODUCTOS
                    TextSerologiaLeucosis.Text = t.SEROLOGIA_LEUCOSIS
                    TextPatologia.Text = t.PATOLOGIA
                    TextAmbiental.Text = t.AMBIENTAL
                    TextEfluentes.Text = t.EFLUENTES
                    TextAgroNutricion.Text = t.NUTRICION
                    TextOtros.Text = t.OTROS
                    TextAgroSuelos.Text = t.SUELOS
                    TextSerologiaBrucelosis.Text = t.SEROLOGIA_BRUCELOSIS
                    TextSerologiaOtros.Text = t.SEROLOGIA_OTROS
                    TextSPSalmonellaListeria.Text = t.SP_SALMONELLA_LISTERIA
                    TextSPMohosLevaduras.Text = t.SP_MOHOS_LEVADURAS
                    TextEsporulados.Text = t.ESPORULADOS
                    TextBrucelosisLeche.Text = t.BRUCELOSIS_LECHE
                Next
            End If
        End If
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim control As Integer = TextControl.Text.Trim
        Dim calidad As Integer = TextCalidad.Text.Trim
        Dim agua As Integer = TextAgua.Text.Trim
        Dim antibiograma As Integer = TextAntibiograma.Text.Trim
        Dim pal As Integer = TextPal.Text.Trim
        Dim parasitologia As Integer = TextParasitologia.Text.Trim
        Dim productos As Integer = TextProductos.Text.Trim
        Dim serologia_leucosis As Integer = TextSerologiaLeucosis.Text.Trim
        Dim patologia As Integer = TextPatologia.Text.Trim
        Dim ambiental As Integer = TextAmbiental.Text.Trim
        Dim lactometros As Integer = TextEfluentes.Text.Trim
        Dim nutricion As Integer = TextAgroNutricion.Text.Trim
        Dim otros As Integer = TextOtros.Text.Trim
        Dim suelos As Integer = TextAgroSuelos.Text.Trim
        Dim serologia_brucelosis As Integer = TextSerologiaBrucelosis.Text.Trim
        Dim serologia_otros As Integer = TextSerologiaOtros.Text.Trim
        Dim sp_salmonella_listeria As Integer = TextSPSalmonellaListeria.Text.Trim
        Dim sp_mohos_levaduras As Integer = TextSPMohosLevaduras.Text.Trim
        Dim esporulados As Integer = TextEsporulados.Text.Trim
        Dim brucelosis_leche As Integer = TextBrucelosisLeche.Text.Trim
        Dim efluentes As Integer = TextEfluentes.Text.Trim
        Dim t As New dTiempos()
        t.CONTROL = control
        t.CALIDAD = calidad
        t.AGUA = agua
        t.ANTIBIOGRAMA = antibiograma
        t.PAL = pal
        t.PARASITOLOGIA = parasitologia
        t.PRODUCTOS = productos
        t.SEROLOGIA_LEUCOSIS = serologia_leucosis
        t.PATOLOGIA = patologia
        t.AMBIENTAL = ambiental
        t.LACTOMETROS = 0
        t.NUTRICION = nutricion
        t.OTROS = otros
        t.SUELOS = suelos
        t.SEROLOGIA_BRUCELOSIS = serologia_brucelosis
        t.SEROLOGIA_OTROS = serologia_otros
        t.SP_SALMONELLA_LISTERIA = sp_salmonella_listeria
        t.SP_MOHOS_LEVADURAS = sp_mohos_levaduras
        t.ESPORULADOS = esporulados
        t.BRUCELOSIS_LECHE = brucelosis_leche
        t.EFLUENTES = efluentes
        If (t.modificar(Usuario)) Then
            limpiar()
            listartiempos()
            MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        End If
    End Sub

    Private Sub limpiar()
        TextControl.Text = ""
        TextCalidad.Text = ""
        TextAgua.Text = ""
        TextAntibiograma.Text = ""
        TextPal.Text = ""
        TextParasitologia.Text = ""
        TextProductos.Text = ""
        TextSerologiaLeucosis.Text = ""
        TextPatologia.Text = ""
        TextAmbiental.Text = ""
        TextEfluentes.Text = ""
        TextAgroNutricion.Text = ""
        TextOtros.Text = ""
        TextAgroSuelos.Text = ""
        TextSerologiaBrucelosis.Text = ""
        TextSerologiaOtros.Text = ""
        TextSPSalmonellaListeria.Text = ""
        TextSPMohosLevaduras.Text = ""
        TextEsporulados.Text = ""
        TextBrucelosisLeche.Text = ""
        ButtonGuardar.Focus()
    End Sub
End Class