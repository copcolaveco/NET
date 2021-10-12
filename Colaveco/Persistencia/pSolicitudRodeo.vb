Public Class pSolicitudRodeo
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudRodeo = CType(o, dSolicitudRodeo)
        Dim sql As String = "INSERT INTO solicitud_rodeo (id, mastitis, ficha, rodeo) VALUES (" & obj.ID & ", '" & obj.MASTITIS & "', " & obj.FICHA & ", " & obj.RODEO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitud_rodeo', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudRodeo = CType(o, dSolicitudRodeo)
        Dim sql As String = "UPDATE solicitud_rodeo SET mastitis = '" & obj.MASTITIS & "', ficha = " & obj.FICHA & ", rodeo = " & obj.RODEO & " WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitud_rodeo', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudRodeo = CType(o, dSolicitudRodeo)
        Dim sql As String = "DELETE FROM solicitud_rodeo WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitud_rodeo', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dSolicitudRodeo
        Dim obj As dSolicitudRodeo = CType(o, dSolicitudRodeo)
        Dim l As New dSolicitudRodeo
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, mastitis, ficha, rodeo FROM solicitud_rodeo WHERE ficha = " & obj.FICHA & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Long)
                l.MASTITIS = CType(unaFila.Item(1), String)
                l.FICHA = CType(unaFila.Item(2), Long)
                l.RODEO = CType(unaFila.Item(3), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, mastitis, ficha, rodeo FROM solicitud_rodeo order by ficha asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dSolicitudRodeo
                    l.ID = CType(unaFila.Item(0), Long)
                    l.MASTITIS = CType(unaFila.Item(1), String)
                    l.FICHA = CType(unaFila.Item(2), Long)
                    l.RODEO = CType(unaFila.Item(3), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
  
End Class
