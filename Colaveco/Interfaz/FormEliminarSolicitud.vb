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
        Dim na As New dNuevoAnalisis
        Dim ficha As Long = 0
        Dim tipoinforme As Integer = 0
        ficha = TextFicha.Text.Trim
        sa.ID = ficha
        sm.ficha = ficha
        sa = sa.buscar
        tipoinforme = sa.IDTIPOINFORME
        If tipoinforme = 1 Then 'Control lechero
            eliminar_control()
            eliminar_control_web()
        ElseIf tipoinforme = 3 Then 'Agua
            eliminar_agua()
            eliminar_agua_web()
        ElseIf tipoinforme = 4 Then 'Antibiograma
            eliminar_antibiograma()
            eliminar_antibiograma_web()
        ElseIf tipoinforme = 5 Then ' PAL
            eliminar_pal_web()
        ElseIf tipoinforme = 6 Then 'Parasitologia
            eliminar_parasitologia_web()
        ElseIf tipoinforme = 7 Then ' Alimentos
            eliminar_subproducto()
            eliminar_subproducto_web()
        ElseIf tipoinforme = 8 Then 'Serologia
            eliminar_serologia_web()
        ElseIf tipoinforme = 9 Then 'Toxicologia
            eliminar_patologia_web()
        ElseIf tipoinforme = 10 Then 'Calidad de leche
            eliminar_calidad()
            eliminar_calidad_web()
            eliminar_calidadsolicitudmuestras()
        ElseIf tipoinforme = 11 Then 'Ambiental
            eliminar_ambiental()
            eliminar_ambiental_web()
        ElseIf tipoinforme = 13 Then 'Ntrición
            eliminar_nutricion()
            eliminar_nutricion_web()
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then 'Suelos
            eliminar_suelos()
            eliminar_suelos_web()
        ElseIf tipoinforme = 15 Then 'Brucelosis en leche
            eliminar_brucelosis_web()
        ElseIf tipoinforme = 99 Then 'Otros servicios
            eliminar_otros_web()
        End If
        If Not sa Is Nothing Then
            na.FICHA = sa.ID
            na.eliminarxficha(Usuario)
            sa.eliminar(Usuario)
            sm.eliminar(Usuario)
            TextFicha.Text = ""
            MsgBox("Solicitud eliminada")
        End If

    End Sub
    Private Sub eliminar_agua()
        Dim a As New dAgua
        Dim a2 As New dAgua2
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        a.FICHA = ficha
        a2.ficha = ficha
        a.eliminar(Usuario)
        a2.eliminar(Usuario)
    End Sub
    Private Sub eliminar_agua_web()
        Dim aw As New dAguaWeb_com
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        aw.FICHA = ficha
        aw.eliminarxficha(Usuario)
    End Sub
    Private Sub eliminar_antibiograma()
        Dim a As New dAntibiograma
        Dim a2 As New dAntibiograma2
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        a.ficha = ficha
        a2.FICHA = ficha
        a.eliminar(Usuario)
        a2.eliminar(Usuario)
    End Sub
    Private Sub eliminar_antibiograma_web()
        Dim aw As New dAntibiogramaWeb_com
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        aw.FICHA = ficha
        aw.eliminarxficha(Usuario)
    End Sub
    Private Sub eliminar_subproducto()
        Dim sp As New dSubproducto
        Dim sp2 As New dSubproducto2
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        sp.ficha = ficha
        sp2.ficha = ficha
        sp.eliminar(Usuario)
        sp2.eliminar(Usuario)
    End Sub
    Private Sub eliminar_subproducto_web()
        Dim spw As New dSubproductosWeb_com
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        spw.FICHA = ficha
        spw.eliminarxficha(Usuario)
    End Sub
    Private Sub eliminar_control()
        Dim c As New dControlSolicitud
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        c.FICHA = ficha
        c.eliminar(Usuario)
    End Sub
    Private Sub eliminar_control_web()
        Dim cw As New dControlLecheroWeb_com
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        cw.FICHA = ficha
        cw.eliminarxficha(Usuario)
    End Sub
    Private Sub eliminar_calidad()
        Dim c As New dCalidadSolicitudMuestra
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        c.ficha = ficha
        c.eliminar2(Usuario)
    End Sub
    Private Sub eliminar_calidadsolicitudmuestras()
        Dim csm As New dCalidadSolicitudMuestra
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        csm.FICHA = ficha
        csm.eliminar2(Usuario)
    End Sub
    Private Sub eliminar_calidad_web()
        Dim cw As New dCalidadWeb_com
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        cw.FICHA = ficha
        cw.eliminarxficha(Usuario)
    End Sub
    Private Sub eliminar_ambiental()
        Dim asol As New dAmbientalSolicitud
        Dim a As New dAmbiental
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        a.FICHA = ficha
        a.eliminar2(Usuario)
        asol.FICHA = ficha
        asol.eliminar2(Usuario)
    End Sub
    Private Sub eliminar_ambiental_web()
        Dim aw As New dAmbientalWeb_com
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        aw.FICHA = ficha
        aw.eliminarxficha(Usuario)
    End Sub
    Private Sub eliminar_nutricion()
        Dim sn As New dSolicitudNutricion
        Dim n As New dNutricion
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        sn.FICHA = ficha
        sn.eliminar2(Usuario)
        n.FICHA = ficha
        n.eliminar2(Usuario)
    End Sub
    Private Sub eliminar_nutricion_web()
        Dim nw As New dAgroNutricionWeb_com
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        nw.FICHA = ficha
        nw.eliminarxficha(Usuario)
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
    Private Sub eliminar_suelos_web()
        Dim sw As New dAgroSuelosWeb_com
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        sw.FICHA = ficha
        sw.eliminarxficha(Usuario)
    End Sub
    Private Sub eliminar_pal_web()
        Dim pw As New dPalWeb_com
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        pw.FICHA = ficha
        pw.eliminarxficha(Usuario)
    End Sub
    Private Sub eliminar_parasitologia_web()
        Dim pw As New dParasitologiaWeb_com
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        pw.FICHA = ficha
        pw.eliminarxficha(Usuario)
    End Sub
    Private Sub eliminar_serologia_web()
        Dim sw As New dSerologiaWeb_com
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        sw.FICHA = ficha
        sw.eliminarxficha(Usuario)
    End Sub
    Private Sub eliminar_patologia_web()
        Dim pw As New dPatologiaWeb_com
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        pw.FICHA = ficha
        pw.eliminarxficha(Usuario)
    End Sub
    Private Sub eliminar_brucelosis_web()
        Dim bw As New dBrucelosisLecheWeb_com
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        bw.FICHA = ficha
        bw.eliminarxficha(Usuario)
    End Sub
    Private Sub eliminar_otros_web()
        Dim ow As New dOtrosServiciosWeb_com
        Dim ficha As Long = 0
        ficha = TextFicha.Text.Trim
        ow.FICHA = ficha
        ow.eliminarxficha(Usuario)
    End Sub
End Class