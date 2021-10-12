Public Class pEstadisticaCalidad
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dEstadisticaCalidad = CType(o, dEstadisticaCalidad)
        Dim sql As String = "INSERT INTO estadistica_calidad (id, periodo, rb, rb_m, rc, rc_m, gr, gr_m, pr, pr_m, la, la_m, st, st_m, cr, cr_m, ur, ur_m) VALUES (" & obj.ID & ", '" & obj.PERIODO & "', " & obj.RB & ", " & obj.RB_M & ", " & obj.RC & ", " & obj.RC_M & ", " & obj.GR & ", " & obj.GR_M & ", " & obj.PR & ", " & obj.PR_M & ", " & obj.LA & ", " & obj.LA_M & ", " & obj.ST & ", " & obj.ST_M & ", " & obj.CR & ", " & obj.CR_M & ", " & obj.UR & ", " & obj.UR_M & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'estadisticas', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dEstadisticaCalidad = CType(o, dEstadisticaCalidad)
        Dim sql As String = "UPDATE estadistica_calidad SET periodo='" & obj.PERIODO & "',rb= " & obj.RB & ",rb_m= " & obj.RB_M & ",rc= " & obj.RC & ", rc_m=" & obj.RC_M & ", gr=" & obj.GR & ", gr_m=" & obj.GR_M & ", pr=" & obj.PR & ", pr_m=" & obj.PR_M & ", la=" & obj.LA & ", la_m=" & obj.LA_M & ", st=" & obj.ST & ", st_m=" & obj.ST_M & ", cr=" & obj.CR & ", cr_m=" & obj.CR_M & ", ur=" & obj.UR & ", ur_m=" & obj.UR_M & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'estadisticas', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dEstadisticaCalidad = CType(o, dEstadisticaCalidad)
        Dim sql As String = "DELETE FROM estadistica_calidad WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'estadisticas', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dEstadisticaCalidad
        Dim obj As dEstadisticaCalidad = CType(o, dEstadisticaCalidad)
        Dim l As New dEstadisticaCalidad
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, periodo, rb, rb_m, rc, rc_m, gr, gr_m, pr, pr_m, la, la_m, st, st_m, cr, cr_m, ur, ur_m FROM estadistica_calidad WHERE id = " & obj.ID)

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Integer)
                l.PERIODO = CType(unaFila.Item(1), String)
                l.RB = CType(unaFila.Item(2), Double)
                l.RB_M = CType(unaFila.Item(3), Integer)
                l.RC = CType(unaFila.Item(4), Double)
                l.RC_M = CType(unaFila.Item(5), Integer)
                l.GR = CType(unaFila.Item(6), Double)
                l.GR_M = CType(unaFila.Item(7), Integer)
                l.PR = CType(unaFila.Item(8), Double)
                l.PR_M = CType(unaFila.Item(9), Integer)
                l.LA = CType(unaFila.Item(10), Double)
                l.LA_M = CType(unaFila.Item(11), Integer)
                l.ST = CType(unaFila.Item(12), Double)
                l.ST_M = CType(unaFila.Item(13), Integer)
                l.CR = CType(unaFila.Item(14), Double)
                l.CR_M = CType(unaFila.Item(15), Integer)
                l.UR = CType(unaFila.Item(16), Double)
                l.UR_M = CType(unaFila.Item(17), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarultimo(ByVal o As Object) As dEstadisticaCalidad
        Dim obj As dEstadisticaCalidad = CType(o, dEstadisticaCalidad)
        Dim l As New dEstadisticaCalidad
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, periodo, rb, rb_m, rc, rc_m, gr, gr_m, pr, pr_m, la, la_m, st, st_m, cr, cr_m, ur, ur_m FROM estadistica_calidad WHERE id = (SELECT MAX(id) FROM estadistica_calidad)")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Integer)
                l.PERIODO = CType(unaFila.Item(1), String)
                l.RB = CType(unaFila.Item(2), Double)
                l.RB_M = CType(unaFila.Item(3), Integer)
                l.RC = CType(unaFila.Item(4), Double)
                l.RC_M = CType(unaFila.Item(5), Integer)
                l.GR = CType(unaFila.Item(6), Double)
                l.GR_M = CType(unaFila.Item(7), Integer)
                l.PR = CType(unaFila.Item(8), Double)
                l.PR_M = CType(unaFila.Item(9), Integer)
                l.LA = CType(unaFila.Item(10), Double)
                l.LA_M = CType(unaFila.Item(11), Integer)
                l.ST = CType(unaFila.Item(12), Double)
                l.ST_M = CType(unaFila.Item(13), Integer)
                l.CR = CType(unaFila.Item(14), Double)
                l.CR_M = CType(unaFila.Item(15), Integer)
                l.UR = CType(unaFila.Item(16), Double)
                l.UR_M = CType(unaFila.Item(17), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, periodo, rb, rb_m, rc, rc_m, gr, gr_m, pr, pr_m, la, la_m, st, st_m, cr, cr_m, ur, ur_m FROM estadistica_calidad order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dEstadisticaCalidad
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.PERIODO = CType(unaFila.Item(1), String)
                    l.RB = CType(unaFila.Item(2), Double)
                    l.RB_M = CType(unaFila.Item(3), Integer)
                    l.RC = CType(unaFila.Item(4), Double)
                    l.RC_M = CType(unaFila.Item(5), Integer)
                    l.GR = CType(unaFila.Item(6), Double)
                    l.GR_M = CType(unaFila.Item(7), Integer)
                    l.PR = CType(unaFila.Item(8), Double)
                    l.PR_M = CType(unaFila.Item(9), Integer)
                    l.LA = CType(unaFila.Item(10), Double)
                    l.LA_M = CType(unaFila.Item(11), Integer)
                    l.ST = CType(unaFila.Item(12), Double)
                    l.ST_M = CType(unaFila.Item(13), Integer)
                    l.CR = CType(unaFila.Item(14), Double)
                    l.CR_M = CType(unaFila.Item(15), Integer)
                    l.UR = CType(unaFila.Item(16), Double)
                    l.UR_M = CType(unaFila.Item(17), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
