Imports System.Net.FtpWebRequest
Imports System.Net
Imports System.IO
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public Class FormTiemposEnviosInformes
    Dim fila As Integer = 0
    Dim columna As Integer = 0
    Dim x1app As Microsoft.Office.Interop.Excel.Application
    Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
    Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
    Private filaexcel As Integer = 1
    Private columnaexcel As Integer = 1
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
        listar_brucelosis_leche()
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
        listar_chequeo()
        listar_nutricion()
        listar_pradera()
        listar_granos()
        listar_raciones()
        listar_semen()
        listar_suelos()

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
        Dim numeros(366) As Integer
        For i = 0 To 366
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
            For i2 = 0 To 200
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
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

    Private Sub listar_brucelosis_leche()
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
        Dim numeros(300) As Integer
        For i = 0 To 300
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_brucelosis_leche(fecdesde, fechasta)
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Brucelosis"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "en Leche"
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Alimentos"
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Alimentos"
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Alimentos"
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Alimentos"
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Alimentos"
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Alimentos"
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Alimentos"
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
        Dim numeros(150) As Integer
        For i = 0 To 150
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
            For i2 = 0 To 150
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
        Dim numeros(200) As Integer
        Dim ficha As Long = 0
        For i = 0 To 200
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_brucelosis(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    ficha = sa.ID
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
            For i2 = 0 To 200
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Calidad de leche"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Esporulados"
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
        Dim numeros(120) As Integer
        For i = 0 To 120
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
            For i2 = 0 To 120
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Nutrición"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Nutrición"
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
    Private Sub listar_suelos()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_suelos(fecdesde, fechasta)
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Suelos"
            columna = columna + 1
            DataGridView1(columna, fila).Value = "Suelos"
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Nutrición"
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Nutrición"
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            DataGridView1.Rows.Add(1)
            DataGridView1(columna, fila).Value = "Nutrición"
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
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

    Private Sub ButtonExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExcel.Click
        'Dim x1app As Microsoft.Office.Interop.Excel.Application
        'Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        'Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        'x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        'x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        'x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        x1hoja.Cells(1, 1).columnwidth = 17
        x1hoja.Cells(1, 2).columnwidth = 18
        x1hoja.Cells(1, 3).columnwidth = 10
        x1hoja.Cells(1, 4).columnwidth = 10
        x1hoja.Cells(1, 5).columnwidth = 10
        x1hoja.Cells(1, 6).columnwidth = 10
        x1hoja.Cells(1, 7).columnwidth = 10

        

        x1hoja.Cells(filaexcel, columnaexcel).formula = "LISTADO DE TIEMPOS DE ENVÍOS DE INFORMES" & " - " & Now
        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
        filaexcel = filaexcel + 2
        x1hoja.Cells(filaexcel, columnaexcel).formula = "TIPO"
        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
        columnaexcel = columnaexcel + 1
        x1hoja.Cells(filaexcel, columnaexcel).formula = "SUBTIPO"
        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
        columnaexcel = columnaexcel + 1
        x1hoja.Cells(filaexcel, columnaexcel).formula = "INFORMES"
        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
        columnaexcel = columnaexcel + 1
        x1hoja.Cells(filaexcel, columnaexcel).formula = "MÍNIMO"
        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
        columnaexcel = columnaexcel + 1
        x1hoja.Cells(filaexcel, columnaexcel).formula = "MÁXIMO"
        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
        columnaexcel = columnaexcel + 1
        x1hoja.Cells(filaexcel, columnaexcel).formula = "MEDIA"
        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
        columnaexcel = columnaexcel + 1
        x1hoja.Cells(filaexcel, columnaexcel).formula = "PROMEDIO"
        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
        filaexcel = filaexcel + 1
        columnaexcel = 1

        listar_clechero_2()
        listar_controlurea_2()
        listar_completo_2()
        listar_fqcompleto_2()
        listar_bacteriologico_2()
        listar_fqcloro_2()
        listar_fqcondph_2()
        listar_heterotroficos_2()
        listar_antibiograma_2()
        listar_bactanque_2()
        listar_aislamiento_2()
        listar_brucelosis_leche_2()
        listar_parasitologia_2()
        listar_paquete1_2()
        listar_paquete2_2()
        listar_paquete3_2()
        listar_fq_2()
        listar_microbiologia_2()
        listar_otros_2()
        listar_microfq_2()
        listar_serologia_2()
        listar_brucelosis_2()
        listar_leucosis_2()
        listar_anaclinicos_2()
        listar_patologia_2()
        listar_toxicologia_2()
        listar_patologiaotros_2()
        listar_calidad_2()
        listar_todo_2()
        listar_delvoycrios_2()
        listar_esporulados_2()
        listar_composicion_2()
        listar_enterobacterias_2()
        listar_nutricion_2()
        listar_pradera_2()
        listar_granos_2()
        listar_raciones_2()
        listar_semen_2()
        listar_suelos_2()

        x1app.Visible = True
        'x1libro.PrintPreview()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub listar_clechero_2()
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
        Dim numeros(400) As Integer
        For i = 0 To 400
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Control lechero"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Control lechero"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1
        End If
    End Sub
    Private Sub listar_controlurea_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Control lechero"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Control + urea"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_completo_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Agua"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Completo"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_fqcompleto_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Agua"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "FQ Completo"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_bacteriologico_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Agua"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Bacteriológico"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_fqcloro_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Agua"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "FQ Cloro"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_fqcondph_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Agua"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "FQ (conductividad/ph)"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_heterotroficos_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Agua"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Heterotróficos"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_antibiograma_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Bact. y antibiograma"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Antibiograma"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_bactanque_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Bact. y antibiograma"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Bact. de tanque"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_aislamiento_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Bact. y antibiograma"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Aislamiento bact."
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub

    Private Sub listar_brucelosis_leche_2()
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
        Dim numeros(300) As Integer
        For i = 0 To 300
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_brucelosis_leche(fecdesde, fechasta)
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Brucelosis"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "en leche"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1
        End If
    End Sub
    Private Sub listar_parasitologia_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Parasitología"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Parásitos internos"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_paquete1_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Alimentos"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Paq.1 Microbiológico"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_paquete2_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Alimentos"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Paq.2 Microbiológico"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_paquete3_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Alimentos"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Paq.3 Microbiológico"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_fq_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Alimentos"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "FQ"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_microbiologia_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Alimentos"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Microbiología"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_otros_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Alimentos"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Otros"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_microfq_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Alimentos"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Microbiológico - FQ"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_serologia_2()
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
        Dim numeros(150) As Integer
        For i = 0 To 150
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
            For i2 = 0 To 150
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Serología"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Serología otros"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_brucelosis_2()
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
        Dim numeros(200) As Integer
        Dim ficha As Long = 0
        For i = 0 To 200
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_brucelosis(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each sa In lista
                    ficha = sa.ID
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Serología"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Brucelosis"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_leucosis_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Serología"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Leucosis"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_anaclinicos_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Serología"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Análisis clínicos"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_patologia_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Patología - Toxicología"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Patología"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1
        End If
    End Sub
    Private Sub listar_toxicologia_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Patología - Toxicología"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Toxicología"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_patologiaotros_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Patología - Toxicología"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Patología otros"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_calidad_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Calidad de leche"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Calidad de leche"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_esporulados_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Calidad de leche"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Esporulados"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_todo_2()
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
        Dim numeros(120) As Integer
        For i = 0 To 120
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
            For i2 = 0 To 120
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Calidad de leche"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Todo"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_delvoycrios_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Calidad de leche"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Todo Delvo y crioscopía"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_composicion_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Calidad de leche"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Composición y urea"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_enterobacterias_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Ambiental"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Enterobacterias"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub

    Private Sub listar_nutricion_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Nutrición"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Nutrición"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_suelos_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
            numeros(i) = 0
        Next i
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.lista_sol_suelos(fecdesde, fechasta)
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Suelos"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Suelos"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_pradera_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Nutrición"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Pradera"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_granos_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Nutrición"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Granos"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_raciones_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Nutrición"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Raciones"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
    Private Sub listar_semen_2()
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
        Dim numeros(200) As Integer
        For i = 0 To 200
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
            For i2 = 0 To 200
                If moda < numeros(i2) Then
                    moda = i2
                End If
            Next i2
            promedio = Math.Round(sumadias / contador, 2)
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Otros servicios"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = "Sémen y venéreas"
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = contador
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = minimo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = maximo
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = moda
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = columnaexcel + 1
            x1hoja.Cells(filaexcel, columnaexcel).formula = promedio
            x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
            x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
            x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
            columnaexcel = 1
            filaexcel = filaexcel + 1

        End If
    End Sub
End Class