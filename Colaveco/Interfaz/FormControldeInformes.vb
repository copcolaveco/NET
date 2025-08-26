Imports System.IO
Imports System.Collections.Generic

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
        cargarControladores()
        cargarComboInformes()
        ' listarinformes()
    End Sub

#End Region

    Private Sub listarinformes()
        'Dim ci As New dControldeInformes

        'Dim lista As New ArrayList
        'lista = ci.listar
        'DataGridView1.Rows.Clear()

        'If Not lista Is Nothing Then
        '    If lista.Count > 0 Then


        '        Dim fila As Integer = 0
        '        Dim columna As Integer = 0
        '        DataGridView1.Rows.Add(lista.Count)
        '        For Each ci In lista
        '            Dim m As New dMuestras
        '            Dim ti As New dTipoInforme
        '            Dim si As New dSubInforme
        '            Dim s As New dSinaveleFicha

        '            DataGridView1(columna, fila).Value = ci.ID
        '            columna = columna + 1
        '            DataGridView1(columna, fila).Value = ci.FECHACONTROL
        '            columna = columna + 1
        '            DataGridView1(columna, fila).Value = ci.FICHA
        '            columna = columna + 1
        '            s.FICHA = ci.FICHA
        '            s = s.buscar
        '            If Not s Is Nothing Then
        '                DataGridView1(columna, fila).Value = s.SINAVELE
        '                columna = columna + 1
        '            Else
        '                DataGridView1(columna, fila).Value = ""
        '                columna = columna + 1
        '            End If
        '            DataGridView1(columna, fila).Value = ci.FECHA
        '            columna = columna + 1
        '            m.ID = ci.MUESTRA
        '            m = m.buscar
        '            If Not m Is Nothing Then
        '                DataGridView1(columna, fila).Value = m.NOMBRE
        '                columna = columna + 1
        '            Else
        '                DataGridView1(columna, fila).Value = "vacío"
        '                columna = columna + 1
        '            End If
        '            ti.ID = ci.TIPO
        '            ti = ti.buscar
        '            DataGridView1(columna, fila).Value = ti.NOMBRE
        '            columna = columna + 1
        '            si.ID = ci.SUBTIPO
        '            si = si.buscar
        '            If Not si Is Nothing Then
        '                DataGridView1(columna, fila).Value = si.NOMBRE
        '                columna = columna + 1
        '            Else
        '                DataGridView1(columna, fila).Value = ""
        '                columna = columna + 1
        '            End If
        '            If ci.RESULTADO = 0 Then
        '                DataGridView1(columna, fila).Value = False
        '            Else
        '                DataGridView1(columna, fila).Value = True
        '            End If
        '            columna = columna + 1
        '            If ci.COINCIDE = 0 Then
        '                DataGridView1(columna, fila).Value = False
        '            Else
        '                DataGridView1(columna, fila).Value = True
        '            End If
        '            columna = columna + 1
        '            If ci.OM = 0 Then
        '                DataGridView1(columna, fila).Value = False
        '            Else
        '                DataGridView1(columna, fila).Value = True
        '            End If
        '            columna = columna + 1
        '            If ci.NC = 0 Then
        '                DataGridView1(columna, fila).Value = False
        '            Else
        '                DataGridView1(columna, fila).Value = True
        '            End If
        '            columna = columna + 1
        '            DataGridView1(columna, fila).Value = ci.OBSERVACIONES
        '            columna = columna + 1
        '            DataGridView1(columna, fila).Value = Usuario.NOMBRE
        '            columna = columna + 1
        '            DataGridView1(columna, fila).Value = "Ver informe"
        '            columna = columna + 1
        '            If ci.CONTROLADO = 0 Then
        '                DataGridView1(columna, fila).Value = False
        '            Else
        '                DataGridView1(columna, fila).Value = True
        '            End If
        '            columna = 0
        '            fila = fila + 1
        '        Next
        '    End If
        'End If
    End Sub
    Private Sub buscarinformes()
        Dim sa As New dSolicitudAnalisis
        Dim contador As Integer = 0
        Dim contadorarchivos As Integer = 0
        Dim faltan As Integer = 0
        Dim controllechero As Integer = 0
        Dim calidaddeleche As Integer = 0
        Dim agua As Integer = 0
        Dim alimentos As Integer = 0
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
                        alimentos = alimentos + 1
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
        If lsuelos.Count > 0 Then
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

        'If faltan < 3 Then
        'Dim ci As New dControldeInformes
        DataGridView1.Rows.Clear()

        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each ci In lista
                    Dim ci2 As New dControldeInformes

                    Dim listaControl As New ArrayList

                    listaControl = ci2.listarPorFicha(ci.ID)
                    Dim m As New dMuestras
                    Dim ti As New dTipoInforme
                    Dim si As New dSubInforme
                    Dim s As New dSinaveleFicha

                    Dim controlConControlado As dControlBase

                    Select Case ci.IDTIPOINFORME
                        Case EnumTipoControles.Efluentes
                            controlConControlado = New dControlInformesEfluentes
                        Case EnumTipoControles.FisicoQuimico
                            controlConControlado = New dControlInformesFQ
                        Case EnumTipoControles.Microbiologia
                            controlConControlado = New dControlInformesMicro
                        Case EnumTipoControles.Nutricion
                            controlConControlado = New dControlInformesNutricion
                        Case EnumTipoControles.Suelos
                            controlConControlado = New dControlInformesSuelos
                        Case Else
                            MsgBox("Tipo de control no válido.", MsgBoxStyle.Exclamation, "Atención")
                            Exit Sub
                    End Select

                    Dim lstConNom As dControlBase = controlConControlado.lstConNom(ci.id)

                    DataGridView1(columna, fila).Value = ci.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ci.FECHAINGRESO
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ci.ID
                    columna = columna + 1
                    s.FICHA = ci.ID
                    s = s.buscar
                    If Not s Is Nothing Then
                        DataGridView1(columna, fila).Value = s.SINAVELE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = ci.FECHAINGRESO
                    columna = columna + 1

                    Dim ciResultado As Integer
                    Dim ciCoindide As Integer
                    Dim ciOM As Integer
                    Dim ciNC As Integer
                    Dim ciControlado As Integer

                    If Not listaControl Is Nothing Then
                        For Each i In listaControl
                            m.ID = i.FICHA
                            ciResultado = i.RESULTADO
                            ciCoindide = i.COINCIDE
                            ciOM = i.OM
                            ciNC = i.NC
                            ciControlado = i.CONTROLADO
                        Next
                    End If

                    m = m.buscar
                    If Not m Is Nothing Then
                        DataGridView1(columna, fila).Value = m.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "vacío"
                        columna = columna + 1
                    End If
                    ti.ID = ci.IDTIPOINFORME
                    ti = ti.buscar
                    DataGridView1(columna, fila).Value = ti.NOMBRE
                    columna = columna + 1
                    si.ID = ci.IDSUBINFORME
                    si = si.buscar
                    If Not si Is Nothing Then
                        DataGridView1(columna, fila).Value = si.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    If ciResultado = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = columna + 1
                    If ciCoindide = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = columna + 1
                    If ciOM = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = columna + 1
                    If ciNC = 0 Then
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
                    If ciControlado = 0 Then
                        DataGridView1(columna, fila).Value = False
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = True
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = lstConNom.CONTROLADOString 'Si o No
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = lstConNom.CONTROLADOR ' Nombre de Técnico


                    columna = 0
                    fila = fila + 1
                Next
        End If
        'End If
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
        Dim Arch1 As String, Arch2 As String, Arch3 As String, Arch4 As String, Arch5 As String, Arch6 As String, Arch7 As String
       

        If DataGridView1.Columns(e.ColumnIndex).Name = "resultado" Then
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
        If DataGridView1.Columns(e.ColumnIndex).Name = "coincide" Then
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
        If DataGridView1.Columns(e.ColumnIndex).Name = "opcionmejora" Then
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
        If DataGridView1.Columns(e.ColumnIndex).Name = "noconformidad" Then
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
        If DataGridView1.Columns(e.ColumnIndex).Name = "Controles" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim observaciones As String = ""
            Dim ci As New dControldeInformes
            id = row.Cells("id").Value
            observaciones = row.Cells("Observaciones").Value
            ci.ID = id
            Dim datefechacontrol As Date = Today
            Dim fechaControl As String = datefechacontrol.ToString("yyyy-MM-dd")
            ci.FECHACONTROL = fechaControl
            ci.marcarcontrolada(Usuario)
            'GestorNuevo modificar estado Cotnrol
            Dim controlGestor As New dNGControl
            Try
                'Registro en Gestor Nuevo
                controlGestor.InformeId = id
                controlGestor.ControlFechaRealizado = Today.ToString("yyyy-MM-dd HH:mm:ss")
                controlGestor.ControlControlado = 1
                controlGestor.modificar()
            Catch ex As Exception

            End Try
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
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & ficha & ".xls"
                    Arch3 = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & ficha & ".pdf"
                    Arch4 = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & ficha & "A.xls"
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
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\192.168.1.10\E\NET\AGUA\" & ficha & ".xls"
                    Arch3 = "\\192.168.1.10\E\NET\AGUA\" & ficha & ".pdf"
                    Arch4 = "\\192.168.1.10\E\NET\AGUA\" & ficha & "A.xls"
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
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & ficha & ".xls"
                    Arch3 = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & ficha & ".pdf"
                    Arch4 = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & ficha & "A.xls"
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
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\192.168.1.10\E\NET\PAL\" & ficha & ".xls"
                    Arch3 = "\\192.168.1.10\E\NET\PAL\" & ficha & ".pdf"
                    Arch4 = "\\192.168.1.10\E\NET\PAL\" & ficha & "A.xls"
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
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & ficha & ".xls"
                    Arch3 = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & ficha & ".pdf"
                    Arch4 = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & ficha & "A.xls"
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
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\192.168.1.10\E\NET\ALIMENTOS\" & ficha & ".xls"
                    Arch3 = "\\192.168.1.10\E\NET\ALIMENTOS\" & ficha & ".pdf"
                    Arch4 = "\\192.168.1.10\E\NET\ALIMENTOS\" & ficha & "A.xls"
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
                        Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                        Arch2 = "http://www.mgap.gub.uy/sinavele/hsinavele.aspx"

                        'Arch2 = "\\192.168.1.10\E\NET\SEROLOGIA\" & ficha & ".xls"
                        'Arch3 = "\\192.168.1.10\E\NET\SEROLOGIA\" & ficha & ".pdf"
                        'Arch4 = "\\192.168.1.10\E\NET\SEROLOGIA\" & ficha & "A.xls"
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
                        'Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                        'Arch2 = "\\192.168.1.10\E\NET\LEPTO\" & ficha & ".xls"
                        'Arch3 = "\\192.168.1.10\E\NET\LEPTO\" & ficha & ".pdf"
                        'Arch4 = "\\192.168.1.10\E\NET\LEPTO Y NEOSPORA\" & ficha & ".xls"
                        'Arch5 = "\\192.168.1.10\E\NET\LEPTO Y NEOSPORA\" & ficha & ".pdf"
                        'Arch6 = "\\192.168.1.10\E\NET\LEUCOSIS\" & ficha & ".xls"
                        'Arch7 = "\\192.168.1.10\E\NET\LEUCOSIS\" & ficha & ".pdf"
                        Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                        Arch2 = "\\192.168.1.10\E\NET\SEROLOGIA\" & ficha & ".xls"
                        Arch3 = "\\192.168.1.10\E\NET\SEROLOGIA\" & ficha & ".pdf"
                        Arch4 = "\\192.168.1.10\E\NET\SEROLOGIA\" & ficha & ".xls"
                        Arch5 = "\\192.168.1.10\E\NET\SEROLOGIA\" & ficha & ".pdf"
                        Arch6 = "\\192.168.1.10\E\NET\SEROLOGIA\" & ficha & ".xls"
                        Arch7 = "\\192.168.1.10\E\NET\SEROLOGIA\" & ficha & ".pdf"
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
                            'ElseIf File.Exists(Arch8) Then
                            '    System.Diagnostics.Process.Start(Arch8)
                        End If

                    End If
                ElseIf ci.TIPO = 9 Then
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\192.168.1.10\E\NET\PATOLOGIA\" & ficha & ".xls"
                    Arch3 = "\\192.168.1.10\E\NET\PATOLOGIA\" & ficha & ".pdf"
                    Arch4 = "\\192.168.1.10\E\NET\PATOLOGIA\" & ficha & "A.xls"

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
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\192.168.1.10\E\NET\CALIDAD\" & ficha & ".xls"
                    Arch3 = "\\192.168.1.10\E\NET\CALIDAD\" & ficha & ".pdf"
                    Arch4 = "\\192.168.1.10\E\NET\CALIDAD\" & ficha & "A.xls"
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
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\192.168.1.10\E\NET\NUTRICION\" & ficha & ".xls"
                    Arch3 = "\\192.168.1.10\E\NET\NUTRICION\" & ficha & ".pdf"
                    Arch4 = "\\192.168.1.10\E\NET\NUTRICION\" & ficha & "A.xls"
                    Arch5 = "\\192.168.1.10\E\NET\NUTRICION\" & ficha & ".xlsx"
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
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\192.168.1.10\E\NET\Suelos\" & ficha & ".xls"
                    Arch3 = "\\192.168.1.10\E\NET\Suelos\" & ficha & ".pdf"
                    Arch4 = "\\192.168.1.10\E\NET\Suelos\" & ficha & "A.xls"
                    Arch5 = "\\192.168.1.10\E\NET\Suelos\" & ficha & ".xlsx"
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
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\192.168.1.10\E\NET\Brucelosis en leche\" & ficha & ".xls"
                    Arch3 = "\\192.168.1.10\E\NET\Brucelosis en leche\" & ficha & ".pdf"
                    Arch4 = "\\192.168.1.10\E\NET\Brucelosis en leche\" & ficha & "A.xls"
                    Arch5 = "\\192.168.1.10\E\NET\Brucelosis en leche\" & ficha & ".xlsx"
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

    Private Sub cargarControladores()
        Dim u As New dUsuario
        Dim lista As New ArrayList
        lista = u.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each u In lista
                    If u.TIPOUSUARIO = 98 Then
                        cbxControladores.Items.Add(u)
                    End If
                Next
            End If
        End If
    End Sub

    Public Sub cargarComboInformes()
        Dim ti As New dTipoInforme
        Dim lista As New ArrayList
        lista = ti.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each ti In lista
                    cbxTipoInfome.Items.Add(ti)
                Next
            End If
        End If
    End Sub


    Private Sub ButtonBuscarInformes_Click(sender As Object, e As EventArgs) Handles ButtonBuscarInformes.Click
        Dim fechad As String = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim fechah As String = DateHasta.Value.ToString("yyyy-MM-dd")

        Dim controlador As Integer = 0
        If cbxControladores.SelectedIndex > -1 Then
            Dim uSel As dUsuario = TryCast(cbxControladores.SelectedItem, dUsuario)
            If uSel IsNot Nothing Then controlador = CInt(uSel.ID) ' ← acá tomás el ID real
        End If

        Dim tipo As Integer = 0
        If cbxTipoInfome.SelectedIndex > -1 Then
            ' Igual lógica según cómo cargues este combo:
            ' si también usás Items.Add(obj), hacé TryCast al tipo correcto y saca su ID
            If IsNumeric(cbxTipoInfome.SelectedValue) Then
                tipo = CInt(cbxTipoInfome.SelectedValue)
            Else
                ' fallback si también agregás objetos al Items:
                Dim tSel = TryCast(cbxTipoInfome.SelectedItem, dTipoInforme) ' o el tipo que uses
                If tSel IsNot Nothing Then tipo = CInt(tSel.ID)
            End If
        End If

        Dim p As New pControldeInformes
        Dim dt As DataTable = p.listarIngenieria_Grilla(fechad, fechah, tipo, controlador)
        CargarGrillaIngenieria(dt)
    End Sub


    Private Sub CargarGrillaIngenieria(dt As DataTable)
        DataGridView1.SuspendLayout()
        DataGridView1.Columns.Clear()
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.DataSource = Nothing

        ' Encabezados visibles
        Dim headerMap As New Dictionary(Of String, String) From {
            {"ficha", "Ficha"},
            {"fechacontrol", "Fecha control"},
            {"fecha", "Fecha"},
            {"muestra", "Muestra"},
            {"tipo", "Tipo"},
            {"resultado", "Resulta"},
            {"coincide", "Coincid"},
            {"opcionmejora", "OM"},
            {"noconformidad", "NC"},
            {"observaciones", "Observaciones"},
            {"TecnicoNombre", "Técnico"},
            {"InformeControlado", "Informe controlado"}
        }

        ' Columnas que deben ser checkbox (case-insensitive)
        Dim asCheck As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        asCheck.UnionWith(New String() {
            "resultado", "coincide", "opcionmejora", "noconformidad"
        })

        For Each dc As DataColumn In dt.Columns
            Dim name As String = dc.ColumnName
            Dim col As DataGridViewColumn

            If asCheck.Contains(name) OrElse dc.DataType Is GetType(Boolean) Then
                Dim c As New DataGridViewCheckBoxColumn()
                c.TrueValue = 1 : c.FalseValue = 0 : c.ThreeState = False
                col = c
            Else
                Dim t As New DataGridViewTextBoxColumn()
                If name.ToLower().Contains("fecha") Then t.DefaultCellStyle.Format = "yyyy-MM-dd"
                col = t
            End If

            col.DataPropertyName = name
            col.Name = name
            col.HeaderText = If(headerMap.ContainsKey(name), headerMap(name), name)
            DataGridView1.Columns.Add(col)
        Next

        ' Extras opcionales:
        Dim colBtn As New DataGridViewButtonColumn() With {.Name = "VerInforme", .HeaderText = "Ver Informe", .Text = "Ver", .UseColumnTextForButtonValue = True}
        DataGridView1.Columns.Add(colBtn)

        Dim colChk As New DataGridViewCheckBoxColumn() With {.Name = "Controles", .HeaderText = "Control"}
        DataGridView1.Columns.Add(colChk)

        DataGridView1.DataSource = dt
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        DataGridView1.RowHeadersVisible = False
        DataGridView1.ResumeLayout()
    End Sub


End Class