Public Class FormEliminarSolicitud
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
    End Sub

#End Region

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        Dim sa As New dSolicitudAnalisis
        Dim sm As New dRelSolicitudMuestras
        'Dim csm As New dCalidadSolicitudMuestra
        Dim ficha As Long = 0
        Dim tipoinforme As Integer = 0
        ficha = TextFicha.Text.Trim
        sa.ID = ficha
        sm.IDSOLICITUD = ficha
        'csm.IDSOLICITUD = ficha
        sa = sa.buscar
        tipoinforme = sa.IDTIPOINFORME
        If tipoinforme = 1 Then 'Control lechero
            eliminar_control()
        ElseIf tipoinforme = 3 Then 'Agua
            eliminar_agua()
        ElseIf tipoinforme = 4 Then 'Antibiograma
            eliminar_antibiograma()
        ElseIf tipoinforme = 5 Then ' PAL

        ElseIf tipoinforme = 6 Then 'Parasitologia

        ElseIf tipoinforme = 7 Then ' Subproductos
            eliminar_subproducto()
        ElseIf tipoinforme = 8 Then 'Serologia

        ElseIf tipoinforme = 9 Then 'Toxicologia

        ElseIf tipoinforme = 10 Then 'Calidad de leche
            eliminar_calidad()
        ElseIf tipoinforme = 11 Then 'Ambiental
            eliminar_ambiental()
        ElseIf tipoinforme = 12 Then 'Lactometros

        ElseIf tipoinforme = 13 Then 'Agronutrición
            eliminar_nutricion()
        ElseIf tipoinforme = 14 Then 'Agro suelos
            eliminar_suelos()
        ElseIf tipoinforme = 15 Then 'Brucelosis en leche

        ElseIf tipoinforme = 99 Then 'Otros servicios

        End If
        If Not sa Is Nothing Then
            sa.eliminar(Usuario)
            sm.eliminar(Usuario)
            'csm.eliminar(Usuario)
            TextFicha.Text = ""
            MsgBox("Solicitud eliminada")
        End If

    End Sub
    Private Sub eliminar_agua()
        Dim a As New dAgua
        Dim a2 As New dAgua2
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        a.IDSOLICITUD = ficha
        a2.IDSOLICITUD = ficha
        a.eliminar(Usuario)
        a2.eliminar(Usuario)
    End Sub
    Private Sub eliminar_antibiograma()
        Dim a As New dAntibiograma
        Dim a2 As New dAntibiograma2
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        a.IDSOLICITUD = ficha
        a2.IDSOLICITUD = ficha
        a.eliminar(Usuario)
        a2.eliminar(Usuario)
    End Sub
    Private Sub eliminar_subproducto()
        Dim sp As New dSubproducto
        Dim sp2 As New dSubproducto2
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        sp.IDSOLICITUD = ficha
        sp2.IDSOLICITUD = ficha
        sp.eliminar(Usuario)
        sp2.eliminar(Usuario)
    End Sub
    Private Sub eliminar_control()
        Dim c As New dControlSolicitud
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        c.IDSOLICITUD = ficha
        c.eliminar(Usuario)
    End Sub
    Private Sub eliminar_calidad()
        Dim c As New dCalidadSolicitudMuestra
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        c.IDSOLICITUD = ficha
        c.eliminar2(Usuario)
    End Sub
    Private Sub eliminar_ambiental()
        Dim asol As New dAmbientalSolicitud
        Dim a As New dAmbiental
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        a.IDSOLICITUD = ficha
        a.eliminar2(Usuario)
        asol.IDSOLICITUD = ficha
        asol.eliminar2(Usuario)
    End Sub
    Private Sub eliminar_nutricion()
        Dim sn As New dSolicitudNutricion
        Dim n As New dNutricion
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        sn.FICHA = ficha
        sn.eliminar(Usuario)
        n.FICHA = ficha
        n.eliminar(Usuario)
    End Sub
    Private Sub eliminar_suelos()
        Dim ss As New dSolicitudSuelos
        Dim s As New dSuelos
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        ss.FICHA = ficha
        ss.eliminar(Usuario)
        s.FICHA = ficha
        s.eliminar(Usuario)
    End Sub
End Class