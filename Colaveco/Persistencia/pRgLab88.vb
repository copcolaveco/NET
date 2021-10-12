Public Class pRgLab88
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRgLab88 = CType(o, dRgLab88)
        Dim sql As String = "INSERT INTO RgLab88 (id, fecha, hora, ficha, muestra, crioscopo, delta, operador,  eliminado, observaciones) VALUES (" & obj.ID & ", '" & obj.FECHA & "','" & obj.HORA & "'," & obj.FICHA & ",'" & obj.MUESTRA & "'," & obj.CRIOSCOPO & "," & obj.DELTA & "," & obj.OPERADOR & "," & obj.ELIMINADO & ",'" & obj.OBSERVACIONES & "' )"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'RgLab88', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRgLab88 = CType(o, dRgLab88)
        Dim sql As String = "UPDATE RgLab88 SET fecha ='" & obj.FECHA & "',hora ='" & obj.HORA & "',ficha = '" & obj.FICHA & "',muestra = '" & obj.MUESTRA & "',crioscopo = " & obj.CRIOSCOPO & ",delta = " & obj.DELTA & ",operador = " & obj.OPERADOR & ",eliminado = " & obj.ELIMINADO & ",observaciones = '" & obj.OBSERVACIONES & "' WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'RgLab88', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRgLab88 = CType(o, dRgLab88)
        Dim sql As String = "DELETE FROM RgLab88 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'RgLab88', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function

    Public Function buscar(ByVal o As Object) As dRgLab88
        Dim obj As dRgLab88 = CType(o, dRgLab88)
        Dim c As New dRgLab88
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, hora, ficha, muestra, crioscopo, delta, operador,  eliminado, observaciones FROM RgLab88 WHERE id = " & obj.ID)

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FECHA = CType(unaFila.Item(1), String)
                c.HORA = CType(unaFila.Item(2), String)
                c.FICHA = CType(unaFila.Item(3), Long)
                c.MUESTRA = CType(unaFila.Item(4), String)
                c.CRIOSCOPO = CType(unaFila.Item(5), Double)
                c.DELTA = CType(unaFila.Item(6), Double)
                c.OPERADOR = CType(unaFila.Item(7), Integer)
                c.ELIMINADO = CType(unaFila.Item(8), Integer)
                c.OBSERVACIONES = CType(unaFila.Item(9), String)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxfichaxmuestra(ByVal o As Object) As dRgLab88
        Dim obj As dRgLab88 = CType(o, dRgLab88)
        Dim c As New dRgLab88
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, hora, ficha, muestra, crioscopo, delta, operador,  eliminado, observaciones FROM RgLab88 WHERE ficha = " & obj.FICHA & " AND muestra = '" & obj.MUESTRA & "'")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FECHA = CType(unaFila.Item(1), String)
                c.HORA = CType(unaFila.Item(2), String)
                c.FICHA = CType(unaFila.Item(3), Long)
                c.MUESTRA = CType(unaFila.Item(4), String)
                c.CRIOSCOPO = CType(unaFila.Item(5), Double)
                c.DELTA = CType(unaFila.Item(6), Double)
                c.OPERADOR = CType(unaFila.Item(7), Integer)
                c.ELIMINADO = CType(unaFila.Item(8), Integer)
                c.OBSERVACIONES = CType(unaFila.Item(9), String)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, hora, ficha, muestra, crioscopo, delta, operador,  eliminado, observaciones FROM RgLab88 order by fecha asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dRgLab88
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHA = CType(unaFila.Item(1), String)
                    c.HORA = CType(unaFila.Item(2), String)
                    c.FICHA = CType(unaFila.Item(3), Long)
                    c.MUESTRA = CType(unaFila.Item(4), String)
                    c.CRIOSCOPO = CType(unaFila.Item(5), Double)
                    c.DELTA = CType(unaFila.Item(6), Double)
                    c.OPERADOR = CType(unaFila.Item(7), Integer)
                    c.ELIMINADO = CType(unaFila.Item(8), Integer)
                    c.OBSERVACIONES = CType(unaFila.Item(9), String)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
