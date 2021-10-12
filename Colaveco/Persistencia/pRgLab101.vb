Public Class pRgLab101
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRgLab101 = CType(o, dRgLab101)
        Dim sql As String = "INSERT INTO rglab101 (id, fecha, hora, equipo, ficha, cantidad, idtipoinforme, operador, observaciones) VALUES (" & obj.ID & ", '" & obj.FECHA & "','" & obj.HORA & "','" & obj.EQUIPO & "'," & obj.FICHA & "," & obj.CANTIDAD & "," & obj.IDTIPOINFORME & "," & obj.OPERADOR & ",'" & obj.OBSERVACIONES & "' )"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'rglab101', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRgLab101 = CType(o, dRgLab101)
        Dim sql As String = "UPDATE rglab101 SET fecha ='" & obj.FECHA & "',hora ='" & obj.HORA & "',equipo ='" & obj.EQUIPO & "',ficha = '" & obj.FICHA & "',cantidad = " & obj.CANTIDAD & ",idtipoinforme = " & obj.IDTIPOINFORME & ",operador = " & obj.OPERADOR & ", observaciones = '" & obj.OBSERVACIONES & "' WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'rglab101', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRgLab101 = CType(o, dRgLab101)
        Dim sql As String = "DELETE FROM rglab101 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'rglab101', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function

    Public Function buscar(ByVal o As Object) As dRgLab101
        Dim obj As dRgLab101 = CType(o, dRgLab101)
        Dim c As New dRgLab101
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, hora, equipo, ficha, cantidad, idtipoinforme, operador, observaciones FROM rglab101 WHERE id = " & obj.ID)

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FECHA = CType(unaFila.Item(1), String)
                c.HORA = CType(unaFila.Item(2), String)
                c.EQUIPO = CType(unaFila.Item(3), String)
                c.FICHA = CType(unaFila.Item(4), Long)
                c.CANTIDAD = CType(unaFila.Item(5), Integer)
                c.IDTIPOINFORME = CType(unaFila.Item(6), Integer)
                c.OPERADOR = CType(unaFila.Item(7), Integer)
                c.OBSERVACIONES = CType(unaFila.Item(8), String)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, hora, equipo, ficha, cantidad, idtipoinforme, operador, observaciones FROM rglab101 order by fecha desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dRgLab101
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHA = CType(unaFila.Item(1), String)
                    c.HORA = CType(unaFila.Item(2), String)
                    c.EQUIPO = CType(unaFila.Item(3), String)
                    c.FICHA = CType(unaFila.Item(4), Long)
                    c.CANTIDAD = CType(unaFila.Item(5), Integer)
                    c.IDTIPOINFORME = CType(unaFila.Item(6), Integer)
                    c.OPERADOR = CType(unaFila.Item(7), Integer)
                    c.OBSERVACIONES = CType(unaFila.Item(8), String)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
