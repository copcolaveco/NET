Public Class pComunicaciones
    Inherits Conectoras.ConexionMySQL_reloj
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dComunicaciones = CType(o, dComunicaciones)
        Dim sql As String = "INSERT INTO notificaciones (id, fecha, idusuario, fechaevento, detalle) VALUES (" & obj.ID & ", '" & obj.FECHA & "', " & obj.IDUSUARIO & ", '" & obj.FECHAEVENTO & "','" & obj.DETALLE & "')"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dComunicaciones = CType(o, dComunicaciones)
        Dim sql As String = "UPDATE notificaciones SET fecha= '" & obj.FECHA & "', idusuario = " & obj.IDUSUARIO & ", fechaevento = '" & obj.FECHAEVENTO & "', detalle = '" & obj.DETALLE & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)



        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dComunicaciones = CType(o, dComunicaciones)
        Dim sql As String = "DELETE FROM notificaciones WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dComunicaciones
        Dim obj As dComunicaciones = CType(o, dComunicaciones)
        Dim l As New dComunicaciones
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, idusuario, fechaevento, detalle FROM notificaciones WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Long)
                l.fecha = CType(unaFila.Item(1), String)
                l.IDUSUARIO = CType(unaFila.Item(2), Integer)
                l.FECHAEVENTO = CType(unaFila.Item(3), String)
                l.detalle = CType(unaFila.Item(4), String)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, idusuario, fechaevento, detalle FROM notificaciones ORDER BY fechaevento DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dComunicaciones
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.IDUSUARIO = CType(unaFila.Item(2), Integer)
                    l.FECHAEVENTO = CType(unaFila.Item(3), String)
                    l.DETALLE = CType(unaFila.Item(4), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxano(ByVal ano As Integer) As ArrayList
        Dim sql As String = "SELECT id, fecha, idusuario, fechaevento, detalle FROM notificaciones WHERE year(desde) = " & ano & " AND year(hasta) = " & ano & " ORDER BY desde ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dComunicaciones
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.IDUSUARIO = CType(unaFila.Item(2), Integer)
                    l.FECHAEVENTO = CType(unaFila.Item(3), String)
                    l.DETALLE = CType(unaFila.Item(4), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxusuarioxfecha(ByVal usu As Integer, ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT id, fecha, idusuario, fechaevento, detalle FROM notificaciones Where idusuario = " & usu & " and fechaevento BETWEEN '" & desde & "' and '" & hasta & "' ORDER BY fecha asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dComunicaciones
                     l.ID = CType(unaFila.Item(0), Long)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.IDUSUARIO = CType(unaFila.Item(2), Integer)
                    l.FECHAEVENTO = CType(unaFila.Item(3), String)
                    l.DETALLE = CType(unaFila.Item(4), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxanoxusuario(ByVal ano As Integer, ByVal idusuario As Integer) As ArrayList
        Dim sql As String = "SELECT id, fecha, idusuario, fechaevento, detalle FROM notificaciones WHERE year(desde) = " & ano & " AND idusuario = " & idusuario & " ORDER BY desde ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dComunicaciones
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.IDUSUARIO = CType(unaFila.Item(2), Integer)
                    l.FECHAEVENTO = CType(unaFila.Item(3), String)
                    l.DETALLE = CType(unaFila.Item(4), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxusuario(ByVal idusuario As Integer, ByVal ano As Integer) As ArrayList
        Dim sql As String = "SELECT id, fecha, idusuario, fechaevento, detalle FROM notificaciones WHERE idusuario= " & idusuario & " AND year(desde) = " & ano & " AND year(hasta) = " & ano & " ORDER BY desde ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dComunicaciones
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.IDUSUARIO = CType(unaFila.Item(2), Integer)
                    l.FECHAEVENTO = CType(unaFila.Item(3), String)
                    l.DETALLE = CType(unaFila.Item(4), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
