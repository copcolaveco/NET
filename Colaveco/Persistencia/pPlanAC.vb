Public Class pPlanAC
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dPlanAC = CType(o, dPlanAC)
        Dim sql As String = "INSERT INTO ac_plan (id, id_ac, accion, responsable, efectuado, fecha) VALUES (" & obj.ID & "," & obj.IDAC & ", '" & obj.ACCION & "', " & obj.RESPONSABLE & ", " & obj.EFECTUADO & ",'" & obj.FECHA & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'ac_plan', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dPlanAC = CType(o, dPlanAC)
        Dim sql As String = "UPDATE ac_plan SET id_ac=" & obj.IDAC & ", accion = '" & obj.ACCION & "', responsable = " & obj.RESPONSABLE & ", efectuado = " & obj.EFECTUADO & ", fecha = '" & obj.FECHA & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'ac_plan', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dPlanAC = CType(o, dPlanAC)
        Dim sql As String = "DELETE FROM ac_plan WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'ac_plan', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dPlanAC
        Dim obj As dPlanAC = CType(o, dPlanAC)
        Dim r As New dPlanAC
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, id_ac, ifnull(accion,''), responsable, efectuado, fecha FROM ac_plan WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
              r.ID = CType(unaFila.Item(0), Long)
                r.IDAC = CType(unaFila.Item(1), Long)
                r.ACCION = CType(unaFila.Item(2), String)
                r.RESPONSABLE = CType(unaFila.Item(3), Integer)
                r.EFECTUADO = CType(unaFila.Item(4), Integer)
                r.FECHA = CType(unaFila.Item(5), String)
                Return r
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, id_ac, ifnull(accion,''), responsable, efectuado, fecha FROM ac_plan order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim r As New dPlanAC
                    r.ID = CType(unaFila.Item(0), Long)
                    r.IDAC = CType(unaFila.Item(1), Long)
                    r.ACCION = CType(unaFila.Item(2), String)
                    r.RESPONSABLE = CType(unaFila.Item(3), Integer)
                    r.EFECTUADO = CType(unaFila.Item(4), Integer)
                    r.FECHA = CType(unaFila.Item(5), String)
                    Lista.Add(r)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxidac(ByVal idac As Long) As ArrayList
        Dim sql As String = "SELECT id, id_ac, ifnull(accion,''), responsable, efectuado, fecha FROM ac_plan WHERE id_ac = " & idac & " order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim r As New dPlanAC
                    r.ID = CType(unaFila.Item(0), Long)
                    r.IDAC = CType(unaFila.Item(1), Long)
                    r.ACCION = CType(unaFila.Item(2), String)
                    r.RESPONSABLE = CType(unaFila.Item(3), Integer)
                    r.EFECTUADO = CType(unaFila.Item(4), Integer)
                    r.FECHA = CType(unaFila.Item(5), String)
                    Lista.Add(r)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
