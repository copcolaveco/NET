Imports System.IO

Public Class FormControldeInformes
    Public check_resultado As Integer = 0
    Public check_coincide As Integer = 0
    Public check_om As Integer = 0
    Public check_nc As Integer = 0

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
        listarinformes()
    End Sub

#End Region
    Private Sub ButtonBuscarInformes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarInformes.Click
        buscarinformes()
        listarinformes()
    End Sub
    Private Sub listarinformes()
        Dim ci As New dControldeInformes

        Dim lista As New ArrayList
        lista = ci.listar
        DataGridView1.Rows.Clear()

        If Not lista Is Nothing Then
            If lista.Count > 0 Then


                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each ci In lista
                    Dim m As New dMuestras
                    Dim ti As New dTipoInforme
                    Dim si As New dSubInforme
                    Dim s As New dSinaveleFicha

                    DataGridView1(columna, fila).Value = ci.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ci.FECHACONTROL
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ci.FICHA
                    columna = columna + 1
                    s.FICHA = ci.FICHA
                    s = s.buscar
                    If Not s Is Nothing Then
                        DataGridView1(columna, fila).Value = s.SINAVELE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = ci.FECHA
                    columna = columna + 1
                    m.ID = ci.MUESTRA
                    m = m.buscar
                    If Not m Is Nothing Then
                        DataGridView1(columna, fila).Value = m.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "vacío"
                        columna = columna + 1
                    End If
                    ti.ID = ci.TIPO
                    ti = ti.buscar
                    DataGridView1(columna, fila).Value = ti.NOMBRE
                    columna = columna + 1
                    si.ID = ci.SUBTIPO
                    si = si.buscar
                    If Not si Is Nothing Then
                        DataGridView1(columna, fila).Value = si.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    If ci.RESULTADO = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = columna + 1
                    If ci.COINCIDE = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = columna + 1
                    If ci.OM = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = columna + 1
                    If ci.NC = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ci.OBSERVACIONES
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = Usuario.NOMBRE
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = "Ver informe"
                    columna = columna + 1
                    If ci.CONTROLADO = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = 0
                    fila = fila + 1
                Next
            End If
        End If
    End Sub
    Private Sub buscarinformes()
        Dim sa As New dSolicitudAnalisis
        Dim contador As Integer = 0
        Dim contadorarchivos As Integer = 0
        Dim faltan As Integer = 0
        Dim controllechero As Integer = 0
        Dim calidaddeleche As Integer = 0
        Dim agua As Integer = 0
        Dim subproductos As Integer = 0
        Dim serologia As Integer = 0
        Dim pal As Integer = 0
        Dim toxicologia As Integer = 0
        Dim parasitologia As Integer = 0
        Dim bacteriologia As Integer = 0
        Dim nutricion As Integer = 0
        Dim suelos As Integer = 0
        Dim brucelosis As Integer = 0
        Dim fechadesde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fechad As String
        Dim fechah As String
        Dim fechasolicitud As Date
        Dim fechasolicitud2 As String
        Dim total As Integer = 0
        fechad = Format(fechadesde, "yyyy-MM-dd")
        fechah = Format(fechahasta, "yyyy-MM-dd")
        Dim r As New Random()
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim lcontrol As New ArrayList
        Dim lcalidad As New ArrayList
        Dim lagua As New ArrayList
        Dim lproductos As New ArrayList
        Dim lserologia As New ArrayList
        Dim lpal As New ArrayList
        Dim ltoxicologia As New ArrayList
        Dim lparasitologia As New ArrayList
        Dim lbacteriologia As New ArrayList
        Dim lnutricion As New ArrayList
        Dim lsuelos As New ArrayList
        Dim lbrucelosis As New ArrayList

        Dim fechacontrol As Date = Now
        Dim fechacontrol2 As String = Format(fechacontrol, "yyyy-MM-dd")
        Dim ficha As Long = 0
        Dim fecha As Date = Now
        Dim muestra As Integer = 0
        Dim tipo As Integer = 0
        Dim subtipo As Integer = 0
        Dim resultado As Integer = 0
        Dim coincide As Integer = 0
        Dim observaciones As String = ""
        Dim controlador As Integer = 0
        Dim controlado As Integer = 0

        lista = sa.listarporfecha(fechad, fechah)
        total = lista.Count
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each sa In lista
                    If sa.IDTIPOINFORME = 1 Then
                        controllechero = controllechero + 1
                        lcontrol.Add(sa.ID)
                    ElseIf sa.IDTIPOINFORME = 3 Then
                        agua = agua + 1
                        lagua.Add(sa.ID)
                    ElseIf sa.IDTIPOINFORME = 4 Then
                        bacteriologia = bacteriologia + 1
                        lbacteriologia.Add(sa.ID)
                    ElseIf sa.IDTIPOINFORME = 5 Then
                        pal = pal + 1
                        lpal.Add(sa.ID)
                    ElseIf sa.IDTIPOINFORME = 6 Then
                        parasitologia = parasitologia + 1
                        lparasitologia.Add(sa.ID)
                    ElseIf sa.IDTIPOINFORME = 7 Then
                        subproductos = subproductos + 1
                        lproductos.Add(sa.ID)
                    ElseIf sa.IDTIPOINFORME = 8 Then
                        serologia = serologia + 1
                        lserologia.Add(sa.ID)
                    ElseIf sa.IDTIPOINFORME = 9 Then
                        toxicologia = toxicologia + 1
                        ltoxicologia.Add(sa.ID)
                    ElseIf sa.IDTIPOINFORME = 10 Then
                        calidaddeleche = calidaddeleche + 1
                        lcalidad.Add(sa.ID)
                    ElseIf sa.IDTIPOINFORME = 13 Then
                        nutricion = nutricion + 1
                        lnutricion.Add(sa.ID)
                    ElseIf sa.IDTIPOINFORME = 14 Then
                        suelos = suelos + 1
                        lsuelos.Add(sa.ID)
                    ElseIf sa.IDTIPOINFORME = 15 Then
                        brucelosis = brucelosis + 1
                        lbrucelosis.Add(sa.ID)
                    End If
                Next
            End If
        End If
        'contar los que faltan
        If lcontrol.Count < 2 Then
            If lcontrol.Count < 1 Then
                faltan = faltan + 2
            Else
                faltan = faltan + 1
            End If
        Else
        End If

        If lcalidad.Count < 2 Then
            If lcalidad.Count < 1 Then
                faltan = faltan + 2
            Else
                faltan = faltan + 1
            End If
        Else
        End If
        If lagua.Count < 2 Then
            If lagua.Count < 1 Then
                faltan = faltan + 2
            Else
                faltan = faltan + 1
            End If
        Else
        End If
        If lproductos.Count < 2 Then
            If lproductos.Count < 1 Then
                faltan = faltan + 2
            Else
                faltan = faltan + 1
            End If
        Else
        End If
        If lserologia.Count < 2 Then
            If lserologia.Count < 1 Then
                faltan = faltan + 2
            Else
                faltan = faltan + 1
            End If
        Else
        End If
        If lpal.Count < 2 Then
            If lpal.Count < 1 Then
                faltan = faltan + 2
            Else
                faltan = faltan + 1
            End If
        Else
        End If
        If ltoxicologia.Count < 2 Then
            If ltoxicologia.Count < 1 Then
                faltan = faltan + 2
            Else
                faltan = faltan + 1
            End If
        Else
        End If
        If lparasitologia.Count < 2 Then
            If lparasitologia.Count < 1 Then
                faltan = faltan + 2
            Else
                faltan = faltan + 1
            End If
        Else
        End If
        If lbacteriologia.Count < 2 Then
            If lbacteriologia.Count < 1 Then
                faltan = faltan + 2
            Else
                faltan = faltan + 1
            End If
        Else
        End If
        If lnutricion.Count < 2 Then
            If lnutricion.Count < 1 Then
                faltan = faltan + 2
            Else
                faltan = faltan + 1
            End If
        Else
        End If
        If lsuelos.Count < 2 Then
            If lsuelos.Count < 1 Then
                faltan = faltan + 2
            Else
                faltan = faltan + 1
            End If
        Else
        End If
        If lbrucelosis.Count < 2 Then
            If lbrucelosis.Count < 1 Then
                faltan = faltan + 2
            Else
                faltan = faltan + 1
            End If
        Else
        End If
        '*** BRUCELOSIS ***********************************************************************
        If lbrucelosis.Count > 0 Then
            Dim ci As New dControldeInformes
            If lbrucelosis.Count < 2 Then
                lista2 = sa.controlbrucelosis1(fechad, fechah)
                For Each sa In lista2
                    fechasolicitud = sa.FECHAINGRESO.ToString
                    fechasolicitud2 = Format(fechasolicitud, "yyyy-MM-dd")
                    ci.FECHACONTROL = fechacontrol2
                    ci.FICHA = sa.ID
                    ci.FECHA = fechasolicitud2
                    ci.MUESTRA = sa.IDMUESTRA
                    ci.TIPO = sa.IDTIPOINFORME
                    ci.SUBTIPO = sa.IDSUBINFORME
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = Usuario.ID
                    ci.CONTROLADO = 0
                    ci.guardar(Usuario)
                Next
            Else
                lista2 = sa.controlbrucelosis2(fechad, fechah)
                For Each sa In lista2
                    fechasolicitud = sa.FECHAINGRESO.ToString
                    fechasolicitud2 = Format(fechasolicitud, "yyyy-MM-dd")
                    ci.FECHACONTROL = fechacontrol2
                    ci.FICHA = sa.ID
                    ci.FECHA = fechasolicitud2
                    ci.MUESTRA = sa.IDMUESTRA
                    ci.TIPO = sa.IDTIPOINFORME
                    ci.SUBTIPO = sa.IDSUBINFORME
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = Usuario.ID
                    ci.CONTROLADO = 0
                    ci.guardar(Usuario)
                Next
            End If
        Else
        End If
        '*** NUTRICION ***********************************************************************
        If lnutricion.Count > 0 Then
            Dim ci As New dControldeInformes
            If lnutricion.Count < 2 Then
                lista2 = sa.controlnutricion1(fechad, fechah)
                For Each sa In lista2
                    fechasolicitud = sa.FECHAINGRESO.ToString
                    fechasolicitud2 = Format(fechasolicitud, "yyyy-MM-dd")
                    ci.FECHACONTROL = fechacontrol2
                    ci.FICHA = sa.ID
                    ci.FECHA = fechasolicitud2
                    ci.MUESTRA = sa.IDMUESTRA
                    ci.TIPO = sa.IDTIPOINFORME
                    ci.SUBTIPO = sa.IDSUBINFORME
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = Usuario.ID
                    ci.CONTROLADO = 0
                    ci.guardar(Usuario)
                Next
            Else
                lista2 = sa.controlnutricion2(fechad, fechah)
                For Each sa In lista2
                    fechasolicitud = sa.FECHAINGRESO.ToString
                    fechasolicitud2 = Format(fechasolicitud, "yyyy-MM-dd")
                    ci.FECHACONTROL = fechacontrol2
                    ci.FICHA = sa.ID
                    ci.FECHA = fechasolicitud2
                    ci.MUESTRA = sa.IDMUESTRA
                    ci.TIPO = sa.IDTIPOINFORME
                    ci.SUBTIPO = sa.IDSUBINFORME
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = Usuario.ID
                    ci.CONTROLADO = 0
                    ci.guardar(Usuario)
                Next
            End If
        Else
        End If
        '*** SUELOS ***********************************************************************
        If lnutricion.Count > 0 Then
            Dim ci As New dControldeInformes
            If lsuelos.Count < 2 Then
                lista2 = sa.controlsuelos1(fechad, fechah)
                For Each sa In lista2
                    fechasolicitud = sa.FECHAINGRESO.ToString
                    fechasolicitud2 = Format(fechasolicitud, "yyyy-MM-dd")
                    ci.FECHACONTROL = fechacontrol2
                    ci.FICHA = sa.ID
                    ci.FECHA = fechasolicitud2
                    ci.MUESTRA = sa.IDMUESTRA
                    ci.TIPO = sa.IDTIPOINFORME
                    ci.SUBTIPO = sa.IDSUBINFORME
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = Usuario.ID
                    ci.CONTROLADO = 0
                    ci.guardar(Usuario)
                Next
            Else
                lista2 = sa.controlsuelos2(fechad, fechah)
                For Each sa In lista2
                    fechasolicitud = sa.FECHAINGRESO.ToString
                    fechasolicitud2 = Format(fechasolicitud, "yyyy-MM-dd")
                    ci.FECHACONTROL = fechacontrol2
                    ci.FICHA = sa.ID
                    ci.FECHA = fechasolicitud2
                    ci.MUESTRA = sa.IDMUESTRA
                    ci.TIPO = sa.IDTIPOINFORME
                    ci.SUBTIPO = sa.IDSUBINFORME
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = Usuario.ID
                    ci.CONTROLADO = 0
                    ci.guardar(Usuario)
                Next
            End If
        Else
        End If
        '*** PARASITOLOGIA ***********************************************************************
        If lparasitologia.Count > 0 Then
            Dim ci As New dControldeInformes
            If lparasitologia.Count < 2 Then
                lista2 = sa.controlparasitologia1(fechad, fechah)
                For Each sa In lista2
                    fechasolicitud = sa.FECHAINGRESO.ToString
                    fechasolicitud2 = Format(fechasolicitud, "yyyy-MM-dd")
                    ci.FECHACONTROL = fechacontrol2
                    ci.FICHA = sa.ID
                    ci.FECHA = fechasolicitud2
                    ci.MUESTRA = sa.IDMUESTRA
                    ci.TIPO = sa.IDTIPOINFORME
                    ci.SUBTIPO = sa.IDSUBINFORME
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = Usuario.ID
                    ci.CONTROLADO = 0
                    ci.guardar(Usuario)
                Next
            Else
                lista2 = sa.controlparasitologia2(fechad, fechah)
                For Each sa In lista2
                    fechasolicitud = sa.FECHAINGRESO.ToString
                    fechasolicitud2 = Format(fechasolicitud, "yyyy-MM-dd")
                    ci.FECHACONTROL = fechacontrol2
                    ci.FICHA = sa.ID
                    ci.FECHA = fechasolicitud2
                    ci.MUESTRA = sa.IDMUESTRA
                    ci.TIPO = sa.IDTIPOINFORME
                    ci.SUBTIPO = sa.IDSUBINFORME
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = Usuario.ID
                    ci.CONTROLADO = 0
                    ci.guardar(Usuario)
                Next
            End If
        Else
        End If
        '*** TOXICOLOGIA ***********************************************************************
        If ltoxicologia.Count > 0 Then
            Dim ci As New dControldeInformes
            If ltoxicologia.Count < 2 Then
                lista2 = sa.controltoxicologia1(fechad, fechah)
                For Each sa In lista2
                    fechasolicitud = sa.FECHAINGRESO.ToString
                    fechasolicitud2 = Format(fechasolicitud, "yyyy-MM-dd")
                    ci.FECHACONTROL = fechacontrol2
                    ci.FICHA = sa.ID
                    ci.FECHA = fechasolicitud2
                    ci.MUESTRA = sa.IDMUESTRA
                    ci.TIPO = sa.IDTIPOINFORME
                    ci.SUBTIPO = sa.IDSUBINFORME
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = Usuario.ID
                    ci.CONTROLADO = 0
                    ci.guardar(Usuario)
                Next
            Else
                lista2 = sa.controltoxicologia2(fechad, fechah)
                For Each sa In lista2
                    fechasolicitud = sa.FECHAINGRESO.ToString
                    fechasolicitud2 = Format(fechasolicitud, "yyyy-MM-dd")
                    ci.FECHACONTROL = fechacontrol2
                    ci.FICHA = sa.ID
                    ci.FECHA = fechasolicitud2
                    ci.MUESTRA = sa.IDMUESTRA
                    ci.TIPO = sa.IDTIPOINFORME
                    ci.SUBTIPO = sa.IDSUBINFORME
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = Usuario.ID
                    ci.CONTROLADO = 0
                    ci.guardar(Usuario)
                Next
            End If
        Else
        End If
        '*** SEROLOGIA ***********************************************************************
        If lserologia.Count > 0 Then
            Dim ci As New dControldeInformes
            If lserologia.Count < 2 Then
                lista2 = sa.controlserologia1(fechad, fechah)
                For Each sa In lista2
                    fechasolicitud = sa.FECHAINGRESO.ToString
                    fechasolicitud2 = Format(fechasolicitud, "yyyy-MM-dd")
                    ci.FECHACONTROL = fechacontrol2
                    ci.FICHA = sa.ID
                    ci.FECHA = fechasolicitud2
                    ci.MUESTRA = sa.IDMUESTRA
                    ci.TIPO = sa.IDTIPOINFORME
                    ci.SUBTIPO = sa.IDSUBINFORME
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = Usuario.ID
                    ci.CONTROLADO = 0
                    ci.guardar(Usuario)
                Next
            Else
                lista2 = sa.controlserologia2(fechad, fechah)
                For Each sa In lista2
                    fechasolicitud = sa.FECHAINGRESO.ToString
                    fechasolicitud2 = Format(fechasolicitud, "yyyy-MM-dd")
                    ci.FECHACONTROL = fechacontrol2
                    ci.FICHA = sa.ID
                    ci.FECHA = fechasolicitud2
                    ci.MUESTRA = sa.IDMUESTRA
                    ci.TIPO = sa.IDTIPOINFORME
                    ci.SUBTIPO = sa.IDSUBINFORME
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = Usuario.ID
                    ci.CONTROLADO = 0
                    ci.guardar(Usuario)
                Next
            End If
        Else
        End If
        '*** PAL ***********************************************************************
        If lpal.Count > 0 Then
            Dim ci As New dControldeInformes
            If lpal.Count < 2 Then
                lista2 = sa.controlpal1(fechad, fechah)
                For Each sa In lista2
                    fechasolicitud = sa.FECHAINGRESO.ToString
                    fechasolicitud2 = Format(fechasolicitud, "yyyy-MM-dd")
                    ci.FECHACONTROL = fechacontrol2
                    ci.FICHA = sa.ID
                    ci.FECHA = fechasolicitud2
                    ci.MUESTRA = sa.IDMUESTRA
                    ci.TIPO = sa.IDTIPOINFORME
                    ci.SUBTIPO = sa.IDSUBINFORME
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = Usuario.ID
                    ci.CONTROLADO = 0
                    ci.guardar(Usuario)
                Next
            Else
                lista2 = sa.controlpal2(fechad, fechah)
                For Each sa In lista2
                    fechasolicitud = sa.FECHAINGRESO.ToString
                    fechasolicitud2 = Format(fechasolicitud, "yyyy-MM-dd")
                    ci.FECHACONTROL = fechacontrol2
                    ci.FICHA = sa.ID
                    ci.FECHA = fechasolicitud2
                    ci.MUESTRA = sa.IDMUESTRA
                    ci.TIPO = sa.IDTIPOINFORME
                    ci.SUBTIPO = sa.IDSUBINFORME
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = Usuario.ID
                    ci.CONTROLADO = 0
                    ci.guardar(Usuario)
                Next
            End If
        Else
        End If
        '*** AGUA ***********************************************************************
        If lagua.Count > 0 Then
            Dim ci As New dControldeInformes
            If lagua.Count < 2 Then
                lista2 = sa.controlagua1(fechad, fechah)
                For Each sa In lista2
                    fechasolicitud = sa.FECHAINGRESO.ToString
                    fechasolicitud2 = Format(fechasolicitud, "yyyy-MM-dd")
                    ci.FECHACONTROL = fechacontrol2
                    ci.FICHA = sa.ID
                    ci.FECHA = fechasolicitud2
                    ci.MUESTRA = sa.IDMUESTRA
                    ci.TIPO = sa.IDTIPOINFORME
                    ci.SUBTIPO = sa.IDSUBINFORME
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = Usuario.ID
                    ci.CONTROLADO = 0
                    ci.guardar(Usuario)
                Next
            Else
                lista2 = sa.controlagua2(fechad, fechah)
                For Each sa In lista2
                    fechasolicitud = sa.FECHAINGRESO.ToString
                    fechasolicitud2 = Format(fechasolicitud, "yyyy-MM-dd")
                    ci.FECHACONTROL = fechacontrol2
                    ci.FICHA = sa.ID
                    ci.FECHA = fechasolicitud2
                    ci.MUESTRA = sa.IDMUESTRA
                    ci.TIPO = sa.IDTIPOINFORME
                    ci.SUBTIPO = sa.IDSUBINFORME
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = Usuario.ID
                    ci.CONTROLADO = 0
                    ci.guardar(Usuario)
                Next
            End If
        Else
        End If
        '*** SUBPRODCTOS ***********************************************************************
        If lproductos.Count > 0 Then
            Dim ci As New dControldeInformes
            If lproductos.Count < 2 Then
                lista2 = sa.controlsubproductos1(fechad, fechah)
                For Each sa In lista2
                    fechasolicitud = sa.FECHAINGRESO.ToString
                    fechasolicitud2 = Format(fechasolicitud, "yyyy-MM-dd")
                    ci.FECHACONTROL = fechacontrol2
                    ci.FICHA = sa.ID
                    ci.FECHA = fechasolicitud2
                    ci.MUESTRA = sa.IDMUESTRA
                    ci.TIPO = sa.IDTIPOINFORME
                    ci.SUBTIPO = sa.IDSUBINFORME
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = Usuario.ID
                    ci.CONTROLADO = 0
                    ci.guardar(Usuario)
                Next
            Else
                lista2 = sa.controlsubproductos2(fechad, fechah)
                For Each sa In lista2
                    fechasolicitud = sa.FECHAINGRESO.ToString
                    fechasolicitud2 = Format(fechasolicitud, "yyyy-MM-dd")
                    ci.FECHACONTROL = fechacontrol2
                    ci.FICHA = sa.ID
                    ci.FECHA = fechasolicitud2
                    ci.MUESTRA = sa.IDMUESTRA
                    ci.TIPO = sa.IDTIPOINFORME
                    ci.SUBTIPO = sa.IDSUBINFORME
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = Usuario.ID
                    ci.CONTROLADO = 0
                    ci.guardar(Usuario)
                Next
            End If
        Else
        End If
        '*** BACTERIOLOGIA ***********************************************************************
        If lbacteriologia.Count > 0 Then
            Dim ci As New dControldeInformes
            If lbacteriologia.Count < 2 Then
                lista2 = sa.controlbacteriologia1(fechad, fechah)
                For Each sa In lista2
                    fechasolicitud = sa.FECHAINGRESO.ToString
                    fechasolicitud2 = Format(fechasolicitud, "yyyy-MM-dd")
                    ci.FECHACONTROL = fechacontrol2
                    ci.FICHA = sa.ID
                    ci.FECHA = fechasolicitud2
                    ci.MUESTRA = sa.IDMUESTRA
                    ci.TIPO = sa.IDTIPOINFORME
                    ci.SUBTIPO = sa.IDSUBINFORME
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = Usuario.ID
                    ci.CONTROLADO = 0
                    ci.guardar(Usuario)
                Next
            Else
                lista2 = sa.controlbacteriologia2(fechad, fechah)
                For Each sa In lista2
                    fechasolicitud = sa.FECHAINGRESO.ToString
                    fechasolicitud2 = Format(fechasolicitud, "yyyy-MM-dd")
                    ci.FECHACONTROL = fechacontrol2
                    ci.FICHA = sa.ID
                    ci.FECHA = fechasolicitud2
                    ci.MUESTRA = sa.IDMUESTRA
                    ci.TIPO = sa.IDTIPOINFORME
                    ci.SUBTIPO = sa.IDSUBINFORME
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = Usuario.ID
                    ci.CONTROLADO = 0
                    ci.guardar(Usuario)
                Next
            End If
        Else
        End If

        '*** CONTROL ***********************************************************************
        If lcontrol.Count > 0 Then
            Dim ci As New dControldeInformes
            If lcontrol.Count < 2 Then
                lista2 = sa.controlclechero1(fechad, fechah)
                For Each sa In lista2
                    fechasolicitud = sa.FECHAINGRESO.ToString
                    fechasolicitud2 = Format(fechasolicitud, "yyyy-MM-dd")
                    ci.FECHACONTROL = fechacontrol2
                    ci.FICHA = sa.ID
                    ci.FECHA = fechasolicitud2
                    ci.MUESTRA = sa.IDMUESTRA
                    ci.TIPO = sa.IDTIPOINFORME
                    ci.SUBTIPO = sa.IDSUBINFORME
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = Usuario.ID
                    ci.CONTROLADO = 0
                    ci.guardar(Usuario)
                Next
            Else
                lista2 = sa.controlclechero2(fechad, fechah)
                For Each sa In lista2
                    fechasolicitud = sa.FECHAINGRESO.ToString
                    fechasolicitud2 = Format(fechasolicitud, "yyyy-MM-dd")
                    ci.FECHACONTROL = fechacontrol2
                    ci.FICHA = sa.ID
                    ci.FECHA = fechasolicitud2
                    ci.MUESTRA = sa.IDMUESTRA
                    ci.TIPO = sa.IDTIPOINFORME
                    ci.SUBTIPO = sa.IDSUBINFORME
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = Usuario.ID
                    ci.CONTROLADO = 0
                    ci.guardar(Usuario)
                Next
            End If
        Else
        End If
        '*** CALIDAD ***********************************************************************
        If lcalidad.Count > 0 Then
            Dim ci As New dControldeInformes
            If lcalidad.Count < 2 Then
                lista2 = sa.controlcalidad1(fechad, fechah)
                For Each sa In lista2
                    fechasolicitud = sa.FECHAINGRESO.ToString
                    fechasolicitud2 = Format(fechasolicitud, "yyyy-MM-dd")
                    ci.FECHACONTROL = fechacontrol2
                    ci.FICHA = sa.ID
                    ci.FECHA = fechasolicitud2
                    ci.MUESTRA = sa.IDMUESTRA
                    ci.TIPO = sa.IDTIPOINFORME
                    ci.SUBTIPO = sa.IDSUBINFORME
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = Usuario.ID
                    ci.CONTROLADO = 0
                    ci.guardar(Usuario)
                Next
            Else
                If faltan > 0 Then
                    faltan = faltan + 2
                    lista2 = sa.controlcalidadvarios(fechad, fechah, faltan)
                Else
                    lista2 = sa.controlcalidad2(fechad, fechah)
                End If
                For Each sa In lista2
                    fechasolicitud = sa.FECHAINGRESO.ToString
                    fechasolicitud2 = Format(fechasolicitud, "yyyy-MM-dd")
                    ci.FECHACONTROL = fechacontrol2
                    ci.FICHA = sa.ID
                    ci.FECHA = fechasolicitud2
                    ci.MUESTRA = sa.IDMUESTRA
                    ci.TIPO = sa.IDTIPOINFORME
                    ci.SUBTIPO = sa.IDSUBINFORME
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = Usuario.ID
                    ci.CONTROLADO = 0
                    ci.guardar(Usuario)
                Next
            End If
        Else
        End If
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.ColumnIndex = DataGridView1.Columns(8).Index Then
            check_resultado = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            If check_resultado = 0 Then
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True
            Else
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
            End If
        End If
        If e.ColumnIndex = DataGridView1.Columns(9).Index Then
            check_coincide = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            If check_coincide = 0 Then
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True
            Else
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
            End If
        End If
        If e.ColumnIndex = DataGridView1.Columns(10).Index Then
            check_om = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            If check_om = 0 Then
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True
            Else
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
            End If
        End If
        If e.ColumnIndex = DataGridView1.Columns(11).Index Then
            check_nc = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            If check_nc = 0 Then
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True
            Else
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
            End If
        End If
    End Sub
   

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim Arch1 As String, Arch2 As String, Arch3 As String, Arch4 As String, Arch5 As String, Arch6 As String, Arch7 As String, Arch8 As String
       

        If DataGridView1.Columns(e.ColumnIndex).Name = "Resultado" Then
            If check_resultado = 0 Then
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim id As Long = 0
                Dim ci As New dControldeInformes
                id = row.Cells("Id").Value
                ci.ID = id
                ci.marcarresultado(Usuario)
                listarinformes()
            Else
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim id As Long = 0
                Dim ci As New dControldeInformes
                id = row.Cells("Id").Value
                ci.ID = id
                ci.desmarcarresultado(Usuario)
                listarinformes()
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Coincide" Then
            If check_coincide = 0 Then
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim id As Long = 0
                Dim ci As New dControldeInformes
                id = row.Cells("Id").Value
                ci.ID = id
                ci.marcarcoincide(Usuario)
                listarinformes()
            Else
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim id As Long = 0
                Dim ci As New dControldeInformes
                id = row.Cells("Id").Value
                ci.ID = id
                ci.desmarcarcoincide(Usuario)
                listarinformes()
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "OM" Then
            If check_om = 0 Then
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim id As Long = 0
                Dim ci As New dControldeInformes
                id = row.Cells("Id").Value
                ci.ID = id
                ci.marcarom(Usuario)
                listarinformes()
            Else
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim id As Long = 0
                Dim ci As New dControldeInformes
                id = row.Cells("Id").Value
                ci.ID = id
                ci.desmarcarom(Usuario)
                listarinformes()
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "NC" Then
            If check_nc = 0 Then
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim id As Long = 0
                Dim ci As New dControldeInformes
                id = row.Cells("Id").Value
                ci.ID = id
                ci.marcarnc(Usuario)
                listarinformes()
            Else
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim id As Long = 0
                Dim ci As New dControldeInformes
                id = row.Cells("Id").Value
                ci.ID = id
                ci.desmarcarnc(Usuario)
                listarinformes()
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Controlada" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim observaciones As String = ""
            Dim ci As New dControldeInformes
            id = row.Cells("Id").Value
            observaciones = row.Cells("Observaciones").Value
            ci.ID = id
            ci.marcarcontrolada(Usuario)
            ci.guardarobservaciones(Usuario, observaciones)
            listarinformes()
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "VerInforme" Then
            Dim sa1 As New dSolicitudAnalisis
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ficha As Long = 0

            Dim ci As New dControldeInformes
            id = row.Cells("Id").Value
            ficha = row.Cells("Ficha").Value
            ci.ID = id
            ci = ci.buscar

            sa1.ID = ficha
            sa1 = sa1.buscar
            If Not sa1 Is Nothing Then
                If sa1.ELIMINADO = 1 Then
                    MsgBox("Esta solicitud fué eliminada!")
                End If
            End If

            If Not ci Is Nothing Then

                If ci.TIPO = 1 Then
                    Arch1 = "\\SRVCOLAVECO\D\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\SRVCOLAVECO\D\NET\CONTROL_LECHERO\" & ficha & ".xls"
                    Arch3 = "\\SRVCOLAVECO\D\NET\CONTROL_LECHERO\" & ficha & ".pdf"
                    Arch4 = "\\SRVCOLAVECO\D\NET\CONTROL_LECHERO\" & ficha & "A.xls"
                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    End If
                    If File.Exists(Arch4) Then
                        System.Diagnostics.Process.Start(Arch4)
                    End If
                ElseIf ci.TIPO = 3 Then
                    Arch1 = "\\SRVCOLAVECO\D\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\SRVCOLAVECO\D\NET\AGUA\" & ficha & ".xls"
                    Arch3 = "\\SRVCOLAVECO\D\NET\AGUA\" & ficha & ".pdf"
                    Arch4 = "\\SRVCOLAVECO\D\NET\AGUA\" & ficha & "A.xls"
                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    End If
                    If File.Exists(Arch4) Then
                        System.Diagnostics.Process.Start(Arch4)
                    End If
                ElseIf ci.TIPO = 4 Then
                    Arch1 = "\\SRVCOLAVECO\D\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\SRVCOLAVECO\D\NET\ANTIBIOGRAMA\" & ficha & ".xls"
                    Arch3 = "\\SRVCOLAVECO\D\NET\ANTIBIOGRAMA\" & ficha & ".pdf"
                    Arch4 = "\\SRVCOLAVECO\D\NET\ANTIBIOGRAMA\" & ficha & "A.xls"
                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    End If
                    If File.Exists(Arch4) Then
                        System.Diagnostics.Process.Start(Arch4)
                    End If
                ElseIf ci.TIPO = 5 Then
                    Arch1 = "\\SRVCOLAVECO\D\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\SRVCOLAVECO\D\NET\PAL\" & ficha & ".xls"
                    Arch3 = "\\SRVCOLAVECO\D\NET\PAL\" & ficha & ".pdf"
                    Arch4 = "\\SRVCOLAVECO\D\NET\PAL\" & ficha & "A.xls"
                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    End If
                    If File.Exists(Arch4) Then
                        System.Diagnostics.Process.Start(Arch4)
                    End If
                ElseIf ci.TIPO = 6 Then
                    Arch1 = "\\SRVCOLAVECO\D\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\SRVCOLAVECO\D\NET\PARASITOLOGIA\" & ficha & ".xls"
                    Arch3 = "\\SRVCOLAVECO\D\NET\PARASITOLOGIA\" & ficha & ".pdf"
                    Arch4 = "\\SRVCOLAVECO\D\NET\PARASITOLOGIA\" & ficha & "A.xls"
                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    End If
                    If File.Exists(Arch4) Then
                        System.Diagnostics.Process.Start(Arch4)
                    End If
                ElseIf ci.TIPO = 7 Then
                    Arch1 = "\\SRVCOLAVECO\D\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\SRVCOLAVECO\D\NET\SUBPRODUCTOS\" & ficha & ".xls"
                    Arch3 = "\\SRVCOLAVECO\D\NET\SUBPRODUCTOS\" & ficha & ".pdf"
                    Arch4 = "\\SRVCOLAVECO\D\NET\SUBPRODUCTOS\" & ficha & "A.xls"
                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    End If
                    If File.Exists(Arch4) Then
                        System.Diagnostics.Process.Start(Arch4)
                    End If
                ElseIf ci.TIPO = 8 Then
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = ficha
                    sa = sa.buscar
                    If sa.IDSUBINFORME = 22 Then
                        Arch1 = "\\SRVCOLAVECO\D\NET\SOLICITUDES\S" & ficha & ".xls"
                        Arch2 = "http://www.mgap.gub.uy/sinavele/hsinavele.aspx"

                        'Arch2 = "\\SRVCOLAVECO\D\NET\SEROLOGIA\" & ficha & ".xls"
                        'Arch3 = "\\SRVCOLAVECO\D\NET\SEROLOGIA\" & ficha & ".pdf"
                        'Arch4 = "\\SRVCOLAVECO\D\NET\SEROLOGIA\" & ficha & "A.xls"
                        If File.Exists(Arch1) Then
                            System.Diagnostics.Process.Start(Arch1)
                        End If
                        System.Diagnostics.Process.Start(Arch2)
                        'If File.Exists(Arch2) Then
                        '    System.Diagnostics.Process.Start(Arch2)
                        'ElseIf File.Exists(Arch3) Then
                        '    System.Diagnostics.Process.Start(Arch3)
                        'End If
                        'If File.Exists(Arch4) Then
                        '    System.Diagnostics.Process.Start(Arch4)
                        'End If
                    Else
                        'Arch1 = "\\SRVCOLAVECO\D\NET\SOLICITUDES\S" & ficha & ".xls"
                        'Arch2 = "\\SRVCOLAVECO\D\NET\LEPTO\" & ficha & ".xls"
                        'Arch3 = "\\SRVCOLAVECO\D\NET\LEPTO\" & ficha & ".pdf"
                        'Arch4 = "\\SRVCOLAVECO\D\NET\LEPTO Y NEOSPORA\" & ficha & ".xls"
                        'Arch5 = "\\SRVCOLAVECO\D\NET\LEPTO Y NEOSPORA\" & ficha & ".pdf"
                        'Arch6 = "\\SRVCOLAVECO\D\NET\LEUCOSIS\" & ficha & ".xls"
                        'Arch7 = "\\SRVCOLAVECO\D\NET\LEUCOSIS\" & ficha & ".pdf"
                        Arch1 = "\\SRVCOLAVECO\D\NET\SOLICITUDES\S" & ficha & ".xls"
                        Arch2 = "\\SRVCOLAVECO\D\NET\SEROLOGIA\" & ficha & ".xls"
                        Arch3 = "\\SRVCOLAVECO\D\NET\SEROLOGIA\" & ficha & ".pdf"
                        Arch4 = "\\SRVCOLAVECO\D\NET\SEROLOGIA\" & ficha & ".xls"
                        Arch5 = "\\SRVCOLAVECO\D\NET\SEROLOGIA\" & ficha & ".pdf"
                        Arch6 = "\\SRVCOLAVECO\D\NET\SEROLOGIA\" & ficha & ".xls"
                        Arch7 = "\\SRVCOLAVECO\D\NET\SEROLOGIA\" & ficha & ".pdf"
                        If File.Exists(Arch1) Then
                            System.Diagnostics.Process.Start(Arch1)
                        End If
                        If File.Exists(Arch2) Then
                            System.Diagnostics.Process.Start(Arch2)
                        ElseIf File.Exists(Arch3) Then
                            System.Diagnostics.Process.Start(Arch3)
                        ElseIf File.Exists(Arch5) Then
                            System.Diagnostics.Process.Start(Arch5)
                        ElseIf File.Exists(Arch6) Then
                            System.Diagnostics.Process.Start(Arch6)
                        ElseIf File.Exists(Arch7) Then
                            System.Diagnostics.Process.Start(Arch7)
                        ElseIf File.Exists(Arch8) Then
                            System.Diagnostics.Process.Start(Arch8)
                        End If

                    End If
                ElseIf ci.TIPO = 9 Then
                    Arch1 = "\\SRVCOLAVECO\D\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\SRVCOLAVECO\D\NET\PATOLOGIA\" & ficha & ".xls"
                    Arch3 = "\\SRVCOLAVECO\D\NET\PATOLOGIA\" & ficha & ".pdf"
                    Arch4 = "\\SRVCOLAVECO\D\NET\PATOLOGIA\" & ficha & "A.xls"

                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    End If
                    If File.Exists(Arch4) Then
                        System.Diagnostics.Process.Start(Arch4)
                    End If
                ElseIf ci.TIPO = 10 Then
                    Arch1 = "\\SRVCOLAVECO\D\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\SRVCOLAVECO\D\NET\CALIDAD\" & ficha & ".xls"
                    Arch3 = "\\SRVCOLAVECO\D\NET\CALIDAD\" & ficha & ".pdf"
                    Arch4 = "\\SRVCOLAVECO\D\NET\CALIDAD\" & ficha & "A.xls"
                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    End If
                    If File.Exists(Arch4) Then
                        System.Diagnostics.Process.Start(Arch4)
                    End If
                ElseIf ci.TIPO = 13 Then
                    Arch1 = "\\SRVCOLAVECO\D\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\SRVCOLAVECO\D\NET\AGRO - NUTRICION\" & ficha & ".xls"
                    Arch3 = "\\SRVCOLAVECO\D\NET\AGRO - NUTRICION\" & ficha & ".pdf"
                    Arch4 = "\\SRVCOLAVECO\D\NET\AGRO - NUTRICION\" & ficha & "A.xls"
                    Arch5 = "\\SRVCOLAVECO\D\NET\AGRO - NUTRICION\" & ficha & ".xlsx"
                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    ElseIf File.Exists(Arch5) Then
                        System.Diagnostics.Process.Start(Arch5)
                    End If
                    If File.Exists(Arch4) Then
                        System.Diagnostics.Process.Start(Arch4)
                    End If
                ElseIf ci.TIPO = 14 Then
                    Arch1 = "\\SRVCOLAVECO\D\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\SRVCOLAVECO\D\NET\Agro - suelos\" & ficha & ".xls"
                    Arch3 = "\\SRVCOLAVECO\D\NET\Agro - suelos\" & ficha & ".pdf"
                    Arch4 = "\\SRVCOLAVECO\D\NET\Agro - suelos\" & ficha & "A.xls"
                    Arch5 = "\\SRVCOLAVECO\D\NET\Agro - suelos\" & ficha & ".xlsx"
                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    ElseIf File.Exists(Arch5) Then
                        System.Diagnostics.Process.Start(Arch5)
                    End If
                    If File.Exists(Arch4) Then
                        System.Diagnostics.Process.Start(Arch4)
                    End If
                ElseIf ci.TIPO = 15 Then
                    Arch1 = "\\SRVCOLAVECO\D\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\SRVCOLAVECO\D\NET\Brucelosis en leche\" & ficha & ".xls"
                    Arch3 = "\\SRVCOLAVECO\D\NET\Brucelosis en leche\" & ficha & ".pdf"
                    Arch4 = "\\SRVCOLAVECO\D\NET\Brucelosis en leche\" & ficha & "A.xls"
                    Arch5 = "\\SRVCOLAVECO\D\NET\Brucelosis en leche\" & ficha & ".xlsx"
                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    ElseIf File.Exists(Arch5) Then
                        System.Diagnostics.Process.Start(Arch5)
                    End If
                    If File.Exists(Arch4) Then
                        System.Diagnostics.Process.Start(Arch4)
                    End If
                End If
            End If
        End If
    End Sub


    Private Sub ButtonVerControles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonVerControles.Click
        Dim v As New FormControlesRealizados
        v.ShowDialog()
    End Sub

    Private Sub ButtonBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscar.Click
        Dim sa As New dSolicitudAnalisis
        Dim contador As Integer = 0
        Dim fechadesde As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fechad As String
        Dim fechah As String
        Dim fechasolicitud As Date
        Dim fechasolicitud2 As String
        Dim total As Integer = 0
        fechad = Format(fechadesde, "yyyy-MM-dd")
        fechah = Format(fechahasta, "yyyy-MM-dd")
        Dim lista As New ArrayList
        
        Dim fechacontrol As Date = Now
        Dim fechacontrol2 As String = Format(fechacontrol, "yyyy-MM-dd")
        Dim ficha As Long = 0
        Dim fecha As Date = Now
        Dim muestra As Integer = 0
        Dim tipo As Integer = 0
        Dim subtipo As Integer = 0
        Dim resultado As Integer = 0
        Dim coincide As Integer = 0
        Dim observaciones As String = ""
        Dim controlador As Integer = 0
        Dim controlado As Integer = 0

        contador = CantInformes.Value

        lista = sa.listarporfechaxcant(fechad, fechah, contador)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim ci As New dControldeInformes
                For Each sa In lista
                    fechasolicitud = sa.FECHAINGRESO.ToString
                    fechasolicitud2 = Format(fechasolicitud, "yyyy-MM-dd")
                    ci.FECHACONTROL = fechacontrol2
                    ci.FICHA = sa.ID
                    ci.FECHA = fechasolicitud2
                    ci.MUESTRA = sa.IDMUESTRA
                    ci.TIPO = sa.IDTIPOINFORME
                    ci.SUBTIPO = sa.IDSUBINFORME
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = Usuario.ID
                    ci.CONTROLADO = 0
                    ci.guardar(Usuario)
                Next
            End If
        End If
        listarinformes()
    End Sub
End Class