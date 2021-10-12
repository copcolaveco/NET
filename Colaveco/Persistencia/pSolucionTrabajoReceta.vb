Public Class pSolucionTrabajoReceta
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolucionTrabajoReceta = CType(o, dSolucionTrabajoReceta)
        Dim sql As String = "INSERT INTO solucion_trabajo_receta (id, idst, idproducto, cantidad, unidad) VALUES (" & obj.ID & ", " & obj.IDST & ", " & obj.IDPRODUCTO & ", " & obj.CANTIDAD & ", " & obj.UNIDAD & " )"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solucion_trabajo_receta', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolucionTrabajoReceta = CType(o, dSolucionTrabajoReceta)
        Dim sql As String = "UPDATE solucion_trabajo_receta SET idst =" & obj.IDST & ", idproducto =" & obj.IDPRODUCTO & ", cantidad =" & obj.CANTIDAD & ", unidad =" & obj.UNIDAD & " WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solucion_trabajo_receta', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolucionTrabajoReceta = CType(o, dSolucionTrabajoReceta)
        Dim sql As String = "DELETE FROM solucion_trabajo_receta WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solucion_trabajo_receta', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function

    Public Function buscar(ByVal o As Object) As dSolucionTrabajoReceta
        Dim obj As dSolucionTrabajoReceta = CType(o, dSolucionTrabajoReceta)
        Dim c As New dSolucionTrabajoReceta
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idst, idproducto, cantidad, unidad FROM solucion_trabajo_receta WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Integer)
                c.IDST = CType(unaFila.Item(1), Integer)
                c.IDPRODUCTO = CType(unaFila.Item(2), Integer)
                c.CANTIDAD = CType(unaFila.Item(3), Double)
                c.UNIDAD = CType(unaFila.Item(4), Integer)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, idst, idproducto, cantidad, unidad FROM solucion_trabajo_receta"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dSolucionTrabajoReceta
                    c.ID = CType(unaFila.Item(0), Integer)
                    c.IDST = CType(unaFila.Item(1), Integer)
                    c.IDPRODUCTO = CType(unaFila.Item(2), Integer)
                    c.CANTIDAD = CType(unaFila.Item(3), Double)
                    c.UNIDAD = CType(unaFila.Item(4), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxid(ByVal id As Integer) As ArrayList
        Dim sql As String = "SELECT id, idst, idproducto, cantidad, unidad FROM solucion_trabajo_receta WHERE idst = " & id & ""
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dSolucionTrabajoReceta
                    c.ID = CType(unaFila.Item(0), Integer)
                    c.IDST = CType(unaFila.Item(1), Integer)
                    c.IDPRODUCTO = CType(unaFila.Item(2), Integer)
                    c.CANTIDAD = CType(unaFila.Item(3), Double)
                    c.UNIDAD = CType(unaFila.Item(4), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
