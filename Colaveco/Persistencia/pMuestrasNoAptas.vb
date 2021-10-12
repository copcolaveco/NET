Public Class pMuestrasNoAptas
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMuestrasNoAptas = CType(o, dMuestrasNoAptas)
        Dim sql As String = "INSERT INTO muestrasnoaptas (id, ficha, motivo, cantidad) VALUES (" & obj.ID & ", " & obj.FICHA & ", " & obj.MOTIVO & ", " & obj.CANTIDAD & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'muestrasnoaptas', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMuestrasNoAptas = CType(o, dMuestrasNoAptas)
        Dim sql As String = "UPDATE muestrasnoaptas SET ficha = " & obj.FICHA & ", motivo = " & obj.MOTIVO & ", cantidad= " & obj.CANTIDAD & " WHERE id = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'muestrasnoaptas', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMuestrasNoAptas = CType(o, dMuestrasNoAptas)
        Dim sql As String = "DELETE FROM muestrasnoaptas WHERE id = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'muestrasnoaptas', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dMuestrasNoAptas
        Dim obj As dMuestrasNoAptas = CType(o, dMuestrasNoAptas)
        Dim l As New dMuestrasNoAptas
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, motivo, cantidad FROM muestrasnoaptas WHERE id = " & obj.ID)

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Long)
                l.FICHA = CType(unaFila.Item(1), Long)
                l.MOTIVO = CType(unaFila.Item(2), Integer)
                l.CANTIDAD = CType(unaFila.Item(3), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarporficha(ByVal o As Object) As dMuestrasNoAptas
        Dim obj As dMuestrasNoAptas = CType(o, dMuestrasNoAptas)
        Dim l As New dMuestrasNoAptas
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, motivo, cantidad FROM muestrasnoaptas WHERE ficha = " & obj.FICHA & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Long)
                l.FICHA = CType(unaFila.Item(1), Long)
                l.MOTIVO = CType(unaFila.Item(2), Integer)
                l.CANTIDAD = CType(unaFila.Item(3), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, motivo, cantidad FROM muestrasnoaptas"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dMuestrasNoAptas
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FICHA = CType(unaFila.Item(1), Long)
                    l.MOTIVO = CType(unaFila.Item(2), Integer)
                    l.CANTIDAD = CType(unaFila.Item(3), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporficha(ByVal texto As Long) As ArrayList
        Dim sql As String = "SELECT id, ficha, motivo, cantidad FROM muestrasnoaptas where ficha = " & texto & ""
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dMuestrasNoAptas
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FICHA = CType(unaFila.Item(1), Long)
                    l.MOTIVO = CType(unaFila.Item(2), Integer)
                    l.CANTIDAD = CType(unaFila.Item(3), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
