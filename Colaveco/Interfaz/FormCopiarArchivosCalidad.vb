Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System
Imports System.IO
Imports System.Collections
Imports System.Net.FtpWebRequest
Imports System.Net
Public Class FormCopiarArchivosCalidad

    Private Sub ButtonCopiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCopiar.Click
        copiarcalcarcarmelo()
        copiarcalcartarariras()
        copiarcaldem()
        copiardulei()
        copiarecolat()
        copiarbrassetti()
        copiarcardonai()
        copiarsaltoi()
        copiarmagnolia()
        copiarnaturalia()
        copiarpinerolo()


        'copiarsecale()
        MsgBox("LISTO!!!")
    End Sub
    Private Sub copiarcalcarcarmelo()
        Dim calcarcarmelo As Integer = 219
        Dim calcartarariras As Integer = 4688
        Dim caldem As Integer = 149
        Dim dulei As Integer = 809
        Dim ecolat As Integer = 143
        Dim granjabrassetti As Integer = 107
        Dim cardonaindulacsa As Integer = 150
        Dim saltoindulacsa As Integer = 2705
        Dim lamagnolia As Integer = 157
        Dim naturalia As Integer = 144
        Dim pinerolo As Integer = 140
        Dim secale As Integer = 2427
        Dim nombrearchivo As String = ""
        Dim nombreempresa As String = ""
        Dim lista As New ArrayList
        Dim sa As New dSolicitudAnalisis
        lista = sa.listarporproductor2(calcarcarmelo)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each sa In lista
                    nombrearchivo = sa.ID & ".xls"
                    nombreempresa = "CALCAR CARMELO"
                    '*** MOVER ARCHIVO ***********************************************************************
                    'Dim sArchivoOrigen As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & nombrearchivo
                    Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\CALIDAD\" & nombrearchivo
                    'Dim sRutaDestino As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\pasados NET\" & nombrearchivo
                    Dim sRutaDestino As String = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\" & nombreempresa & "\NET\" & nombrearchivo

                    Try
                        ' Mover el fichero.si existe lo sobreescribe  
                        My.Computer.FileSystem.CopyFile(sArchivoOrigen, _
                                                                sRutaDestino, _
                                                                True)
                        'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                        ' errores  
                    Catch ex As Exception
                        'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                    End Try
                Next
            End If
        End If
    End Sub
    Private Sub copiarcalcartarariras()
        Dim calcarcarmelo As Integer = 219
        Dim calcartarariras As Integer = 4688
        Dim caldem As Integer = 149
        Dim dulei As Integer = 809
        Dim ecolat As Integer = 143
        Dim granjabrassetti As Integer = 107
        Dim cardonaindulacsa As Integer = 150
        Dim saltoindulacsa As Integer = 2705
        Dim lamagnolia As Integer = 157
        Dim naturalia As Integer = 144
        Dim pinerolo As Integer = 140
        Dim secale As Integer = 2427
        Dim nombrearchivo As String = ""
        Dim nombreempresa As String = ""
        Dim lista As New ArrayList
        Dim sa As New dSolicitudAnalisis
        lista = sa.listarporproductor2(calcartarariras)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each sa In lista
                    nombrearchivo = sa.ID & ".xls"
                    nombreempresa = "CALCAR TARARIRAS"
                    '*** MOVER ARCHIVO ***********************************************************************
                    'Dim sArchivoOrigen As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & nombrearchivo
                    Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\CALIDAD\" & nombrearchivo
                    'Dim sRutaDestino As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\pasados NET\" & nombrearchivo
                    Dim sRutaDestino As String = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\" & nombreempresa & "\NET\" & nombrearchivo

                    Try
                        ' Mover el fichero.si existe lo sobreescribe  
                        My.Computer.FileSystem.CopyFile(sArchivoOrigen, _
                                                                sRutaDestino, _
                                                                True)
                        'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                        ' errores  
                    Catch ex As Exception
                        'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                    End Try
                Next
            End If
        End If
    End Sub
    Private Sub copiarcaldem()
        Dim calcar As Integer = 219
        Dim caldem As Integer = 149
        Dim dulei As Integer = 809
        Dim ecolat As Integer = 143
        Dim granjabrassetti As Integer = 107
        Dim cardonaindulacsa As Integer = 150
        Dim saltoindulacsa As Integer = 2705
        Dim lamagnolia As Integer = 157
        Dim naturalia As Integer = 144
        Dim pinerolo As Integer = 140
        Dim secale As Integer = 2427
        Dim nombrearchivo As String = ""
        Dim nombreempresa As String = ""
        Dim lista As New ArrayList
        Dim sa As New dSolicitudAnalisis
        lista = sa.listarporproductor2(caldem)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each sa In lista
                    nombrearchivo = sa.ID & ".xls"
                    nombreempresa = "CALDEM"
                    '*** MOVER ARCHIVO ***********************************************************************
                    'Dim sArchivoOrigen As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & nombrearchivo
                    Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\CALIDAD\" & nombrearchivo
                    'Dim sRutaDestino As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\pasados NET\" & nombrearchivo
                    Dim sRutaDestino As String = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\" & nombreempresa & "\NET\" & nombrearchivo

                    Try
                        ' Mover el fichero.si existe lo sobreescribe  
                        My.Computer.FileSystem.CopyFile(sArchivoOrigen, _
                                                                sRutaDestino, _
                                                                True)
                        'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                        ' errores  
                    Catch ex As Exception
                        'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                    End Try
                Next
            End If
        End If
    End Sub
    Private Sub copiardulei()
        Dim calcar As Integer = 219
        Dim caldem As Integer = 149
        Dim dulei As Integer = 809
        Dim ecolat As Integer = 143
        Dim granjabrassetti As Integer = 107
        Dim cardonaindulacsa As Integer = 150
        Dim saltoindulacsa As Integer = 2705
        Dim lamagnolia As Integer = 157
        Dim naturalia As Integer = 144
        Dim pinerolo As Integer = 140
        Dim secale As Integer = 2427
        Dim nombrearchivo As String = ""
        Dim nombreempresa As String = ""
        Dim lista As New ArrayList
        Dim sa As New dSolicitudAnalisis
        lista = sa.listarporproductor2(dulei)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each sa In lista
                    nombrearchivo = sa.ID & ".xls"
                    nombreempresa = "DULEI"
                    '*** MOVER ARCHIVO ***********************************************************************
                    'Dim sArchivoOrigen As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & nombrearchivo
                    Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\CALIDAD\" & nombrearchivo
                    'Dim sRutaDestino As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\pasados NET\" & nombrearchivo
                    Dim sRutaDestino As String = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\" & nombreempresa & "\NET\" & nombrearchivo

                    Try
                        ' Mover el fichero.si existe lo sobreescribe  
                        My.Computer.FileSystem.CopyFile(sArchivoOrigen, _
                                                                sRutaDestino, _
                                                                True)
                        'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                        ' errores  
                    Catch ex As Exception
                        'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                    End Try
                Next
            End If
        End If
    End Sub
    Private Sub copiarecolat()
        Dim calcar As Integer = 219
        Dim caldem As Integer = 149
        Dim dulei As Integer = 809
        Dim ecolat As Integer = 143
        Dim granjabrassetti As Integer = 107
        Dim cardonaindulacsa As Integer = 150
        Dim saltoindulacsa As Integer = 2705
        Dim lamagnolia As Integer = 157
        Dim naturalia As Integer = 144
        Dim pinerolo As Integer = 140
        Dim secale As Integer = 2427
        Dim nombrearchivo As String = ""
        Dim nombreempresa As String = ""
        Dim lista As New ArrayList
        Dim sa As New dSolicitudAnalisis
        lista = sa.listarporproductor2(ecolat)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each sa In lista
                    nombrearchivo = sa.ID & ".xls"
                    nombreempresa = "ECOLAT"
                    '*** MOVER ARCHIVO ***********************************************************************
                    'Dim sArchivoOrigen As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & nombrearchivo
                    Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\CALIDAD\" & nombrearchivo
                    'Dim sRutaDestino As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\pasados NET\" & nombrearchivo
                    Dim sRutaDestino As String = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\" & nombreempresa & "\NET\" & nombrearchivo

                    Try
                        ' Mover el fichero.si existe lo sobreescribe  
                        My.Computer.FileSystem.CopyFile(sArchivoOrigen, _
                                                                sRutaDestino, _
                                                                True)
                        'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                        ' errores  
                    Catch ex As Exception
                        'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                    End Try
                Next
            End If
        End If
    End Sub
    Private Sub copiarbrassetti()
        Dim calcar As Integer = 219
        Dim caldem As Integer = 149
        Dim dulei As Integer = 809
        Dim ecolat As Integer = 143
        Dim granjabrassetti As Integer = 107
        Dim cardonaindulacsa As Integer = 150
        Dim saltoindulacsa As Integer = 2705
        Dim lamagnolia As Integer = 157
        Dim naturalia As Integer = 144
        Dim pinerolo As Integer = 140
        Dim secale As Integer = 2427
        Dim nombrearchivo As String = ""
        Dim nombreempresa As String = ""
        Dim lista As New ArrayList
        Dim sa As New dSolicitudAnalisis
        lista = sa.listarporproductor2(granjabrassetti)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each sa In lista
                    nombrearchivo = sa.ID & ".xls"
                    nombreempresa = "GRANJA BRASSETTI"
                    '*** MOVER ARCHIVO ***********************************************************************
                    'Dim sArchivoOrigen As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & nombrearchivo
                    Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\CALIDAD\" & nombrearchivo
                    'Dim sRutaDestino As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\pasados NET\" & nombrearchivo
                    Dim sRutaDestino As String = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\" & nombreempresa & "\NET\" & nombrearchivo

                    Try
                        ' Mover el fichero.si existe lo sobreescribe  
                        My.Computer.FileSystem.CopyFile(sArchivoOrigen, _
                                                                sRutaDestino, _
                                                                True)
                        'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                        ' errores  
                    Catch ex As Exception
                        'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                    End Try
                Next
            End If
        End If
    End Sub
    Private Sub copiarcardonai()
        Dim calcar As Integer = 219
        Dim caldem As Integer = 149
        Dim dulei As Integer = 809
        Dim ecolat As Integer = 143
        Dim granjabrassetti As Integer = 107
        Dim cardonaindulacsa As Integer = 150
        Dim saltoindulacsa As Integer = 2705
        Dim lamagnolia As Integer = 157
        Dim naturalia As Integer = 144
        Dim pinerolo As Integer = 140
        Dim secale As Integer = 2427
        Dim nombrearchivo As String = ""
        Dim nombreempresa As String = ""
        Dim lista As New ArrayList
        Dim sa As New dSolicitudAnalisis
        lista = sa.listarporproductor2(cardonaindulacsa)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each sa In lista
                    nombrearchivo = sa.ID & ".xls"
                    nombreempresa = "CARDONA INDULACSA"
                    '*** MOVER ARCHIVO ***********************************************************************
                    'Dim sArchivoOrigen As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & nombrearchivo
                    Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\CALIDAD\" & nombrearchivo
                    'Dim sRutaDestino As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\pasados NET\" & nombrearchivo
                    Dim sRutaDestino As String = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\" & nombreempresa & "\NET\" & nombrearchivo

                    Try
                        ' Mover el fichero.si existe lo sobreescribe  
                        My.Computer.FileSystem.CopyFile(sArchivoOrigen, _
                                                                sRutaDestino, _
                                                                True)
                        'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                        ' errores  
                    Catch ex As Exception
                        'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                    End Try
                Next
            End If
        End If
    End Sub
    Private Sub copiarsaltoi()
        Dim calcar As Integer = 219
        Dim caldem As Integer = 149
        Dim dulei As Integer = 809
        Dim ecolat As Integer = 143
        Dim granjabrassetti As Integer = 107
        Dim cardonaindulacsa As Integer = 150
        Dim saltoindulacsa As Integer = 2705
        Dim lamagnolia As Integer = 157
        Dim naturalia As Integer = 144
        Dim pinerolo As Integer = 140
        Dim secale As Integer = 2427
        Dim nombrearchivo As String = ""
        Dim nombreempresa As String = ""
        Dim lista As New ArrayList
        Dim sa As New dSolicitudAnalisis
        lista = sa.listarporproductor2(saltoindulacsa)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each sa In lista
                    nombrearchivo = sa.ID & ".xls"
                    nombreempresa = "SALTO INDULACSA"
                    '*** MOVER ARCHIVO ***********************************************************************
                    'Dim sArchivoOrigen As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & nombrearchivo
                    Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\CALIDAD\" & nombrearchivo
                    'Dim sRutaDestino As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\pasados NET\" & nombrearchivo
                    Dim sRutaDestino As String = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\" & nombreempresa & "\NET\" & nombrearchivo

                    Try
                        ' Mover el fichero.si existe lo sobreescribe  
                        My.Computer.FileSystem.CopyFile(sArchivoOrigen, _
                                                                sRutaDestino, _
                                                                True)
                        'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                        ' errores  
                    Catch ex As Exception
                        'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                    End Try
                Next
            End If
        End If
    End Sub
    Private Sub copiarmagnolia()
        Dim calcar As Integer = 219
        Dim caldem As Integer = 149
        Dim dulei As Integer = 809
        Dim ecolat As Integer = 143
        Dim granjabrassetti As Integer = 107
        Dim cardonaindulacsa As Integer = 150
        Dim saltoindulacsa As Integer = 2705
        Dim lamagnolia As Integer = 157
        Dim naturalia As Integer = 144
        Dim pinerolo As Integer = 140
        Dim secale As Integer = 2427
        Dim nombrearchivo As String = ""
        Dim nombreempresa As String = ""
        Dim lista As New ArrayList
        Dim sa As New dSolicitudAnalisis
        lista = sa.listarporproductor2(lamagnolia)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each sa In lista
                    nombrearchivo = sa.ID & ".xls"
                    nombreempresa = "LA MAGNOLIA"
                    '*** MOVER ARCHIVO ***********************************************************************
                    'Dim sArchivoOrigen As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & nombrearchivo
                    Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\CALIDAD\" & nombrearchivo
                    'Dim sRutaDestino As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\pasados NET\" & nombrearchivo
                    Dim sRutaDestino As String = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\" & nombreempresa & "\NET\" & nombrearchivo

                    Try
                        ' Mover el fichero.si existe lo sobreescribe  
                        My.Computer.FileSystem.CopyFile(sArchivoOrigen, _
                                                                sRutaDestino, _
                                                                True)
                        'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                        ' errores  
                    Catch ex As Exception
                        'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                    End Try
                Next
            End If
        End If
    End Sub
    Private Sub copiarnaturalia()
        Dim calcar As Integer = 219
        Dim caldem As Integer = 149
        Dim dulei As Integer = 809
        Dim ecolat As Integer = 143
        Dim granjabrassetti As Integer = 107
        Dim cardonaindulacsa As Integer = 150
        Dim saltoindulacsa As Integer = 2705
        Dim lamagnolia As Integer = 157
        Dim naturalia As Integer = 144
        Dim pinerolo As Integer = 140
        Dim secale As Integer = 2427
        Dim nombrearchivo As String = ""
        Dim nombreempresa As String = ""
        Dim lista As New ArrayList
        Dim sa As New dSolicitudAnalisis
        lista = sa.listarporproductor2(naturalia)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each sa In lista
                    nombrearchivo = sa.ID & ".xls"
                    nombreempresa = "NATURALIA"
                    '*** MOVER ARCHIVO ***********************************************************************
                    'Dim sArchivoOrigen As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & nombrearchivo
                    Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\CALIDAD\" & nombrearchivo
                    'Dim sRutaDestino As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\pasados NET\" & nombrearchivo
                    Dim sRutaDestino As String = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\" & nombreempresa & "\NET\" & nombrearchivo

                    Try
                        ' Mover el fichero.si existe lo sobreescribe  
                        My.Computer.FileSystem.CopyFile(sArchivoOrigen, _
                                                                sRutaDestino, _
                                                                True)
                        'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                        ' errores  
                    Catch ex As Exception
                        'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                    End Try
                Next
            End If
        End If
    End Sub
    Private Sub copiarpinerolo()
        Dim calcar As Integer = 219
        Dim caldem As Integer = 149
        Dim dulei As Integer = 809
        Dim ecolat As Integer = 143
        Dim granjabrassetti As Integer = 107
        Dim cardonaindulacsa As Integer = 150
        Dim saltoindulacsa As Integer = 2705
        Dim lamagnolia As Integer = 157
        Dim naturalia As Integer = 144
        Dim pinerolo As Integer = 140
        Dim secale As Integer = 2427
        Dim nombrearchivo As String = ""
        Dim nombreempresa As String = ""
        Dim lista As New ArrayList
        Dim sa As New dSolicitudAnalisis
        lista = sa.listarporproductor2(pinerolo)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each sa In lista
                    nombrearchivo = sa.ID & ".xls"
                    nombreempresa = "PINEROLO"
                    '*** MOVER ARCHIVO ***********************************************************************
                    'Dim sArchivoOrigen As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & nombrearchivo
                    Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\CALIDAD\" & nombrearchivo
                    'Dim sRutaDestino As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\pasados NET\" & nombrearchivo
                    Dim sRutaDestino As String = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\" & nombreempresa & "\NET\" & nombrearchivo

                    Try
                        ' Mover el fichero.si existe lo sobreescribe  
                        My.Computer.FileSystem.CopyFile(sArchivoOrigen, _
                                                                sRutaDestino, _
                                                                True)
                        'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                        ' errores  
                    Catch ex As Exception
                        'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                    End Try
                Next
            End If
        End If
    End Sub
    Private Sub copiarsecale()
        Dim calcar As Integer = 219
        Dim caldem As Integer = 149
        Dim dulei As Integer = 809
        Dim ecolat As Integer = 143
        Dim granjabrassetti As Integer = 107
        Dim cardonaindulacsa As Integer = 150
        Dim saltoindulacsa As Integer = 2705
        Dim lamagnolia As Integer = 157
        Dim naturalia As Integer = 144
        Dim pinerolo As Integer = 140
        Dim secale As Integer = 2427
        Dim nombrearchivo As String = ""
        Dim nombreempresa As String = ""
        Dim lista As New ArrayList
        Dim sa As New dSolicitudAnalisis
        lista = sa.listarporproductor2(secale)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each sa In lista
                    nombrearchivo = sa.ID & ".xls"
                    nombreempresa = "SECALE"
                    '*** MOVER ARCHIVO ***********************************************************************
                    'Dim sArchivoOrigen As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & nombrearchivo
                    Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\CALIDAD\" & nombrearchivo
                    'Dim sRutaDestino As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\pasados NET\" & nombrearchivo
                    Dim sRutaDestino As String = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\" & nombreempresa & "\NET\" & nombrearchivo

                    Try
                        ' Mover el fichero.si existe lo sobreescribe  
                        My.Computer.FileSystem.CopyFile(sArchivoOrigen, _
                                                                sRutaDestino, _
                                                                True)
                        'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                        ' errores  
                    Catch ex As Exception
                        'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                    End Try
                Next
            End If
        End If
    End Sub
End Class