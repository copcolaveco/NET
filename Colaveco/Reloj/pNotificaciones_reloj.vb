Public Class pNotificaciones_reloj
    Inherits Conectoras.ConexionMySQL_reloj
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNotificaciones_reloj = CType(o, dNotificaciones_reloj)
        Dim sql As String = "INSERT INTO notificaciones (id, fecha, idusuario, fechaevento, detalle) VALUES (" & obj.ID & ", '" & obj.FECHA & "', " & obj.IDUSUARIO & ", '" & obj.FECHAEVENTO & "','" & obj.DETALLE & "')"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNotificaciones_reloj = CType(o, dNotificaciones_reloj)
        Dim sql As String = "UPDATE notificaciones SET fecha= '" & obj.FECHA & "', idusuario = " & obj.IDUSUARIO & ", fechaevento = '" & obj.FECHAEVENTO & "', detalle = '" & obj.DETALLE & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)



        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNotificaciones_reloj = CType(o, dNotificaciones_reloj)
        Dim sql As String = "DELETE FROM notificaciones WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dNotificaciones_reloj
        Dim obj As dNotificaciones_reloj = CType(o, dNotificaciones_reloj)
        Dim l As New dNotificaciones_reloj
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
                    Dim l As New dNotificaciones_reloj
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
                    Dim l As New dNotificaciones_reloj
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
                    Dim l As New dNotificaciones_reloj
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
                    Dim l As New dNotificaciones_reloj
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
    Public Function listarsemana(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT id, fecha, idusuario, fechaevento, detalle FROM notificaciones WHERE fechaevento BETWEEN '" & desde & "' and '" & hasta & "' ORDER BY  fechaevento DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dNotificaciones_reloj
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
    Public Function listarPorFiltros(ByVal desde As String, ByVal hasta As String, ByVal id As Integer) As ArrayList
        Dim idQuery As String
        If id > 0 Then
            idQuery = " idusuario = '" & id & "'"
        Else
            idQuery = " 1 = 1 "
        End If

        Dim sql As String = "SELECT id, fecha, idusuario, fechaevento, detalle FROM notificaciones WHERE fechaevento BETWEEN '" & desde & "' and '" & hasta & "' and " + idQuery + "ORDER BY fechaevento DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dNotificaciones_reloj
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

