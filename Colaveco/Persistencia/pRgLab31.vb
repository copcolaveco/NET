Public Class pRgLab31
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRgLab31 = CType(o, dRgLab31)
        Dim sql As String = "INSERT INTO rglab31 (id, fecha, hora, equipo, ficha, cantidad, idtipoinforme, operador, temperatura, humedad, eliminado, observaciones) VALUES (" & obj.ID & ", '" & obj.FECHA & "','" & obj.HORA & "','" & obj.EQUIPO & "'," & obj.FICHA & "," & obj.CANTIDAD & "," & obj.IDTIPOINFORME & "," & obj.OPERADOR & "," & obj.TEMPERATURA & "," & obj.HUMEDAD & "," & obj.ELIMINADO & ",'" & obj.OBSERVACIONES & "' )"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'rglab31', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRgLab31 = CType(o, dRgLab31)
        Dim sql As String = "UPDATE rglab31 SET fecha ='" & obj.FECHA & "',hora ='" & obj.HORA & "',equipo ='" & obj.EQUIPO & "',ficha = '" & obj.FICHA & "',cantidad = " & obj.CANTIDAD & ",idtipoinforme = " & obj.IDTIPOINFORME & ",operador = " & obj.OPERADOR & ",temperatura = " & obj.TEMPERATURA & ",humedad = " & obj.HUMEDAD & ",eliminado = " & obj.ELIMINADO & ",observaciones = '" & obj.OBSERVACIONES & "' WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'rglab31', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar2(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRgLab31 = CType(o, dRgLab31)
        Dim sql As String = "UPDATE rglab31 SET fecha ='" & obj.FECHA & "',hora ='" & obj.HORA & "',equipo ='" & obj.EQUIPO & "', cantidad = " & obj.CANTIDAD & ",idtipoinforme = " & obj.IDTIPOINFORME & ",operador = " & obj.OPERADOR & ",temperatura = " & obj.TEMPERATURA & ",humedad = " & obj.HUMEDAD & ",eliminado = " & obj.ELIMINADO & ",observaciones = '" & obj.OBSERVACIONES & "' WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'rglab31', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRgLab31 = CType(o, dRgLab31)
        Dim sql As String = "DELETE FROM rglab31 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'rglab31', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
   
    Public Function buscar(ByVal o As Object) As dRgLab31
        Dim obj As dRgLab31 = CType(o, dRgLab31)
        Dim c As New dRgLab31
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, hora, equipo, ficha, cantidad, idtipoinforme, operador, temperatura, humedad, eliminado, observaciones FROM rglab31 WHERE id = " & obj.ID)

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
                c.TEMPERATURA = CType(unaFila.Item(8), Double)
                c.HUMEDAD = CType(unaFila.Item(9), Double)
                c.ELIMINADO = CType(unaFila.Item(10), Integer)
                c.OBSERVACIONES = CType(unaFila.Item(11), String)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxficha(ByVal o As Object) As dRgLab31
        Dim obj As dRgLab31 = CType(o, dRgLab31)
        Dim c As New dRgLab31
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, hora, equipo, ficha, cantidad, idtipoinforme, operador, temperatura, humedad, eliminado, observaciones FROM rglab31 WHERE ficha = " & obj.FICHA)

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
                c.TEMPERATURA = CType(unaFila.Item(8), Double)
                c.HUMEDAD = CType(unaFila.Item(9), Double)
                c.ELIMINADO = CType(unaFila.Item(10), Integer)
                c.OBSERVACIONES = CType(unaFila.Item(11), String)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, hora, equipo, ficha, cantidad, idtipoinforme, operador, temperatura, humedad, eliminado, observaciones FROM rglab31 order by fecha desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dRgLab31
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHA = CType(unaFila.Item(1), String)
                    c.HORA = CType(unaFila.Item(2), String)
                    c.EQUIPO = CType(unaFila.Item(3), String)
                    c.FICHA = CType(unaFila.Item(4), Long)
                    c.CANTIDAD = CType(unaFila.Item(5), Integer)
                    c.IDTIPOINFORME = CType(unaFila.Item(6), Integer)
                    c.OPERADOR = CType(unaFila.Item(7), Integer)
                    c.TEMPERATURA = CType(unaFila.Item(8), Double)
                    c.HUMEDAD = CType(unaFila.Item(9), Double)
                    c.ELIMINADO = CType(unaFila.Item(10), Integer)
                    c.OBSERVACIONES = CType(unaFila.Item(11), String)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
