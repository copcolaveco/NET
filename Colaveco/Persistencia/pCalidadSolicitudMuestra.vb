Public Class pCalidadSolicitudMuestra
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCalidadSolicitudMuestra = CType(o, dCalidadSolicitudMuestra)
        Dim sql As String = "INSERT INTO calidad_solicitud_muestra (id, ficha, muestra, rb, rc, composicion, composicionsuero, crioscopia, inhibidores, charm, esporulados, urea, termofilos, psicrotrofos, crioscopia_crioscopo, caseina, aflatoxina) VALUES (" & obj.ID & ", " & obj.FICHA & ",'" & obj.MUESTRA & "'," & obj.RB & ", " & obj.RC & ", " & obj.COMPOSICION & ", " & obj.COMPOSICIONSUERO & ", " & obj.CRIOSCOPIA & ", " & obj.INHIBIDORES & "," & obj.CHARM & ", " & obj.ESPORULADOS & ", " & obj.UREA & ", " & obj.TERMOFILOS & ", " & obj.PSICROTROFOS & ", " & obj.CRIOSCOPIA_CRIOSCOPO & ", " & obj.CASEINA & ", " & obj.AFLATOXINA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'calidad_solicitud_muestra', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCalidadSolicitudMuestra = CType(o, dCalidadSolicitudMuestra)
        Dim sql As String = "UPDATE calidad_solicitud_muestra SET muestra='" & obj.MUESTRA & "', rb=" & obj.RB & ",rc=" & obj.RC & ", composicion=" & obj.COMPOSICION & ", composicionsuero=" & obj.COMPOSICIONSUERO & ", crioscopia=" & obj.CRIOSCOPIA & ", inhibidores=" & obj.INHIBIDORES & ", charm=" & obj.CHARM & ", esporulados=" & obj.ESPORULADOS & ", urea=" & obj.UREA & ", termofilos=" & obj.TERMOFILOS & ",psicrotrofos=" & obj.PSICROTROFOS & ",crioscopia_crioscopo=" & obj.CRIOSCOPIA_CRIOSCOPO & ", caseina=" & obj.CASEINA & ", aflatoxina=" & obj.AFLATOXINA & " WHERE ficha = " & obj.FICHA

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'calidad_solicitud_muestra', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCalidadSolicitudMuestra = CType(o, dCalidadSolicitudMuestra)
        Dim sql As String = "DELETE FROM calidad_solicitud_muestra WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'calidad_solicitud_muestra', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar2(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCalidadSolicitudMuestra = CType(o, dCalidadSolicitudMuestra)
        Dim sql As String = "DELETE FROM calidad_solicitud_muestra WHERE ficha = " & obj.ficha & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'calidad_solicitud_muestra', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminarxmuestra(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCalidadSolicitudMuestra = CType(o, dCalidadSolicitudMuestra)
        Dim sql As String = "DELETE FROM calidad_solicitud_muestra WHERE ficha = " & obj.FICHA & " AND muestra = '" & obj.MUESTRA & "'"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'calidad_solicitud_muestra', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
   
    Public Function buscar(ByVal o As Object) As dCalidadSolicitudMuestra
        Dim obj As dCalidadSolicitudMuestra = CType(o, dCalidadSolicitudMuestra)
        Dim c As New dCalidadSolicitudMuestra
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, muestra, rb, rc, composicion, composicionsuero, crioscopia, inhibidores, charm, esporulados, urea, termofilos, psicrotrofos, crioscopia_crioscopo, caseina, aflatoxina FROM calidad_solicitud_muestra WHERE ficha = " & obj.FICHA & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.ficha = CType(unaFila.Item(1), Long)
                c.MUESTRA = CType(unaFila.Item(2), String)
                c.RB = CType(unaFila.Item(3), Integer)
                c.RC = CType(unaFila.Item(4), Double)
                c.COMPOSICION = CType(unaFila.Item(5), Double)
                c.COMPOSICIONSUERO = CType(unaFila.Item(6), Double)
                c.CRIOSCOPIA = CType(unaFila.Item(7), Double)
                c.INHIBIDORES = CType(unaFila.Item(8), Integer)
                c.CHARM = CType(unaFila.Item(9), Integer)
                c.ESPORULADOS = CType(unaFila.Item(10), Integer)
                c.UREA = CType(unaFila.Item(11), Integer)
                c.TERMOFILOS = CType(unaFila.Item(12), Integer)
                c.PSICROTROFOS = CType(unaFila.Item(13), Integer)
                c.CRIOSCOPIA_CRIOSCOPO = CType(unaFila.Item(14), Integer)
                c.CASEINA = CType(unaFila.Item(15), Integer)
                c.AFLATOXINA = CType(unaFila.Item(16), Integer)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxsolicitud(ByVal o As Object) As dCalidadSolicitudMuestra
        Dim obj As dCalidadSolicitudMuestra = CType(o, dCalidadSolicitudMuestra)
        Dim c As New dCalidadSolicitudMuestra
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, muestra, rb, rc, composicion, composicionsuero, crioscopia, inhibidores, charm, esporulados, urea, termofilos, psicrotrofos, crioscopia_crioscopo, caseina, aflatoxina FROM calidad_solicitud_muestra WHERE ficha = " & obj.FICHA & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FICHA = CType(unaFila.Item(1), Long)
                c.MUESTRA = CType(unaFila.Item(2), String)
                c.RB = CType(unaFila.Item(3), Integer)
                c.RC = CType(unaFila.Item(4), Double)
                c.COMPOSICION = CType(unaFila.Item(5), Double)
                c.COMPOSICIONSUERO = CType(unaFila.Item(6), Double)
                c.CRIOSCOPIA = CType(unaFila.Item(7), Double)
                c.INHIBIDORES = CType(unaFila.Item(8), Integer)
                c.CHARM = CType(unaFila.Item(9), Integer)
                c.ESPORULADOS = CType(unaFila.Item(10), Integer)
                c.UREA = CType(unaFila.Item(11), Integer)
                c.TERMOFILOS = CType(unaFila.Item(12), Integer)
                c.PSICROTROFOS = CType(unaFila.Item(13), Integer)
                c.CRIOSCOPIA_CRIOSCOPO = CType(unaFila.Item(14), Integer)
                c.CASEINA = CType(unaFila.Item(15), Integer)
                c.AFLATOXINA = CType(unaFila.Item(16), Integer)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, muestra, rb, rc, composicion, composicionsuero, crioscopia, inhibidores, charm, esporulados, urea, termofilos, psicrotrofos, crioscopia_crioscopo, caseina, aflatoxina FROM calidad_solicitud_muestra WHERE marca = 0 order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitudMuestra
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), Long)
                    c.MUESTRA = CType(unaFila.Item(2), String)
                    c.RB = CType(unaFila.Item(3), Integer)
                    c.RC = CType(unaFila.Item(4), Double)
                    c.COMPOSICION = CType(unaFila.Item(5), Double)
                    c.COMPOSICIONSUERO = CType(unaFila.Item(6), Double)
                    c.CRIOSCOPIA = CType(unaFila.Item(7), Double)
                    c.INHIBIDORES = CType(unaFila.Item(8), Integer)
                    c.CHARM = CType(unaFila.Item(9), Integer)
                    c.ESPORULADOS = CType(unaFila.Item(10), Integer)
                    c.UREA = CType(unaFila.Item(11), Integer)
                    c.TERMOFILOS = CType(unaFila.Item(12), Integer)
                    c.PSICROTROFOS = CType(unaFila.Item(13), Integer)
                    c.CRIOSCOPIA_CRIOSCOPO = CType(unaFila.Item(14), Integer)
                    c.CASEINA = CType(unaFila.Item(15), Integer)
                    c.AFLATOXINA = CType(unaFila.Item(16), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichas() As ArrayList
        Dim sql As String = "SELECT DISTINCT ficha FROM calidad_solicitud_muestra WHERE marca = 0 order by ficha asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitudMuestra
                    c.ficha = CType(unaFila.Item(0), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, muestra, rb, rc, composicion, composicionsuero, crioscopia, inhibidores, charm, esporulados, urea, termofilos, psicrotrofos, crioscopia_crioscopo, caseina, aflatoxina FROM calidad_solicitud_muestra where ficha = " & texto & " order by id desc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitudMuestra
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), Long)
                    c.MUESTRA = CType(unaFila.Item(2), String)
                    c.RB = CType(unaFila.Item(3), Integer)
                    c.RC = CType(unaFila.Item(4), Double)
                    c.COMPOSICION = CType(unaFila.Item(5), Double)
                    c.COMPOSICIONSUERO = CType(unaFila.Item(6), Double)
                    c.CRIOSCOPIA = CType(unaFila.Item(7), Double)
                    c.INHIBIDORES = CType(unaFila.Item(8), Integer)
                    c.CHARM = CType(unaFila.Item(9), Integer)
                    c.ESPORULADOS = CType(unaFila.Item(10), Integer)
                    c.UREA = CType(unaFila.Item(11), Integer)
                    c.TERMOFILOS = CType(unaFila.Item(12), Integer)
                    c.PSICROTROFOS = CType(unaFila.Item(13), Integer)
                    c.CRIOSCOPIA_CRIOSCOPO = CType(unaFila.Item(14), Integer)
                    c.CASEINA = CType(unaFila.Item(15), Integer)
                    c.AFLATOXINA = CType(unaFila.Item(16), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controlarmuestras(ByVal ficha As Long, ByVal muestra As String) As ArrayList
        Dim sql As String = ("SELECT id, ficha, muestra, rb, rc, composicion, composicionsuero, crioscopia, inhibidores, charm, esporulados, urea, termofilos, psicrotrofos, crioscopia_crioscopo, caseina, aflatoxina FROM calidad_solicitud_muestra where ficha = '" & ficha & "' and muestra = '" & muestra & "' ")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitudMuestra
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), Long)
                    c.MUESTRA = CType(unaFila.Item(2), String)
                    c.RB = CType(unaFila.Item(3), Integer)
                    c.RC = CType(unaFila.Item(4), Double)
                    c.COMPOSICION = CType(unaFila.Item(5), Double)
                    c.COMPOSICIONSUERO = CType(unaFila.Item(6), Double)
                    c.CRIOSCOPIA = CType(unaFila.Item(7), Double)
                    c.INHIBIDORES = CType(unaFila.Item(8), Integer)
                    c.CHARM = CType(unaFila.Item(9), Integer)
                    c.ESPORULADOS = CType(unaFila.Item(10), Integer)
                    c.UREA = CType(unaFila.Item(11), Integer)
                    c.TERMOFILOS = CType(unaFila.Item(12), Integer)
                    c.PSICROTROFOS = CType(unaFila.Item(13), Integer)
                    c.CRIOSCOPIA_CRIOSCOPO = CType(unaFila.Item(14), Integer)
                    c.CASEINA = CType(unaFila.Item(15), Integer)
                    c.AFLATOXINA = CType(unaFila.Item(16), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, muestra, rb, rc, composicion, composicionsuero, crioscopia, inhibidores, charm, esporulados, urea, termofilos, psicrotrofos, crioscopia_crioscopo, caseina, aflatoxina FROM calidad_solicitud_muestra where ficha = " & texto & " order by muestra asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitudMuestra
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), Long)
                    c.MUESTRA = CType(unaFila.Item(2), String)
                    c.RB = CType(unaFila.Item(3), Integer)
                    c.RC = CType(unaFila.Item(4), Double)
                    c.COMPOSICION = CType(unaFila.Item(5), Double)
                    c.COMPOSICIONSUERO = CType(unaFila.Item(6), Double)
                    c.CRIOSCOPIA = CType(unaFila.Item(7), Double)
                    c.INHIBIDORES = CType(unaFila.Item(8), Integer)
                    c.CHARM = CType(unaFila.Item(9), Integer)
                    c.ESPORULADOS = CType(unaFila.Item(10), Integer)
                    c.UREA = CType(unaFila.Item(11), Integer)
                    c.TERMOFILOS = CType(unaFila.Item(12), Integer)
                    c.PSICROTROFOS = CType(unaFila.Item(13), Integer)
                    c.CRIOSCOPIA_CRIOSCOPO = CType(unaFila.Item(14), Integer)
                    c.CASEINA = CType(unaFila.Item(15), Integer)
                    c.AFLATOXINA = CType(unaFila.Item(16), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
   
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha,muestra, rb, rc, composicion, composicionsuero, crioscopia, inhibidores, charm, esporulados, urea, termofilos, psicrotrofos, crioscopia_crioscopo, caseina, aflatoxina FROM calidad_solicitud_muestra where marca = 1 and ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitudMuestra
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), Long)
                    c.MUESTRA = CType(unaFila.Item(2), String)
                    c.RB = CType(unaFila.Item(3), Integer)
                    c.RC = CType(unaFila.Item(4), Double)
                    c.COMPOSICION = CType(unaFila.Item(5), Double)
                    c.COMPOSICIONSUERO = CType(unaFila.Item(6), Double)
                    c.CRIOSCOPIA = CType(unaFila.Item(7), Double)
                    c.INHIBIDORES = CType(unaFila.Item(8), Integer)
                    c.CHARM = CType(unaFila.Item(9), Integer)
                    c.ESPORULADOS = CType(unaFila.Item(10), Integer)
                    c.UREA = CType(unaFila.Item(11), Integer)
                    c.TERMOFILOS = CType(unaFila.Item(12), Integer)
                    c.PSICROTROFOS = CType(unaFila.Item(13), Integer)
                    c.CRIOSCOPIA_CRIOSCOPO = CType(unaFila.Item(14), Integer)
                    c.CASEINA = CType(unaFila.Item(15), Integer)
                    c.AFLATOXINA = CType(unaFila.Item(16), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporsolicitud3(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, muestra, rb, rc, composicion, composicionsuero, crioscopia, inhibidores, charm, esporulados, urea, termofilos, psicrotrofos, crioscopia_crioscopo, caseina, aflatoxina FROM calidad_solicitud_muestra where ficha = " & texto & " order by id asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitudMuestra
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), Long)
                    c.MUESTRA = CType(unaFila.Item(2), String)
                    c.RB = CType(unaFila.Item(3), Integer)
                    c.RC = CType(unaFila.Item(4), Double)
                    c.COMPOSICION = CType(unaFila.Item(5), Double)
                    c.COMPOSICIONSUERO = CType(unaFila.Item(6), Double)
                    c.CRIOSCOPIA = CType(unaFila.Item(7), Double)
                    c.INHIBIDORES = CType(unaFila.Item(8), Integer)
                    c.CHARM = CType(unaFila.Item(9), Integer)
                    c.ESPORULADOS = CType(unaFila.Item(10), Integer)
                    c.UREA = CType(unaFila.Item(11), Integer)
                    c.TERMOFILOS = CType(unaFila.Item(12), Integer)
                    c.PSICROTROFOS = CType(unaFila.Item(13), Integer)
                    c.CRIOSCOPIA_CRIOSCOPO = CType(unaFila.Item(14), Integer)
                    c.CASEINA = CType(unaFila.Item(15), Integer)
                    c.AFLATOXINA = CType(unaFila.Item(16), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, ficha, muestra, rb, rc, composicion, composicionsuero, crioscopia, inhibidores, charm, esporulados, urea, termofilos, psicrotrofos, crioscopia_crioscopo, caseina, aflatoxina FROM calidad_solicitud_muestra where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "'")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitudMuestra
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), Long)
                    c.MUESTRA = CType(unaFila.Item(2), String)
                    c.RB = CType(unaFila.Item(3), Integer)
                    c.RC = CType(unaFila.Item(4), Double)
                    c.COMPOSICION = CType(unaFila.Item(5), Double)
                    c.COMPOSICIONSUERO = CType(unaFila.Item(6), Double)
                    c.CRIOSCOPIA = CType(unaFila.Item(7), Double)
                    c.INHIBIDORES = CType(unaFila.Item(8), Integer)
                    c.CHARM = CType(unaFila.Item(9), Integer)
                    c.ESPORULADOS = CType(unaFila.Item(10), Integer)
                    c.UREA = CType(unaFila.Item(11), Integer)
                    c.TERMOFILOS = CType(unaFila.Item(12), Integer)
                    c.PSICROTROFOS = CType(unaFila.Item(13), Integer)
                    c.CRIOSCOPIA_CRIOSCOPO = CType(unaFila.Item(14), Integer)
                    c.CASEINA = CType(unaFila.Item(15), Integer)
                    c.AFLATOXINA = CType(unaFila.Item(16), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarrb(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id FROM calidad_solicitud_muestra where ficha = " & texto & " and rb=1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitudMuestra
                    c.ID = CType(unaFila.Item(0), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarrc(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id FROM calidad_solicitud_muestra where ficha = " & texto & " and rc=1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitudMuestra
                    c.ID = CType(unaFila.Item(0), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarcomposicion(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id FROM calidad_solicitud_muestra where ficha = " & texto & " and composicion=1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitudMuestra
                    c.ID = CType(unaFila.Item(0), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarcomposicionsuero(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id FROM calidad_solicitud_muestra where ficha = " & texto & " and composicionsuero=1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitudMuestra
                    c.ID = CType(unaFila.Item(0), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarcrioscopia(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id FROM calidad_solicitud_muestra where ficha = " & texto & " and crioscopia=1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitudMuestra
                    c.ID = CType(unaFila.Item(0), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarinhibidores(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id FROM calidad_solicitud_muestra where ficha = " & texto & " and inhibidores=1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitudMuestra
                    c.ID = CType(unaFila.Item(0), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarcharm(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id FROM calidad_solicitud_muestra where ficha = " & texto & " and charm=1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitudMuestra
                    c.ID = CType(unaFila.Item(0), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listaresporulados(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id FROM calidad_solicitud_muestra where ficha = " & texto & " and esporulados=1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitudMuestra
                    c.ID = CType(unaFila.Item(0), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarurea(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id FROM calidad_solicitud_muestra where ficha = " & texto & " and urea=1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitudMuestra
                    c.ID = CType(unaFila.Item(0), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listartermofilos(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id FROM calidad_solicitud_muestra where ficha = " & texto & " and termofilos=1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitudMuestra
                    c.ID = CType(unaFila.Item(0), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarpsicrotrofos(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id FROM calidad_solicitud_muestra where ficha = " & texto & " and psicrotrofos=1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitudMuestra
                    c.ID = CType(unaFila.Item(0), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarcrioscopia_crioscopo(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id FROM calidad_solicitud_muestra where ficha = " & texto & " and crioscopia_crioscopo=1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitudMuestra
                    c.ID = CType(unaFila.Item(0), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarrb_rc(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id FROM calidad_solicitud_muestra where ficha = " & texto & " and rb=1 and rc=1 ")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitudMuestra
                    c.ID = CType(unaFila.Item(0), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarrb_rc_composicion(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id FROM calidad_solicitud_muestra where ficha = " & texto & " and rb=1 and rc=1 and composicion=1 ")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitudMuestra
                    c.ID = CType(unaFila.Item(0), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar_caseina(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id FROM calidad_solicitud_muestra where ficha = " & texto & " and caseina=1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitudMuestra
                    c.ID = CType(unaFila.Item(0), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar_aflatoxina(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id FROM calidad_solicitud_muestra where ficha = " & texto & " and aflatoxina=1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitudMuestra
                    c.ID = CType(unaFila.Item(0), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar_composicionsuero(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id FROM calidad_solicitud_muestra where ficha = " & texto & " and composicionsuero=1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitudMuestra
                    c.ID = CType(unaFila.Item(0), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
