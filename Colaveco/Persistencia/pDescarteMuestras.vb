Public Class pDescarteMuestras
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dDescarteMuestras = CType(o, dDescarteMuestras)
        Dim sql As String = "INSERT INTO descartemuestras (id, fecha, ficha, idproductor, idmuestra, cantidad, idtipoinforme, idmotivodescarte, valor, idinforetorno, idautorizacion, observaciones, operador, eliminado) VALUES (" & obj.ID & ", '" & obj.FECHA & "'," & obj.FICHA & "," & obj.IDPRODUCTOR & ", " & obj.IDMUESTRA & "," & obj.CANTIDAD & "," & obj.IDTIPOINFORME & "," & obj.IDMOTIVODESCARTE & "," & obj.VALOR & "," & obj.IDINFORETORNO & "," & obj.IDAUTORIZACION & ", '" & obj.OBSERVACIONES & "', " & obj.OPERADOR & ", " & obj.ELIMINADO & ")"
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'descartemuestras', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dDescarteMuestras = CType(o, dDescarteMuestras)
        Dim sql As String = "UPDATE descartemuestras SET fecha ='" & obj.FECHA & "', ficha =" & obj.FICHA & ",idproductor =" & obj.IDPRODUCTOR & ",idmuestra =" & obj.IDMUESTRA & ",cantidad =" & obj.CANTIDAD & ",idtipoinforme =" & obj.IDTIPOINFORME & ", idmotivodescarte =" & obj.IDMOTIVODESCARTE & ", valor=" & obj.VALOR & ", idinforetorno=" & obj.IDINFORETORNO & ", idautorizacion=" & obj.IDAUTORIZACION & ", observaciones='" & obj.OBSERVACIONES & "', operador=" & obj.OPERADOR & ",eliminado=" & obj.ELIMINADO & " WHERE ID = " & obj.ID
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'descartemuestras', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dDescarteMuestras = CType(o, dDescarteMuestras)
        'Dim sql As String = "DELETE FROM descartemuestras WHERE ID = " & obj.ID
        Dim sql As String = "UPDATE descartemuestras SET eliminado =1 WHERE id = " & obj.ID
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'descartemuestras', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dDescarteMuestras
        Dim obj As dDescarteMuestras = CType(o, dDescarteMuestras)
        Dim s As New dDescarteMuestras
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, ficha, idproductor, idmuestra, cantidad, idtipoinforme, idmotivodescarte, valor, idinforetorno, idautorizacion, observaciones, operador, eliminado FROM descartemuestras WHERE id = " & obj.ID & "")
            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                s.ID = CType(unaFila.Item(0), Long)
                s.FECHA = CType(unaFila.Item(1), String)
                s.FICHA = CType(unaFila.Item(2), Long)
                s.IDPRODUCTOR = CType(unaFila.Item(3), Long)
                s.IDMUESTRA = CType(unaFila.Item(4), Integer)
                s.CANTIDAD = CType(unaFila.Item(5), Double)
                s.IDTIPOINFORME = CType(unaFila.Item(6), Integer)
                s.IDMOTIVODESCARTE = CType(unaFila.Item(7), Integer)
                s.VALOR = CType(unaFila.Item(8), Double)
                s.IDINFORETORNO = CType(unaFila.Item(9), Integer)
                s.IDAUTORIZACION = CType(unaFila.Item(10), Integer)
                s.OBSERVACIONES = CType(unaFila.Item(11), String)
                s.OPERADOR = CType(unaFila.Item(12), Integer)
                s.ELIMINADO = CType(unaFila.Item(13), Integer)
                Return s
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxficha(ByVal o As Object) As dDescarteMuestras
        Dim obj As dDescarteMuestras = CType(o, dDescarteMuestras)
        Dim s As New dDescarteMuestras
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, ficha, idproductor, idmuestra, cantidad, idtipoinforme, idmotivodescarte, valor, idinforetorno, idautorizacion, observaciones, operador, eliminado FROM descartemuestras WHERE ficha = " & obj.FICHA & "")
            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                s.ID = CType(unaFila.Item(0), Long)
                s.FECHA = CType(unaFila.Item(1), String)
                s.FICHA = CType(unaFila.Item(2), Long)
                s.IDPRODUCTOR = CType(unaFila.Item(3), Long)
                s.IDMUESTRA = CType(unaFila.Item(4), Integer)
                s.CANTIDAD = CType(unaFila.Item(5), Double)
                s.IDTIPOINFORME = CType(unaFila.Item(6), Integer)
                s.IDMOTIVODESCARTE = CType(unaFila.Item(7), Integer)
                s.VALOR = CType(unaFila.Item(8), Double)
                s.IDINFORETORNO = CType(unaFila.Item(9), Integer)
                s.IDAUTORIZACION = CType(unaFila.Item(10), Integer)
                s.OBSERVACIONES = CType(unaFila.Item(11), String)
                s.OPERADOR = CType(unaFila.Item(12), Integer)
                s.ELIMINADO = CType(unaFila.Item(13), Integer)
                Return s
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, ficha, idproductor, idmuestra, cantidad, idtipoinforme, idmotivodescarte, valor, idinforetorno, idautorizacion, observaciones, operador, eliminado FROM descartemuestras"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dDescarteMuestras
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHA = CType(unaFila.Item(1), String)
                    s.FICHA = CType(unaFila.Item(2), Long)
                    s.IDPRODUCTOR = CType(unaFila.Item(3), Long)
                    s.IDMUESTRA = CType(unaFila.Item(4), Integer)
                    s.CANTIDAD = CType(unaFila.Item(5), Double)
                    s.IDTIPOINFORME = CType(unaFila.Item(6), Integer)
                    s.IDMOTIVODESCARTE = CType(unaFila.Item(7), Integer)
                    s.VALOR = CType(unaFila.Item(8), Double)
                    s.IDINFORETORNO = CType(unaFila.Item(9), Integer)
                    s.IDAUTORIZACION = CType(unaFila.Item(10), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(11), String)
                    s.OPERADOR = CType(unaFila.Item(12), Integer)
                    s.ELIMINADO = CType(unaFila.Item(13), Integer)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado FROM descartemuestras where marca = 0 And eliminado = 0 and id = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dDescarteMuestras
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHA = CType(unaFila.Item(1), String)
                    s.FICHA = CType(unaFila.Item(2), Long)
                    s.IDPRODUCTOR = CType(unaFila.Item(3), Long)
                    s.IDMUESTRA = CType(unaFila.Item(4), Integer)
                    s.CANTIDAD = CType(unaFila.Item(5), Double)
                    s.IDTIPOINFORME = CType(unaFila.Item(6), Integer)
                    s.IDMOTIVODESCARTE = CType(unaFila.Item(7), Integer)
                    s.VALOR = CType(unaFila.Item(8), Double)
                    s.IDINFORETORNO = CType(unaFila.Item(9), Integer)
                    s.IDAUTORIZACION = CType(unaFila.Item(10), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(11), String)
                    s.OPERADOR = CType(unaFila.Item(12), Integer)
                    s.ELIMINADO = CType(unaFila.Item(13), Integer)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
   
    Public Function buscarultimoid(ByVal o As Object) As dDescarteMuestras
        Dim obj As dDescarteMuestras = CType(o, dDescarteMuestras)
        Dim s As New dDescarteMuestras
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado FROM descartemuestras where id = (SELECT MAX(id) FROM descartemuestras)")
            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                s.ID = CType(unaFila.Item(0), Long)
                s.ID = CType(unaFila.Item(0), Long)
                s.FECHA = CType(unaFila.Item(1), String)
                s.FICHA = CType(unaFila.Item(2), Long)
                s.IDPRODUCTOR = CType(unaFila.Item(3), Long)
                s.IDMUESTRA = CType(unaFila.Item(4), Integer)
                s.CANTIDAD = CType(unaFila.Item(5), Double)
                s.IDTIPOINFORME = CType(unaFila.Item(6), Integer)
                s.IDMOTIVODESCARTE = CType(unaFila.Item(7), Integer)
                s.VALOR = CType(unaFila.Item(8), Double)
                s.IDINFORETORNO = CType(unaFila.Item(9), Integer)
                s.IDAUTORIZACION = CType(unaFila.Item(10), Integer)
                s.OBSERVACIONES = CType(unaFila.Item(11), String)
                s.OPERADOR = CType(unaFila.Item(12), Integer)
                s.ELIMINADO = CType(unaFila.Item(13), Integer)
                Return s
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarultimoid() As ArrayList
        Dim sql As String = "SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado FROM descartemuestras where id = (SELECT MAX(id) FROM descartemuestras)"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dDescarteMuestras
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHA = CType(unaFila.Item(1), String)
                    s.FICHA = CType(unaFila.Item(2), Long)
                    s.IDPRODUCTOR = CType(unaFila.Item(3), Long)
                    s.IDMUESTRA = CType(unaFila.Item(4), Integer)
                    s.CANTIDAD = CType(unaFila.Item(5), Double)
                    s.IDTIPOINFORME = CType(unaFila.Item(6), Integer)
                    s.IDMOTIVODESCARTE = CType(unaFila.Item(7), Integer)
                    s.VALOR = CType(unaFila.Item(8), Double)
                    s.IDINFORETORNO = CType(unaFila.Item(9), Integer)
                    s.IDAUTORIZACION = CType(unaFila.Item(10), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(11), String)
                    s.OPERADOR = CType(unaFila.Item(12), Integer)
                    s.ELIMINADO = CType(unaFila.Item(13), Integer)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporproductor(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, fecha, ficha, idproductor, idmuestra, cantidad, idtipoinforme, idmotivodescarte, valor, idinforetorno, idautorizacion, observaciones, operador, eliminado FROM descartemuestras where idproductor = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dDescarteMuestras
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHA = CType(unaFila.Item(1), String)
                    s.FICHA = CType(unaFila.Item(2), Long)
                    s.IDPRODUCTOR = CType(unaFila.Item(3), Long)
                    s.IDMUESTRA = CType(unaFila.Item(4), Integer)
                    s.CANTIDAD = CType(unaFila.Item(5), Double)
                    s.IDTIPOINFORME = CType(unaFila.Item(6), Integer)
                    s.IDMOTIVODESCARTE = CType(unaFila.Item(7), Integer)
                    s.VALOR = CType(unaFila.Item(8), Double)
                    s.IDINFORETORNO = CType(unaFila.Item(9), Integer)
                    s.IDAUTORIZACION = CType(unaFila.Item(10), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(11), String)
                    s.OPERADOR = CType(unaFila.Item(12), Integer)
                    s.ELIMINADO = CType(unaFila.Item(13), Integer)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fecha, ficha, idproductor, idmuestra, cantidad, idtipoinforme, idmotivodescarte, valor, idinforetorno, idautorizacion, observaciones, operador, eliminado FROM descartemuestras where fecha BETWEEN '" & fechadesde & "' And '" & fechahasta & "'")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dDescarteMuestras
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHA = CType(unaFila.Item(1), String)
                    s.FICHA = CType(unaFila.Item(2), Long)
                    s.IDPRODUCTOR = CType(unaFila.Item(3), Long)
                    s.IDMUESTRA = CType(unaFila.Item(4), Integer)
                    s.CANTIDAD = CType(unaFila.Item(5), Double)
                    s.IDTIPOINFORME = CType(unaFila.Item(6), Integer)
                    s.IDMOTIVODESCARTE = CType(unaFila.Item(7), Integer)
                    s.VALOR = CType(unaFila.Item(8), Double)
                    s.IDINFORETORNO = CType(unaFila.Item(9), Integer)
                    s.IDAUTORIZACION = CType(unaFila.Item(10), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(11), String)
                    s.OPERADOR = CType(unaFila.Item(12), Integer)
                    s.ELIMINADO = CType(unaFila.Item(13), Integer)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichasagua() As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado FROM descartemuestras where marca = 0 And eliminado = 0 and idtipoinforme = 3")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dDescarteMuestras
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHA = CType(unaFila.Item(1), String)
                    s.FICHA = CType(unaFila.Item(2), Long)
                    s.IDPRODUCTOR = CType(unaFila.Item(3), Long)
                    s.IDMUESTRA = CType(unaFila.Item(4), Integer)
                    s.CANTIDAD = CType(unaFila.Item(5), Double)
                    s.IDTIPOINFORME = CType(unaFila.Item(6), Integer)
                    s.IDMOTIVODESCARTE = CType(unaFila.Item(7), Integer)
                    s.VALOR = CType(unaFila.Item(8), Double)
                    s.IDINFORETORNO = CType(unaFila.Item(9), Integer)
                    s.IDAUTORIZACION = CType(unaFila.Item(10), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(11), String)
                    s.OPERADOR = CType(unaFila.Item(12), Integer)
                    s.ELIMINADO = CType(unaFila.Item(13), Integer)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporficha(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, fecha, ficha, idproductor, idmuestra, cantidad, idtipoinforme, idmotivodescarte, valor, idinforetorno, idautorizacion, observaciones, operador, eliminado FROM descartemuestras where ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dDescarteMuestras
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHA = CType(unaFila.Item(1), String)
                    s.FICHA = CType(unaFila.Item(2), Long)
                    s.IDPRODUCTOR = CType(unaFila.Item(3), Long)
                    s.IDMUESTRA = CType(unaFila.Item(4), Integer)
                    s.CANTIDAD = CType(unaFila.Item(5), Double)
                    s.IDTIPOINFORME = CType(unaFila.Item(6), Integer)
                    s.IDMOTIVODESCARTE = CType(unaFila.Item(7), Integer)
                    s.VALOR = CType(unaFila.Item(8), Double)
                    s.IDINFORETORNO = CType(unaFila.Item(9), Integer)
                    s.IDAUTORIZACION = CType(unaFila.Item(10), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(11), String)
                    s.OPERADOR = CType(unaFila.Item(12), Integer)
                    s.ELIMINADO = CType(unaFila.Item(13), Integer)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
