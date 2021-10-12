
Public Class FormTiemposEnviosInformes
    Dim fila As Integer = 0
    Dim columna As Integer = 0
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

    End Sub

#End Region
    

    Private Sub ButtonListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListar.Click
        DataGridView1.Rows.Clear()
        listar_clechero()
        listar_controlurea()
        listar_completo()
        listar_fqcompleto()
        listar_bacteriologico()
        listar_fqcloro()
        listar_fqcondph()
        listar_heterotroficos()
        listar_antibiograma()
        listar_bactanque()
        listar_aislamiento()
        listar_pal()
        listar_parasitologia()
        listar_paquete1()
        listar_paquete2()
        listar_paquete3()
        listar_fq()
        listar_microbiologia()
        listar_otros()
        listar_microfq()
        listar_serologia()
        listar_brucelosis()
        listar_leucosis()
        listar_anaclinicos()
        listar_patologia()
        listar_toxicologia()
        listar_patologiaotros()
        listar_calidad()
        listar_todo()
        listar_delvoycrios()
        listar_esporulados()
        listar_composicion()
        listar_enterobacterias()
        listar_lactometros()
        listar_chequeo()
        listar_nutricion()
        listar_pradera()
        listar_granos()
        listar_raciones()
        listar_semen()
    End Sub
    Private Sub listar_clechero()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_clechero(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Control lechero"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Control lechero"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_controlurea()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_controlurea(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Control lechero"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Control + urea"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_completo()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_completo(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Agua"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Completo"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_fqcompleto()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_fqcompleto(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Agua"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "FQ Completo"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_bacteriologico()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_bacteriologico(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Agua"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Bacteriológico"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_fqcloro()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_fqcloro(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Agua"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "FQ (cloro)"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_fqcondph()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_fqcondph(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Agua"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "FQ (conductividad/ph)"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_heterotroficos()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_heterotroficos(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Agua"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Heterotróficos"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_antibiograma()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_antibiograma(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Bact. y antibiograma"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Antibiograma"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_bactanque()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_bactanque(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Bact. y antibiograma"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Bact. de tanque"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_aislamiento()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_aislamiento(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Bact. y antibiograma "
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Aislamiento bact."
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_pal()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_pal(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "PAL"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "PAL"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_parasitologia()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_parasitologia(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Parasitología"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Parásitos internos"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_paquete1()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_paquete1(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Prodúctos lácteos"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Paq.1 Microbiológico"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_paquete2()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_paquete2(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Prodúctos lácteos"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Paq.2 Microbiológico"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_paquete3()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_paquete3(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Prodúctos lácteos"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Paq.3 Microbiológico"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_fq()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_fq(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Prodúctos lácteos"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "FQ"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_microbiologia()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_microbiologia(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Prodúctos lácteos"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Microbiología"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_otros()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_otros(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Prodúctos lácteos"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Otros"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_microfq()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_microfq(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Prodúctos lácteos"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Microbiológico -FQ"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_serologia()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_serologia(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Serología"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Serología otros"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_brucelosis()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_brucelosis(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Serología"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Brucelosis"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_leucosis()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_leucosis(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Serología"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Leucosis"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_anaclinicos()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_anaclinicos(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Serología"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Análisis clínicos"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_patologia()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_patologia(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Patología - Toxicología"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Patología"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_toxicologia()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_toxicologia(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Patología - Toxicología"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Toxicología"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_patologiaotros()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_patologiaotros(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Patología - Toxicología"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Patología otros"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_calidad()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_calidad(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Calidad de leche"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Calidad de leche"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_esporulados()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_calidad_esporulados(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Calidad de leche"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Calidad de leche"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_todo()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_todo(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Calidad de leche"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Todo"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_delvoycrios()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_delvoycrios(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Calidad de leche"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Todo Delvo y crioscopía"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_composicion()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_composicion(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Calidad de leche"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Coposición y urea"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_enterobacterias()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_enterobacterias(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Ambiental"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Enterobacterias"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_lactometros()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_lactometros(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Lactómetros - Chequeos"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Lactómetros"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_chequeo()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_chequeo(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Lactómetros - Chequeos"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Chequeo de máquina"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_nutricion()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_nutricion(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Agro Nutrición"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Paquete nutrición por NIRS"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_pradera()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_pradera(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Agro Nutrición"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Pradera"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_granos()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_granos(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Agro Nutrición"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Granos"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_raciones()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_raciones(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Agro Nutrición"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Raciones"
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
    Private Sub listar_semen()
        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim minimo As Integer = 2
        Dim maximo As Integer = 0
        Dim media As Double = 0
        Dim promedio As Double = 0
        Dim moda As Integer = 0
        Dim contador As Integer = 0
        Dim dias As Integer = 0
        Dim sumadias As Integer = 0
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim numeros(100) As Integer
        For i = 0 To 100
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_semen(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    fechainicio = sa.FECHAINGRESO
                    fechafin = sa.FECHAENVIO
                    dias = (fechafin - fechainicio).TotalDays
                    If minimo > dias Then
                        minimo = dias
                    End If
                    If maximo < dias Then
                        maximo = dias
                    End If
                    sumadias = sumadias + dias
                    contador = contador + 1
                    numeros(dias) = numeros(dias) + 1
                Next
            End If
            For i2 = 0 To 100
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Otros servicios"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Sémen y venereas "
            columna = columna + 1
            DataGridView1(columna, fila).Value = contador
            columna = columna + 1
            DataGridView1(columna, fila).Value = minimo
            columna = columna + 1
            DataGridView1(columna, fila).Value = maximo
            columna = columna + 1
            DataGridView1(columna, fila).Value = moda
            columna = columna + 1
            DataGridView1(columna, fila).Value = promedio
            columna = 0
            fila = fila + 1

        End If
    End Sub
End Class