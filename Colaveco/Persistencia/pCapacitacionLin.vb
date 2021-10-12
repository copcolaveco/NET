Public Class pCapacitacionLin
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCapacitacionLin = CType(o, dCapacitacionLin)
        Dim sql As String = "INSERT INTO capacitacion_lin (id, idcab,area, tipo, nombre, descripcion, usuario, desde,hasta, horas, evaluacion1, evaluacion2) VALUES (" & obj.ID & ", " & obj.IDCAB & ", " & obj.AREA & ", " & obj.TIPO & ", '" & obj.NOMBRE & "','" & obj.DESCRIPCION & "'," & obj.IDUSUARIO & ", '" & obj.DESDE & "', '" & obj.HASTA & "', '" & obj.HORAS & "', " & obj.EVALUACION1 & ", " & obj.EVALUACION2 & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'capacitacion_lin', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCapacitacionLin = CType(o, dCapacitacionLin)
        Dim sql As String = "UPDATE capacitacion_lin SET idcab= " & obj.IDCAB & ",area= " & obj.AREA & ", tipo= " & obj.TIPO & ",nombre= '" & obj.NOMBRE & "',descripcion= '" & obj.DESCRIPCION & "',usuario=" & obj.IDUSUARIO & ",desde= '" & obj.DESDE & "',hasta= '" & obj.HASTA & "',horas= '" & obj.HORAS & "',evaluacion1= " & obj.EVALUACION1 & ",evaluacion2= " & obj.EVALUACION2 & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'capacitacion_lin', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCapacitacionLin = CType(o, dCapacitacionLin)
        Dim sql As String = "DELETE FROM capacitacion_lin WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'capacitacion_lin', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dCapacitacionLin
        Dim obj As dCapacitacionLin = CType(o, dCapacitacionLin)
        Dim l As New dCapacitacionLin
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idcab, area, tipo, ifnull(nombre,''),ifnull(descripcion,''), usuario, desde, hasta, horas, evaluacion1, evaluacion2 FROM capacitacion_lin WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Long)
                l.IDCAB = CType(unaFila.Item(1), Long)
                l.AREA = CType(unaFila.Item(2), Integer)
                l.TIPO = CType(unaFila.Item(3), Integer)
                l.NOMBRE = CType(unaFila.Item(4), String)
                l.DESCRIPCION = CType(unaFila.Item(5), String)
                l.IDUSUARIO = CType(unaFila.Item(6), Integer)
                l.DESDE = CType(unaFila.Item(7), String)
                l.HASTA = CType(unaFila.Item(8), String)
                l.HORAS = CType(unaFila.Item(9), String)
                l.EVALUACION1 = CType(unaFila.Item(10), Integer)
                l.EVALUACION2 = CType(unaFila.Item(11), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, idcab, area, tipo,ifnull(nombre,''), ifnull(descripcion,''),usuario, desde, hasta, horas, evaluacion1, evaluacion2 FROM capacitacion_lin order by desde desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dCapacitacionLin
                    l.ID = CType(unaFila.Item(0), Long)
                    l.IDCAB = CType(unaFila.Item(1), Long)
                    l.AREA = CType(unaFila.Item(2), Integer)
                    l.TIPO = CType(unaFila.Item(3), Integer)
                    l.NOMBRE = CType(unaFila.Item(4), String)
                    l.DESCRIPCION = CType(unaFila.Item(5), String)
                    l.IDUSUARIO = CType(unaFila.Item(6), Integer)
                    l.DESDE = CType(unaFila.Item(7), String)
                    l.HASTA = CType(unaFila.Item(8), String)
                    l.HORAS = CType(unaFila.Item(9), String)
                    l.EVALUACION1 = CType(unaFila.Item(10), Integer)
                    l.EVALUACION2 = CType(unaFila.Item(11), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT id, idcab, area, tipo,ifnull(nombre,''), ifnull(descripcion,''),usuario, desde, hasta, horas, evaluacion1, evaluacion2 FROM capacitacion_lin where desde >='" & desde & "' and hasta <='" & hasta & "'"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dCapacitacionLin
                    l.ID = CType(unaFila.Item(0), Long)
                    l.IDCAB = CType(unaFila.Item(1), Long)
                    l.AREA = CType(unaFila.Item(2), Integer)
                    l.TIPO = CType(unaFila.Item(3), Integer)
                    l.NOMBRE = CType(unaFila.Item(4), String)
                    l.DESCRIPCION = CType(unaFila.Item(5), String)
                    l.IDUSUARIO = CType(unaFila.Item(6), Integer)
                    l.DESDE = CType(unaFila.Item(7), String)
                    l.HASTA = CType(unaFila.Item(8), String)
                    l.HORAS = CType(unaFila.Item(9), String)
                    l.EVALUACION1 = CType(unaFila.Item(10), Integer)
                    l.EVALUACION2 = CType(unaFila.Item(11), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfechaxarea(ByVal desde As String, ByVal hasta As String, ByVal area As Integer) As ArrayList
        Dim sql As String = "SELECT id, idcab, area, tipo,ifnull(nombre,''), ifnull(descripcion,''),usuario, desde, hasta, horas, evaluacion1, evaluacion2 FROM capacitacion_lin where desde >='" & desde & "' and hasta <='" & hasta & "' AND area = " & area & ""
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dCapacitacionLin
                    l.ID = CType(unaFila.Item(0), Long)
                    l.IDCAB = CType(unaFila.Item(1), Long)
                    l.AREA = CType(unaFila.Item(2), Integer)
                    l.TIPO = CType(unaFila.Item(3), Integer)
                    l.NOMBRE = CType(unaFila.Item(4), String)
                    l.DESCRIPCION = CType(unaFila.Item(5), String)
                    l.IDUSUARIO = CType(unaFila.Item(6), Integer)
                    l.DESDE = CType(unaFila.Item(7), String)
                    l.HASTA = CType(unaFila.Item(8), String)
                    l.HORAS = CType(unaFila.Item(9), String)
                    l.EVALUACION1 = CType(unaFila.Item(10), Integer)
                    l.EVALUACION2 = CType(unaFila.Item(11), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfechaxusuario(ByVal desde As String, ByVal hasta As String, ByVal user As Integer) As ArrayList
        Dim sql As String = "SELECT id, idcab, area, tipo,ifnull(nombre,''), ifnull(descripcion,''),usuario, desde, hasta, horas, evaluacion1, evaluacion2 FROM capacitacion_lin where desde >='" & desde & "' and hasta <='" & hasta & "' AND usuario = " & user & ""
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dCapacitacionLin
                    l.ID = CType(unaFila.Item(0), Long)
                    l.IDCAB = CType(unaFila.Item(1), Long)
                    l.AREA = CType(unaFila.Item(2), Integer)
                    l.TIPO = CType(unaFila.Item(3), Integer)
                    l.NOMBRE = CType(unaFila.Item(4), String)
                    l.DESCRIPCION = CType(unaFila.Item(5), String)
                    l.IDUSUARIO = CType(unaFila.Item(6), Integer)
                    l.DESDE = CType(unaFila.Item(7), String)
                    l.HASTA = CType(unaFila.Item(8), String)
                    l.HORAS = CType(unaFila.Item(9), String)
                    l.EVALUACION1 = CType(unaFila.Item(10), Integer)
                    l.EVALUACION2 = CType(unaFila.Item(11), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxusuario(ByVal user As Integer) As ArrayList
        Dim sql As String = "SELECT id, idcab, area, tipo,ifnull(nombre,''), ifnull(descripcion,''),usuario, desde, hasta, horas, evaluacion1, evaluacion2 FROM capacitacion_lin WHERE usuario = " & user & " order by desde desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dCapacitacionLin
                    l.ID = CType(unaFila.Item(0), Long)
                    l.IDCAB = CType(unaFila.Item(1), Long)
                    l.AREA = CType(unaFila.Item(2), Integer)
                    l.TIPO = CType(unaFila.Item(3), Integer)
                    l.NOMBRE = CType(unaFila.Item(4), String)
                    l.DESCRIPCION = CType(unaFila.Item(5), String)
                    l.IDUSUARIO = CType(unaFila.Item(6), Integer)
                    l.DESDE = CType(unaFila.Item(7), String)
                    l.HASTA = CType(unaFila.Item(8), String)
                    l.HORAS = CType(unaFila.Item(9), String)
                    l.EVALUACION1 = CType(unaFila.Item(10), Integer)
                    l.EVALUACION2 = CType(unaFila.Item(11), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
