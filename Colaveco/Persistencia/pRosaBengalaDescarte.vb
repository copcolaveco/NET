Public Class pRosaBengalaDescarte
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRosaBengalaDescarte = CType(o, dRosaBengalaDescarte)
        Dim sql As String = "INSERT INTO rosabengala_descarte (id, ficha, fecha, descartada, fechad, marcada, fecham) VALUES (" & obj.ID & "," & obj.FICHA & ", '" & obj.FECHA & "'," & obj.DESCARTADA & ", '" & obj.FECHAD & "'," & obj.MARCADA & ", '" & obj.FECHAM & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'rosabengala_descarte', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRosaBengalaDescarte = CType(o, dRosaBengalaDescarte)
        Dim sql As String = "UPDATE rosabengala_descarte SET ficha = " & obj.FICHA & ", fecha = '" & obj.FECHA & "',descartada= " & obj.DESCARTADA & ", fechad = '" & obj.FECHAD & "',marcada= " & obj.MARCADA & ", fecham = '" & obj.FECHAM & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'rosabengala_descarte', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function descartar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRosaBengalaDescarte = CType(o, dRosaBengalaDescarte)
        Dim sql As String = "UPDATE rosabengala_descarte SET descartada= 1, fechad='" & obj.FECHAD & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'rosabengala_descarte', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRosaBengalaDescarte = CType(o, dRosaBengalaDescarte)
        Dim sql As String = "UPDATE rosabengala_descarte SET marcada= 1, fecham = '" & obj.FECHAM & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'rosabengala_descarte', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRosaBengalaDescarte = CType(o, dRosaBengalaDescarte)
        Dim sql As String = "DELETE FROM rosabengala_descarte WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'rosabengala_descarte', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dRosaBengalaDescarte
        Dim obj As dRosaBengalaDescarte = CType(o, dRosaBengalaDescarte)
        Dim l As New dRosaBengalaDescarte
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, fecha, descartada, fechad, marcada, fecham FROM rosabengala_descarte WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Long)
                l.FICHA = CType(unaFila.Item(1), Long)
                l.FECHA = CType(unaFila.Item(2), String)
                l.DESCARTADA = CType(unaFila.Item(3), Integer)
                l.FECHAD = CType(unaFila.Item(4), String)
                l.MARCADA = CType(unaFila.Item(5), Integer)
                l.FECHAM = CType(unaFila.Item(6), String)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, fecha, descartada , fechad, marcada, fecham FROM rosabengala_descarte"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dRosaBengalaDescarte
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FICHA = CType(unaFila.Item(1), Long)
                    l.FECHA = CType(unaFila.Item(2), String)
                    l.DESCARTADA = CType(unaFila.Item(3), Integer)
                    l.FECHAD = CType(unaFila.Item(4), String)
                    l.MARCADA = CType(unaFila.Item(5), Integer)
                    l.FECHAM = CType(unaFila.Item(6), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsinmarcar() As ArrayList
        Dim sql As String = "SELECT id, ficha, fecha, descartada , fechad, marcada, fecham FROM rosabengala_descarte WHERE  marcada = 0"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dRosaBengalaDescarte
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FICHA = CType(unaFila.Item(1), Long)
                    l.FECHA = CType(unaFila.Item(2), String)
                    l.DESCARTADA = CType(unaFila.Item(3), Integer)
                    l.FECHAD = CType(unaFila.Item(4), String)
                    l.MARCADA = CType(unaFila.Item(5), Integer)
                    l.FECHAM = CType(unaFila.Item(6), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsindescartar() As ArrayList
        Dim sql As String = "SELECT id, ficha, fecha, descartada , fechad, marcada, fecham FROM rosabengala_descarte WHERE  descartada = 0"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dRosaBengalaDescarte
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FICHA = CType(unaFila.Item(1), Long)
                    l.FECHA = CType(unaFila.Item(2), String)
                    l.DESCARTADA = CType(unaFila.Item(3), Integer)
                    l.FECHAD = CType(unaFila.Item(4), String)
                    l.MARCADA = CType(unaFila.Item(5), Integer)
                    l.FECHAM = CType(unaFila.Item(6), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
