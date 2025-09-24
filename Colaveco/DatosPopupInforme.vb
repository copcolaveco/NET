Public Class DatosPopupInforme
    Public Property Ficha As Long
    Public Property Cliente As String
    Public Property TipoMuestras As String
    Public Property Analisis As String
    Public Property ObservacionesInternas As String
    Public Property ObservacionesInforme As String
    Public Property CantidadMuestras As Integer
    Public Property Temperatura As String          ' "15º" o solo "15"
    Public Property TipoLeche As String
    Public Property Cajas As String()              ' ej: {"C6050","C6051","C6052"}

    ' Detalle: array de strings "IDMUESTRA||ANALISIS"
    Public Property Detalle As String()

    ' (Opcional) helper para agregar líneas al detalle
    Public Sub AddDetalle(idMuestra As String, analisis As String)
        Dim linea As String = idMuestra & "||" & analisis   ' sin interpolación

        If Detalle Is Nothing OrElse Detalle.Length = 0 Then
            ReDim Detalle(0)               ' crea array de 1 elemento
            Detalle(0) = linea
        Else
            Dim l As New List(Of String)(Detalle)
            l.Add(linea)
            Detalle = l.ToArray()
        End If
    End Sub

End Class
