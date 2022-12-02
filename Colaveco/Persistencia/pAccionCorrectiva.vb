Public Class pAccionCorrectiva
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAccionCorrectiva = CType(o, dAccionCorrectiva)
        Dim sql As String = "INSERT INTO accion_correctiva (id, numero, causa, accion, plan, plazo, responsable, criterios, eficaz, fecha_evaluacion, estado) VALUES (" & obj.ID & "," & obj.NUMERO & ",'" & obj.CAUSA & "', '" & obj.ACCION & "'," & obj.PLAN & ",'" & obj.PLAZO & "'," & obj.RESPONSABLE & ",'" & obj.CRITERIOS & "','" & obj.EFICAZ & "','" & obj.FECHAEVALUACION & "'," & obj.ESTADO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'accion_correctiva', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAccionCorrectiva = CType(o, dAccionCorrectiva)
        Dim sql As String = "UPDATE accion_correctiva SET numero=" & obj.NUMERO & ", causa='" & obj.CAUSA & "', accion = '" & obj.ACCION & "', plan = " & obj.PLAN & ", plazo = '" & obj.PLAZO & "', responsable = " & obj.RESPONSABLE & ", criterios = '" & obj.CRITERIOS & "',eficaz = '" & obj.EFICAZ & "', fecha_evaluacion = '" & obj.FECHAEVALUACION & "', estado = " & obj.ESTADO & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'accion_correctiva', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAccionCorrectiva = CType(o, dAccionCorrectiva)
        Dim sql As String = "DELETE FROM accion_correctiva WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'accion_correctiva', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dAccionCorrectiva
        Dim obj As dAccionCorrectiva = CType(o, dAccionCorrectiva)
        Dim r As New dAccionCorrectiva
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, numero, ifnull(causa,''), ifnull(accion,''), plan, plazo, responsable, ifnull(criterios,''), ifnull(eficaz,''), fecha_evaluacion, estado FROM accion_correctiva WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                r.ID = CType(unaFila.Item(0), Long)
                r.NUMERO = CType(unaFila.Item(1), Long)
                r.CAUSA = CType(unaFila.Item(2), String)
                r.ACCION = CType(unaFila.Item(3), String)
                r.PLAN = CType(unaFila.Item(4), Integer)
                r.PLAZO = CType(unaFila.Item(5), String)
                r.RESPONSABLE = CType(unaFila.Item(6), Integer)
                r.CRITERIOS = CType(unaFila.Item(7), String)
                r.EFICAZ = CType(unaFila.Item(8), String)
                r.FECHAEVALUACION = CType(unaFila.Item(9), String)
                r.ESTADO = CType(unaFila.Item(10), Integer)
                Return r
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, numero, ifnull(causa,''), ifnull(accion,''), plan, plazo, responsable, ifnull(criterios,''), ifnull(eficaz,''), fecha_evaluacion, estado FROM accion_correctiva order by numero desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim r As New dAccionCorrectiva
                    r.ID = CType(unaFila.Item(0), Long)
                    r.NUMERO = CType(unaFila.Item(1), Long)
                    r.CAUSA = CType(unaFila.Item(2), String)
                    r.ACCION = CType(unaFila.Item(3), String)
                    r.PLAN = CType(unaFila.Item(4), Integer)
                    r.PLAZO = CType(unaFila.Item(5), String)
                    r.RESPONSABLE = CType(unaFila.Item(6), Integer)
                    r.CRITERIOS = CType(unaFila.Item(7), String)
                    r.EFICAZ = CType(unaFila.Item(8), String)
                    r.FECHAEVALUACION = CType(unaFila.Item(9), String)
                    r.ESTADO = CType(unaFila.Item(10), Integer)
                    Lista.Add(r)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxnum(ByVal n As Long) As ArrayList
        Dim sql As String = "SELECT id, numero, ifnull(causa,''), ifnull(accion,''), plan, plazo, responsable, ifnull(criterios,''), ifnull(eficaz,''), fecha_evaluacion, estado FROM accion_correctiva WHERE numero = " & n & " order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim r As New dAccionCorrectiva
                    r.ID = CType(unaFila.Item(0), Long)
                    r.NUMERO = CType(unaFila.Item(1), Long)
                    r.CAUSA = CType(unaFila.Item(2), String)
                    r.ACCION = CType(unaFila.Item(3), String)
                    r.PLAN = CType(unaFila.Item(4), Integer)
                    r.PLAZO = CType(unaFila.Item(5), String)
                    r.RESPONSABLE = CType(unaFila.Item(6), Integer)
                    r.CRITERIOS = CType(unaFila.Item(7), String)
                    r.EFICAZ = CType(unaFila.Item(8), String)
                    r.FECHAEVALUACION = CType(unaFila.Item(9), String)
                    r.ESTADO = CType(unaFila.Item(10), Integer)
                    Lista.Add(r)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
