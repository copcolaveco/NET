Public Class pPlanillaCapacitacion
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dPlanillaCapacitacion = CType(o, dPlanillaCapacitacion)
        Dim sql As String = "INSERT INTO planillacapacitacion (id, idlin, participante, tipoactividad, instructor, fechainicio, fechafin, local, horas, costo, autorizacion, fechaautorizacion, b1, b2, b3, recomendar, comentarios, evaluaciondir, comentariosdir, evaluacion, devolucion, mejora, repercusion) VALUES (" & obj.ID & ", " & obj.IDLIN & ", " & obj.PARTICIPANTE & ", " & obj.TIPOACTIVIDAD & ",'" & obj.INSTRUCTOR & "','" & obj.FECHAINICIO & "', '" & obj.FECHAFIN & "', '" & obj.LOCAL & "', '" & obj.HORAS & "', '" & obj.COSTO & "', " & obj.AUTORIZACION & ", '" & obj.FECHAAUTORIZACION & "', " & obj.B1 & ", " & obj.B2 & ", " & obj.B3 & ", '" & obj.RECOMENDAR & "', '" & obj.COMENTARIOS & "', " & obj.EVALUACIONDIR & ", '" & obj.COMENTARIOSDIR & "', '" & obj.EVALUACION & "', '" & obj.DEVOLUCION & "', '" & obj.MEJORA & "', '" & obj.REPERCUSION & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'planillacapacitacion', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dPlanillaCapacitacion = CType(o, dPlanillaCapacitacion)
        Dim sql As String = "UPDATE planillacapacitacion SET idlin= " & obj.IDLIN & ",participante= " & obj.PARTICIPANTE & ", tipoactividad=" & obj.TIPOACTIVIDAD & ",instructor='" & obj.INSTRUCTOR & "',fechainicio='" & obj.FECHAINICIO & "',fechafin= '" & obj.FECHAFIN & "',local= '" & obj.LOCAL & "',horas= '" & obj.HORAS & "',costo= '" & obj.COSTO & "',autorizacion= " & obj.AUTORIZACION & ",fechaautorizacion= '" & obj.FECHAAUTORIZACION & "',b1= " & obj.B1 & ",b2= " & obj.B2 & ",b3= " & obj.B3 & ",recomendar= '" & obj.RECOMENDAR & "',comentarios= '" & obj.COMENTARIOS & "',evaluaciondir= " & obj.EVALUACIONDIR & ",comentariosdir= '" & obj.COMENTARIOSDIR & "',evaluacion= '" & obj.EVALUACION & "',devolucion= '" & obj.DEVOLUCION & "',mejora= '" & obj.MEJORA & "',repercusion= '" & obj.REPERCUSION & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'planillacapacitacion', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dPlanillaCapacitacion = CType(o, dPlanillaCapacitacion)
        Dim sql As String = "DELETE FROM planillacapacitacion WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'planillacapacitacion', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dPlanillaCapacitacion
        Dim obj As dPlanillaCapacitacion = CType(o, dPlanillaCapacitacion)
        Dim l As New dPlanillaCapacitacion
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idlin, participante, tipoactividad, ifnull(instructor,''), fechainicio, fechafin, ifnull(local,''), ifnull(horas,''), ifnull(costo,''), autorizacion, fechaautorizacion, b1, b2, b3, ifnull(recomendar,''), ifnull(comentarios,''), evaluaciondir, ifnull(comentariosdir,''), ifnull(evaluacion,''), ifnull(devolucion,''), ifnull(mejora,''), ifnull(repercusion,'') FROM planillacapacitacion WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Long)
                l.IDLIN = CType(unaFila.Item(1), Long)
                l.PARTICIPANTE = CType(unaFila.Item(2), Integer)
                l.TIPOACTIVIDAD = CType(unaFila.Item(3), Integer)
                l.INSTRUCTOR = CType(unaFila.Item(4), String)
                l.FECHAINICIO = CType(unaFila.Item(5), String)
                l.FECHAFIN = CType(unaFila.Item(6), String)
                l.LOCAL = CType(unaFila.Item(7), String)
                l.HORAS = CType(unaFila.Item(8), String)
                l.COSTO = CType(unaFila.Item(9), String)
                l.AUTORIZACION = CType(unaFila.Item(10), Integer)
                l.FECHAAUTORIZACION = CType(unaFila.Item(11), String)
                l.B1 = CType(unaFila.Item(12), Integer)
                l.B2 = CType(unaFila.Item(13), Integer)
                l.B3 = CType(unaFila.Item(14), Integer)
                l.RECOMENDAR = CType(unaFila.Item(15), String)
                l.COMENTARIOS = CType(unaFila.Item(16), String)
                l.EVALUACIONDIR = CType(unaFila.Item(17), Integer)
                l.COMENTARIOSDIR = CType(unaFila.Item(18), String)
                l.EVALUACION = CType(unaFila.Item(19), String)
                l.DEVOLUCION = CType(unaFila.Item(20), String)
                l.MEJORA = CType(unaFila.Item(21), String)
                l.REPERCUSION = CType(unaFila.Item(22), String)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxcapacitacion(ByVal o As Object) As dPlanillaCapacitacion
        Dim obj As dPlanillaCapacitacion = CType(o, dPlanillaCapacitacion)
        Dim l As New dPlanillaCapacitacion
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idlin, participante, tipoactividad, ifnull(instructor,''), fechainicio, fechafin, ifnull(local,''), ifnull(horas,''), ifnull(costo,''), autorizacion, fechaautorizacion, b1, b2, b3, ifnull(recomendar,''), ifnull(comentarios,''), evaluaciondir, ifnull(comentariosdir,''), ifnull(evaluacion,''), ifnull(devolucion,''), ifnull(mejora,''), ifnull(repercusion,'') FROM planillacapacitacion WHERE idlin = " & obj.IDLIN & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Long)
                l.IDLIN = CType(unaFila.Item(1), Long)
                l.PARTICIPANTE = CType(unaFila.Item(2), Integer)
                l.TIPOACTIVIDAD = CType(unaFila.Item(3), Integer)
                l.INSTRUCTOR = CType(unaFila.Item(4), String)
                l.FECHAINICIO = CType(unaFila.Item(5), String)
                l.FECHAFIN = CType(unaFila.Item(6), String)
                l.LOCAL = CType(unaFila.Item(7), String)
                l.HORAS = CType(unaFila.Item(8), String)
                l.COSTO = CType(unaFila.Item(9), String)
                l.AUTORIZACION = CType(unaFila.Item(10), Integer)
                l.FECHAAUTORIZACION = CType(unaFila.Item(11), String)
                l.B1 = CType(unaFila.Item(12), Integer)
                l.B2 = CType(unaFila.Item(13), Integer)
                l.B3 = CType(unaFila.Item(14), Integer)
                l.RECOMENDAR = CType(unaFila.Item(15), String)
                l.COMENTARIOS = CType(unaFila.Item(16), String)
                l.EVALUACIONDIR = CType(unaFila.Item(17), Integer)
                l.COMENTARIOSDIR = CType(unaFila.Item(18), String)
                l.EVALUACION = CType(unaFila.Item(19), String)
                l.DEVOLUCION = CType(unaFila.Item(20), String)
                l.MEJORA = CType(unaFila.Item(21), String)
                l.REPERCUSION = CType(unaFila.Item(22), String)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, idlin, participante, tipoactividad, ifnull(instructor,''), fechainicio, fechafin, ifnull(local,''), ifnull(horas,''), ifnull(costo,''), autorizacion, fechaautorizacion, b1, b2, b3, ifnull(recomendar,''), ifnull(comentarios,''), evaluaciondir, ifnull(comentariosdir,''), ifnull(evaluacion,''), ifnull(devolucion,''), ifnull(mejora,''), ifnull(repercusion,'') FROM planillacapacitacion order by desde desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dPlanillaCapacitacion
                    l.ID = CType(unaFila.Item(0), Long)
                    l.IDLIN = CType(unaFila.Item(1), Long)
                    l.PARTICIPANTE = CType(unaFila.Item(2), Integer)
                    l.TIPOACTIVIDAD = CType(unaFila.Item(3), Integer)
                    l.INSTRUCTOR = CType(unaFila.Item(4), String)
                    l.FECHAINICIO = CType(unaFila.Item(5), String)
                    l.FECHAFIN = CType(unaFila.Item(6), String)
                    l.LOCAL = CType(unaFila.Item(7), String)
                    l.HORAS = CType(unaFila.Item(8), String)
                    l.COSTO = CType(unaFila.Item(9), String)
                    l.AUTORIZACION = CType(unaFila.Item(10), Integer)
                    l.FECHAAUTORIZACION = CType(unaFila.Item(11), String)
                    l.B1 = CType(unaFila.Item(12), Integer)
                    l.B2 = CType(unaFila.Item(13), Integer)
                    l.B3 = CType(unaFila.Item(14), Integer)
                    l.RECOMENDAR = CType(unaFila.Item(15), String)
                    l.COMENTARIOS = CType(unaFila.Item(16), String)
                    l.EVALUACIONDIR = CType(unaFila.Item(17), Integer)
                    l.COMENTARIOSDIR = CType(unaFila.Item(18), String)
                    l.EVALUACION = CType(unaFila.Item(19), String)
                    l.DEVOLUCION = CType(unaFila.Item(20), String)
                    l.MEJORA = CType(unaFila.Item(21), String)
                    l.REPERCUSION = CType(unaFila.Item(22), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    
End Class
