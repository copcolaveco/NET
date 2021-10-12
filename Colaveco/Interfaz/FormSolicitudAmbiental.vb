Public Class FormSolicitudAmbiental
    Private _usuario As dUsuario
    Dim idsol As String
    Dim subinf As Integer
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

#Region "Constructores"
    Public Sub New(ByVal u As dUsuario, ByVal solicitud As String, ByVal idsubinf As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        'listarultimoid()
        idsol = solicitud
        subinf = idsubinf

    End Sub
#End Region

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        'Dim ficha As Long = Textficha.Text.Trim
        Dim enterobacterias As Integer
        Dim listambiental As Integer
        Dim listmono As Integer
        Dim listspp As Integer
        Dim salmonella As Integer
        Dim ecoli As Integer
        Dim mohosylevaduras As Integer
        Dim rb As Integer
        Dim ct As Integer
        Dim cf As Integer
        Dim pseudomonaspp As Integer
        Dim estaf As Integer
        If CheckEnterobacterias.Checked = True Then
            enterobacterias = 1
        Else
            enterobacterias = 0
        End If
        If CheckListAmbiental.Checked = True Then
            listambiental = 1
        Else
            listambiental = 0
        End If
        If CheckListMono.Checked = True Then
            listmono = 1
        Else
            listmono = 0
        End If
        If CheckListspp.Checked = True Then
            listspp = 1
        Else
            listspp = 0
        End If
        If CheckSalmonella.Checked = True Then
            salmonella = 1
        Else
            salmonella = 0
        End If
        If CheckEcoli.Checked = True Then
            ecoli = 1
        Else
            ecoli = 0
        End If
        If CheckMohos.Checked = True Then
            mohosylevaduras = 1
        Else
            mohosylevaduras = 0
        End If
        If CheckRB.Checked = True Then
            rb = 1
        Else
            rb = 0
        End If
        If CheckCT.Checked = True Then
            ct = 1
        Else
            ct = 0
        End If
        If CheckCF.Checked = True Then
            cf = 1
        Else
            cf = 0
        End If
        If CheckPseudomona.Checked = True Then
            pseudomonaspp = 1
        Else
            pseudomonaspp = 0
        End If
        If CheckEstafCoagPos.Checked = True Then
            estaf = 1
        Else
            estaf = 0
        End If
        Dim ams As New dAmbientalSolicitud
        ams.FICHA = idsol
        ams = ams.buscar
        If Not ams Is Nothing Then
            Dim ambs As New dAmbientalSolicitud
            ambs.FICHA = idsol
            ams.ENTEROBACTERIAS = enterobacterias
            ambs.LISTAMBIENTAL = listambiental
            ambs.LISTMONO = listmono
            ambs.SALMONELLA = salmonella
            ambs.ECOLI = ecoli
            ambs.MOHOSYLEVADURAS = mohosylevaduras
            ambs.RB = rb
            ambs.CT = ct
            ambs.CF = cf
            ambs.PSEUDOMONASPP = pseudomonaspp
            ambs.LISTSPP = listspp
            ambs.ESTAFCOAGPOS = estaf
            If (ambs.modificar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
            Me.Close()
        Else
            Dim ambs As New dAmbientalSolicitud
            ambs.FICHA = idsol
            ambs.ENTEROBACTERIAS = enterobacterias
            ambs.LISTAMBIENTAL = listambiental
            ambs.LISTMONO = listmono
            ambs.SALMONELLA = salmonella
            ambs.ECOLI = ecoli
            ambs.MOHOSYLEVADURAS = mohosylevaduras
            ambs.RB = rb
            ambs.CT = ct
            ambs.CF = cf
            ambs.PSEUDOMONASPP = pseudomonaspp
            ambs.LISTSPP = listspp
            ambs.ESTAFCOAGPOS = estaf
            If (ambs.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
            Me.Close()
        End If


    End Sub

  
End Class