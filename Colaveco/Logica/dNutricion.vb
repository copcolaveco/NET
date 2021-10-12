Public Class dNutricion
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_fechaingreso As String
    Private m_fechaproceso As String
    Private m_muestra As String
    Private m_detallemuestra As String
    Private m_clase As Integer
    Private m_alimento As Integer
    Private m_msh As Double
    Private m_msm As Integer
    Private m_cenizash As Double
    Private m_cenizass As Double
    Private m_cenizasm As Integer
    Private m_pbh As Double
    Private m_pbs As Double
    Private m_pbm As Integer
    Private m_fndh As Double
    Private m_fnds As Double
    Private m_fndm As Integer
    Private m_fadh As Double
    Private m_fads As Double
    Private m_fadm As Integer
    Private m_enls As Double
    Private m_enlm As Integer
    Private m_ems As Double
    Private m_emm As Integer
    Private m_fch As Double
    Private m_fcs As Double
    Private m_fcm As Integer
    Private m_phh As Double
    Private m_phm As Integer
    Private m_eeh As Double
    Private m_ees As Double
    Private m_eem As Integer
    Private m_nidah As Double
    Private m_nidam As Integer
    Private m_don As String
    Private m_donm As Integer
    Private m_afla As String
    Private m_aflam As Integer
    Private m_zeara As String
    Private m_zearam As Integer
    Private m_fibraefectiva As String
    Private m_fibraefectivam As Integer
    Private m_clostridios As String
    Private m_clostridiosm As Integer
    Private m_zinc As Double
    Private m_zincm As Integer
    Private m_calcio As Double
    Private m_calciom As Integer
    Private m_fosforo As Double
    Private m_fosforom As Integer
    Private m_operador As Integer
    Private m_marca As Integer

#End Region

#Region "Getters y Setters"
    Public Property ID() As Long
        Get
            Return m_id
        End Get
        Set(ByVal value As Long)
            m_id = value
        End Set
    End Property
    Public Property FICHA() As Long
        Get
            Return m_ficha
        End Get
        Set(ByVal value As Long)
            m_ficha = value
        End Set
    End Property
    Public Property FECHAINGRESO() As String
        Get
            Return m_fechaingreso
        End Get
        Set(ByVal value As String)
            m_fechaingreso = value
        End Set
    End Property
    Public Property FECHAPROCESO() As String
        Get
            Return m_fechaproceso
        End Get
        Set(ByVal value As String)
            m_fechaproceso = value
        End Set
    End Property
    Public Property MUESTRA() As String
        Get
            Return m_muestra
        End Get
        Set(ByVal value As String)
            m_muestra = value
        End Set
    End Property
    Public Property DETALLEMUESTRA() As String
        Get
            Return m_detallemuestra
        End Get
        Set(ByVal value As String)
            m_detallemuestra = value
        End Set
    End Property
    Public Property CLASE() As Integer
        Get
            Return m_clase
        End Get
        Set(ByVal value As Integer)
            m_clase = value
        End Set
    End Property
    Public Property ALIMENTO() As Integer
        Get
            Return m_alimento
        End Get
        Set(ByVal value As Integer)
            m_alimento = value
        End Set
    End Property
    Public Property MSH() As Double
        Get
            Return m_msh
        End Get
        Set(ByVal value As Double)
            m_msh = value
        End Set
    End Property
   
    Public Property MSM() As Integer
        Get
            Return m_msm
        End Get
        Set(ByVal value As Integer)
            m_msm = value
        End Set
    End Property
    Public Property CENIZASH() As Double
        Get
            Return m_cenizash
        End Get
        Set(ByVal value As Double)
            m_cenizash = value
        End Set
    End Property
    Public Property CENIZASS() As Double
        Get
            Return m_cenizass
        End Get
        Set(ByVal value As Double)
            m_cenizass = value
        End Set
    End Property
    Public Property CENIZASM() As Integer
        Get
            Return m_cenizasm
        End Get
        Set(ByVal value As Integer)
            m_cenizasm = value
        End Set
    End Property
    Public Property PBH() As Double
        Get
            Return m_pbh
        End Get
        Set(ByVal value As Double)
            m_pbh = value
        End Set
    End Property
    Public Property PBS() As Double
        Get
            Return m_pbs
        End Get
        Set(ByVal value As Double)
            m_pbs = value
        End Set
    End Property
    Public Property PBM() As Integer
        Get
            Return m_pbm
        End Get
        Set(ByVal value As Integer)
            m_pbm = value
        End Set
    End Property
    Public Property FNDH() As Double
        Get
            Return m_fndh
        End Get
        Set(ByVal value As Double)
            m_fndh = value
        End Set
    End Property
    Public Property FNDS() As Double
        Get
            Return m_fnds
        End Get
        Set(ByVal value As Double)
            m_fnds = value
        End Set
    End Property
    Public Property FNDM() As Integer
        Get
            Return m_fndm
        End Get
        Set(ByVal value As Integer)
            m_fndm = value
        End Set
    End Property
    Public Property FADH() As Double
        Get
            Return m_fadh
        End Get
        Set(ByVal value As Double)
            m_fadh = value
        End Set
    End Property
    Public Property FADS() As Double
        Get
            Return m_fads
        End Get
        Set(ByVal value As Double)
            m_fads = value
        End Set
    End Property
    Public Property FADM() As Integer
        Get
            Return m_fadm
        End Get
        Set(ByVal value As Integer)
            m_fadm = value
        End Set
    End Property
    
    Public Property ENLS() As Double
        Get
            Return m_enls
        End Get
        Set(ByVal value As Double)
            m_enls = value
        End Set
    End Property
    Public Property ENLM() As Integer
        Get
            Return m_enlm
        End Get
        Set(ByVal value As Integer)
            m_enlm = value
        End Set
    End Property
  
    Public Property EMS() As Double
        Get
            Return m_ems
        End Get
        Set(ByVal value As Double)
            m_ems = value
        End Set
    End Property
    Public Property EMM() As Integer
        Get
            Return m_emm
        End Get
        Set(ByVal value As Integer)
            m_emm = value
        End Set
    End Property
    Public Property FCH() As Double
        Get
            Return m_fch
        End Get
        Set(ByVal value As Double)
            m_fch = value
        End Set
    End Property
    
    Public Property FCS() As Double
        Get
            Return m_fcs
        End Get
        Set(ByVal value As Double)
            m_fcs = value
        End Set
    End Property
    Public Property FCM() As Integer
        Get
            Return m_fcm
        End Get
        Set(ByVal value As Integer)
            m_fcm = value
        End Set
    End Property
    Public Property PHH() As Double
        Get
            Return m_phh
        End Get
        Set(ByVal value As Double)
            m_phh = value
        End Set
    End Property
   
    Public Property PHM() As Integer
        Get
            Return m_phm
        End Get
        Set(ByVal value As Integer)
            m_phm = value
        End Set
    End Property
    Public Property EEH() As Double
        Get
            Return m_eeh
        End Get
        Set(ByVal value As Double)
            m_eeh = value
        End Set
    End Property
    Public Property EES() As Double
        Get
            Return m_ees
        End Get
        Set(ByVal value As Double)
            m_ees = value
        End Set
    End Property
    Public Property EEM() As Integer
        Get
            Return m_eem
        End Get
        Set(ByVal value As Integer)
            m_eem = value
        End Set
    End Property
    Public Property NIDAH() As Double
        Get
            Return m_nidah
        End Get
        Set(ByVal value As Double)
            m_nidah = value
        End Set
    End Property
    Public Property NIDAM() As Integer
        Get
            Return m_nidam
        End Get
        Set(ByVal value As Integer)
            m_nidam = value
        End Set
    End Property
    Public Property DON() As String
        Get
            Return m_don
        End Get
        Set(ByVal value As String)
            m_don = value
        End Set
    End Property
    Public Property DONM() As Integer
        Get
            Return m_donm
        End Get
        Set(ByVal value As Integer)
            m_donm = value
        End Set
    End Property
    Public Property AFLA() As String
        Get
            Return m_afla
        End Get
        Set(ByVal value As String)
            m_afla = value
        End Set
    End Property
    Public Property AFLAM() As Integer
        Get
            Return m_aflam
        End Get
        Set(ByVal value As Integer)
            m_aflam = value
        End Set
    End Property
    Public Property ZEARA() As String
        Get
            Return m_zeara
        End Get
        Set(ByVal value As String)
            m_zeara = value
        End Set
    End Property
    Public Property ZEARAM() As Integer
        Get
            Return m_zearam
        End Get
        Set(ByVal value As Integer)
            m_zearam = value
        End Set
    End Property
    Public Property FIBRAEFECTIVA() As String
        Get
            Return m_fibraefectiva
        End Get
        Set(ByVal value As String)
            m_fibraefectiva = value
        End Set
    End Property
    Public Property FIBRAEFECTIVAM() As Integer
        Get
            Return m_fibraefectivam
        End Get
        Set(ByVal value As Integer)
            m_fibraefectivam = value
        End Set
    End Property
    Public Property CLOSTRIDIOS() As String
        Get
            Return m_clostridios
        End Get
        Set(ByVal value As String)
            m_clostridios = value
        End Set
    End Property
    Public Property CLOSTRIDIOSM() As Integer
        Get
            Return m_clostridiosm
        End Get
        Set(ByVal value As Integer)
            m_clostridiosm = value
        End Set
    End Property
    Public Property ZINC() As Double
        Get
            Return m_zinc
        End Get
        Set(ByVal value As Double)
            m_zinc = value
        End Set
    End Property
    Public Property ZINCM() As Integer
        Get
            Return m_zincm
        End Get
        Set(ByVal value As Integer)
            m_zincm = value
        End Set
    End Property
    Public Property CALCIO() As Double
        Get
            Return m_calcio
        End Get
        Set(ByVal value As Double)
            m_calcio = value
        End Set
    End Property
    Public Property CALCIOM() As Integer
        Get
            Return m_calciom
        End Get
        Set(ByVal value As Integer)
            m_calciom = value
        End Set
    End Property
    Public Property FOSFORO() As Double
        Get
            Return m_fosforo
        End Get
        Set(ByVal value As Double)
            m_fosforo = value
        End Set
    End Property
    Public Property FOSFOROM() As Integer
        Get
            Return m_fosforom
        End Get
        Set(ByVal value As Integer)
            m_fosforom = value
        End Set
    End Property
    Public Property OPERADOR() As Integer
        Get
            Return m_operador
        End Get
        Set(ByVal value As Integer)
            m_operador = value
        End Set
    End Property
    Public Property MARCA() As Integer
        Get
            Return m_marca
        End Get
        Set(ByVal value As Integer)
            m_marca = value
        End Set
    End Property



#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_fechaingreso = ""
        m_fechaproceso = ""
        m_muestra = ""
        m_detallemuestra = ""
        m_clase = 0
        m_alimento = 0
        m_msh = 0
        m_msm = 0
        m_cenizash = 0
        m_cenizass = 0
        m_cenizasm = 0
        m_pbh = 0
        m_pbs = 0
        m_pbm = 0
        m_fndh = 0
        m_fnds = 0
        m_fndm = 0
        m_fadh = 0
        m_fads = 0
        m_fadm = 0
        m_enls = 0
        m_enlm = 0
        m_ems = 0
        m_emm = 0
        m_fch = 0
        m_fcs = 0
        m_fcm = 0
        m_phh = 0
        m_phm = 0
        m_eeh = 0
        m_ees = 0
        m_eem = 0
        m_nidah = 0
        m_nidam = 0
        m_don = ""
        m_donm = 0
        m_afla = ""
        m_aflam = 0
        m_zeara = ""
        m_zearam = 0
        m_fibraefectiva = ""
        m_fibraefectivam = 0
        m_clostridios = ""
        m_clostridiosm = 0
        m_zinc = 0
        m_zincm = 0
        m_calcio = 0
        m_calciom = 0
        m_fosforo = 0
        m_fosforom = 0
        m_operador = 0
        m_marca = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal fechaingreso As String, ByVal fechaproceso As String, ByVal muestra As String, ByVal detallemuestra As String, ByVal clase As Integer, ByVal alimento As Integer, ByVal msh As Double, ByVal msm As Integer, ByVal cenizash As Double, ByVal cenizass As Double, ByVal cenizasm As Integer, ByVal pbh As Double, ByVal pbs As Double, ByVal pbm As Integer, ByVal fndh As Double, ByVal fnds As Double, ByVal fndm As Integer, ByVal fadh As Double, ByVal fads As Double, ByVal fadm As Integer, ByVal enls As Double, ByVal enlm As Integer, ByVal ems As Double, ByVal emm As Integer, ByVal fch As Double, ByVal fcs As Double, ByVal fcm As Integer, ByVal phh As Double, ByVal phm As Integer, ByVal eeh As Double, ByVal ees As Double, ByVal eem As Integer, ByVal nidah As Double, ByVal nidam As Integer, ByVal don As String, ByVal donm As Integer, ByVal afla As String, ByVal aflam As Integer, ByVal zeara As String, ByVal zearam As Integer, ByVal fibraefectiva As String, ByVal fibraefectivam As Integer, ByVal clostridios As String, ByVal clostridiosm As Integer, ByVal zinc As Double, ByVal zincm As Integer, ByVal calcio As Double, ByVal calciom As Integer, ByVal fosoforo As Double, ByVal fosforom As Integer, ByVal operador As Integer, ByVal marca As Integer)
        m_id = id
        m_ficha = ficha
        m_fechaingreso = fechaingreso
        m_fechaproceso = fechaproceso
        m_muestra = muestra
        m_detallemuestra = detallemuestra
        m_clase = clase
        m_alimento = alimento
        m_msh = msh
        m_msm = msm
        m_cenizash = cenizash
        m_cenizass = cenizass
        m_cenizasm = cenizasm
        m_pbh = pbh
        m_pbs = pbs
        m_pbm = pbm
        m_fndh = fndh
        m_fnds = fnds
        m_fndm = fndm
        m_fadh = fadh
        m_fads = fads
        m_fadm = fadm
        m_enls = enls
        m_enlm = enlm
        m_ems = ems
        m_emm = emm
        m_fch = fch
        m_fcs = fcs
        m_fcm = fcm
        m_phh = phh
        m_phm = phm
        m_eeh = eeh
        m_ees = ees
        m_eem = eem
        m_nidah = nidah
        m_nidam = nidam
        m_don = don
        m_donm = donm
        m_afla = afla
        m_aflam = aflam
        m_zeara = zeara
        m_zearam = zearam
        m_fibraefectiva = fibraefectiva
        m_fibraefectivam = fibraefectivam
        m_clostridios = clostridios
        m_clostridiosm = clostridiosm
        m_zinc = zinc
        m_zincm = zincm
        m_calcio = calcio
        m_calciom = calciom
        m_fosforo = fosforom
        m_fosforom = fosforom
        m_operador = operador
        m_marca = marca

    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim n As New pNutricion
        Return n.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim n As New pNutricion
        Return n.modificar(Me, usuario)
    End Function
    Public Function marcar(ByVal usuario As dUsuario) As Boolean
        Dim n As New pNutricion
        Return n.marcar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim n As New pNutricion
        Return n.eliminar(Me, usuario)
    End Function
    Public Function eliminar2(ByVal usuario As dUsuario) As Boolean
        Dim n As New pNutricion
        Return n.eliminar2(Me, usuario)
    End Function

    Public Function buscar() As dNutricion
        Dim n As New pNutricion
        Return n.buscar(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_ficha & " - " & m_muestra
    End Function
    Public Function listar() As ArrayList
        Dim n As New pNutricion
        Return n.listar
    End Function
    Public Function listarfichas() As ArrayList
        Dim n As New pNutricion
        Return n.listarfichas
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim n As New pNutricion
        Return n.listarporid(texto)
    End Function
    Public Function listarxfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim n As New pNutricion
        Return n.listarxfecha(desde, hasta)
    End Function
    Public Function listarxfechaxclase(ByVal desde As String, ByVal hasta As String, ByVal clase As Integer) As ArrayList
        Dim n As New pNutricion
        Return n.listarxfechaxclase(desde, hasta, clase)
    End Function
    Public Function listarxfechaxclasexalimento(ByVal desde As String, ByVal hasta As String, ByVal clase As Integer, ByVal alimento As Integer) As ArrayList
        Dim n As New pNutricion
        Return n.listarxfechaxclasexalimento(desde, hasta, clase, alimento)
    End Function
    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim n As New pNutricion
        Return n.listarporsolicitud(texto)
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim n As New pNutricion
        Return n.listarporsolicitud2(texto)
    End Function
    Public Function desmarcarficha() As Boolean
        Dim n As New pNutricion
        Return n.desmarcarficha(Me)
    End Function
End Class
