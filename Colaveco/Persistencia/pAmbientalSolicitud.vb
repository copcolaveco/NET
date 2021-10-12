Public Class pAmbientalSolicitud
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAmbientalSolicitud = CType(o, dAmbientalSolicitud)
        Dim sql As String = "INSERT INTO ambiental_solicitud (id, ficha, enterobacterias, listambiental, listmono, salmonella, ecoli, mohosylevaduras, rb, ct, cf, pseudomonaspp, listeriaspp, estafcoagpositivo) VALUES (" & obj.ID & ", " & obj.FICHA & "," & obj.ENTEROBACTERIAS & ", " & obj.LISTAMBIENTAL & ", " & obj.LISTMONO & "," & obj.SALMONELLA & "," & obj.ECOLI & "," & obj.MOHOSYLEVADURAS & "," & obj.RB & "," & obj.CT & "," & obj.CF & "," & obj.PSEUDOMONASPP & "," & obj.LISTSPP & "," & obj.ESTAFCOAGPOS & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'ambiental_solicitud', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAmbientalSolicitud = CType(o, dAmbientalSolicitud)
        Dim sql As String = "UPDATE ambiental_solicitud SET enterobacterias=" & obj.ENTEROBACTERIAS & ",listambiental=" & obj.LISTAMBIENTAL & ", listmono=" & obj.LISTMONO & ", salmonella=" & obj.SALMONELLA & ", ecoli=" & obj.ECOLI & ",mohosylevaduras=" & obj.MOHOSYLEVADURAS & ",rb=" & obj.RB & ",ct=" & obj.CT & ",cf=" & obj.CF & ",pseudomonaspp=" & obj.PSEUDOMONASPP & ",listeriaspp=" & obj.LISTSPP & ",estafcoagpositivo=" & obj.ESTAFCOAGPOS & " WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'ambiental_solicitud', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAmbientalSolicitud = CType(o, dAmbientalSolicitud)
        Dim sql As String = "DELETE FROM ambiental_solicitud WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'ambiental_solicitud', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar2(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAmbientalSolicitud = CType(o, dAmbientalSolicitud)
        Dim sql As String = "DELETE FROM ambiental_solicitud WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'ambiental_solicitud', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dAmbientalSolicitud
        Dim obj As dAmbientalSolicitud = CType(o, dAmbientalSolicitud)
        Dim a As New dAmbientalSolicitud
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, enterobacterias, listambiental, listmono, salmonella, ecoli, mohosylevaduras, rb, ct, cf, pseudomonaspp, listeriaspp, estafcoagpositivo FROM ambiental_solicitud WHERE ficha = " & obj.FICHA & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                a.ID = CType(unaFila.Item(0), Long)
                a.FICHA = CType(unaFila.Item(1), Long)
                a.ENTEROBACTERIAS = CType(unaFila.Item(2), Integer)
                a.LISTAMBIENTAL = CType(unaFila.Item(3), Integer)
                a.LISTMONO = CType(unaFila.Item(4), Integer)
                a.SALMONELLA = CType(unaFila.Item(5), Integer)
                a.ECOLI = CType(unaFila.Item(6), Integer)
                a.MOHOSYLEVADURAS = CType(unaFila.Item(7), Integer)
                a.RB = CType(unaFila.Item(8), Integer)
                a.CT = CType(unaFila.Item(9), Integer)
                a.CF = CType(unaFila.Item(10), Integer)
                a.PSEUDOMONASPP = CType(unaFila.Item(11), Integer)
                a.LISTSPP = CType(unaFila.Item(12), Integer)
                a.ESTAFCOAGPOS = CType(unaFila.Item(13), Integer)
                Return a
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, enterobacterias, listambiental, listmono, salmonella, ecoli, mohosylevaduras, rb, ct, cf, pseudomonaspp, listeriaspp, estafcoagpositivo FROM ambiental_solicitud WHERE marca = 0 order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAmbientalSolicitud
                    a.ID = CType(unaFila.Item(0), Long)
                    a.FICHA = CType(unaFila.Item(1), Long)
                    a.ENTEROBACTERIAS = CType(unaFila.Item(2), Integer)
                    a.LISTAMBIENTAL = CType(unaFila.Item(3), Integer)
                    a.LISTMONO = CType(unaFila.Item(4), Integer)
                    a.SALMONELLA = CType(unaFila.Item(5), Integer)
                    a.ECOLI = CType(unaFila.Item(6), Integer)
                    a.MOHOSYLEVADURAS = CType(unaFila.Item(7), Integer)
                    a.RB = CType(unaFila.Item(8), Integer)
                    a.CT = CType(unaFila.Item(9), Integer)
                    a.CF = CType(unaFila.Item(10), Integer)
                    a.PSEUDOMONASPP = CType(unaFila.Item(11), Integer)
                    a.LISTSPP = CType(unaFila.Item(12), Integer)
                    a.ESTAFCOAGPOS = CType(unaFila.Item(13), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichas() As ArrayList
        Dim sql As String = "SELECT DISTINCT ficha FROM ambiental_solicitud WHERE marca = 0 order by ficha asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAmbientalSolicitud
                    a.FICHA = CType(unaFila.Item(0), Long)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, enterobacterias, listambiental, listmono, salmonella, ecoli, mohosylevaduras, rb, ct, cf, pseudomonaspp, listeriaspp, estafcoagpositivo FROM ambiental_solicitud where ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAmbientalSolicitud
                    a.ID = CType(unaFila.Item(0), Long)
                    a.FICHA = CType(unaFila.Item(1), Long)
                    a.ENTEROBACTERIAS = CType(unaFila.Item(2), Integer)
                    a.LISTAMBIENTAL = CType(unaFila.Item(3), Integer)
                    a.LISTMONO = CType(unaFila.Item(4), Integer)
                    a.SALMONELLA = CType(unaFila.Item(5), Integer)
                    a.ECOLI = CType(unaFila.Item(6), Integer)
                    a.MOHOSYLEVADURAS = CType(unaFila.Item(7), Integer)
                    a.RB = CType(unaFila.Item(8), Integer)
                    a.CT = CType(unaFila.Item(9), Integer)
                    a.CF = CType(unaFila.Item(10), Integer)
                    a.PSEUDOMONASPP = CType(unaFila.Item(11), Integer)
                    a.LISTSPP = CType(unaFila.Item(12), Integer)
                    a.ESTAFCOAGPOS = CType(unaFila.Item(13), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, enterobacterias, listambiental, listmono, salmonella, ecoli, mohosylevaduras, rb, ct, cf, pseudomonaspp, listeriaspp, estafcoagpositivo FROM ambiental_solicitud where ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAmbientalSolicitud
                    a.ID = CType(unaFila.Item(0), Long)
                    a.FICHA = CType(unaFila.Item(1), Long)
                    a.ENTEROBACTERIAS = CType(unaFila.Item(2), Integer)
                    a.LISTAMBIENTAL = CType(unaFila.Item(3), Integer)
                    a.LISTMONO = CType(unaFila.Item(4), Integer)
                    a.SALMONELLA = CType(unaFila.Item(5), Integer)
                    a.ECOLI = CType(unaFila.Item(6), Integer)
                    a.MOHOSYLEVADURAS = CType(unaFila.Item(7), Integer)
                    a.RB = CType(unaFila.Item(8), Integer)
                    a.CT = CType(unaFila.Item(9), Integer)
                    a.CF = CType(unaFila.Item(10), Integer)
                    a.PSEUDOMONASPP = CType(unaFila.Item(11), Integer)
                    a.LISTSPP = CType(unaFila.Item(12), Integer)
                    a.ESTAFCOAGPOS = CType(unaFila.Item(13), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, enterobacterias, listambiental, listmono, salmonella, ecoli, mohosylevaduras, rb, ct, cf, pseudomonaspp, listeriaspp, estafcoagpositivo FROM ambiental_solicitud where ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAmbientalSolicitud
                    a.ID = CType(unaFila.Item(0), Long)
                    a.FICHA = CType(unaFila.Item(1), Long)
                    a.ENTEROBACTERIAS = CType(unaFila.Item(2), Integer)
                    a.LISTAMBIENTAL = CType(unaFila.Item(3), Integer)
                    a.LISTMONO = CType(unaFila.Item(4), Integer)
                    a.SALMONELLA = CType(unaFila.Item(5), Integer)
                    a.ECOLI = CType(unaFila.Item(6), Integer)
                    a.MOHOSYLEVADURAS = CType(unaFila.Item(7), Integer)
                    a.RB = CType(unaFila.Item(8), Integer)
                    a.CT = CType(unaFila.Item(9), Integer)
                    a.CF = CType(unaFila.Item(10), Integer)
                    a.PSEUDOMONASPP = CType(unaFila.Item(11), Integer)
                    a.LISTSPP = CType(unaFila.Item(12), Integer)
                    a.ESTAFCOAGPOS = CType(unaFila.Item(13), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, ficha, enterobacterias, listambiental, listmono, salmonella, ecoli, mohosylevaduras, rb, ct, cf, pseudomonaspp, listeriaspp, estafcoagpositivo FROM ambiental_solicitud where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "'")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAmbientalSolicitud
                    a.ID = CType(unaFila.Item(0), Long)
                    a.FICHA = CType(unaFila.Item(1), Long)
                    a.ENTEROBACTERIAS = CType(unaFila.Item(2), Integer)
                    a.LISTAMBIENTAL = CType(unaFila.Item(3), Integer)
                    a.LISTMONO = CType(unaFila.Item(4), Integer)
                    a.SALMONELLA = CType(unaFila.Item(5), Integer)
                    a.ECOLI = CType(unaFila.Item(6), Integer)
                    a.MOHOSYLEVADURAS = CType(unaFila.Item(7), Integer)
                    a.RB = CType(unaFila.Item(8), Integer)
                    a.CT = CType(unaFila.Item(9), Integer)
                    a.CF = CType(unaFila.Item(10), Integer)
                    a.PSEUDOMONASPP = CType(unaFila.Item(11), Integer)
                    a.LISTSPP = CType(unaFila.Item(12), Integer)
                    a.ESTAFCOAGPOS = CType(unaFila.Item(13), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxsolicitud(ByVal o As Object) As dAmbientalSolicitud
        Dim obj As dAmbientalSolicitud = CType(o, dAmbientalSolicitud)
        Dim a As New dAmbientalSolicitud
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, enterobacterias, listambiental, listmono, salmonella, ecoli, mohosylevaduras, rb, ct, cf, pseudomonaspp, listeriaspp, estafcoagpositivo FROM ambiental_solicitud WHERE ficha = " & obj.FICHA & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                a.ID = CType(unaFila.Item(0), Long)
                a.FICHA = CType(unaFila.Item(1), Long)
                a.ENTEROBACTERIAS = CType(unaFila.Item(2), Integer)
                a.LISTAMBIENTAL = CType(unaFila.Item(3), Integer)
                a.LISTMONO = CType(unaFila.Item(4), Integer)
                a.SALMONELLA = CType(unaFila.Item(5), Integer)
                a.ECOLI = CType(unaFila.Item(6), Integer)
                a.MOHOSYLEVADURAS = CType(unaFila.Item(7), Integer)
                a.RB = CType(unaFila.Item(8), Integer)
                a.CT = CType(unaFila.Item(9), Integer)
                a.CF = CType(unaFila.Item(10), Integer)
                a.PSEUDOMONASPP = CType(unaFila.Item(11), Integer)
                a.LISTSPP = CType(unaFila.Item(12), Integer)
                a.ESTAFCOAGPOS = CType(unaFila.Item(13), Integer)
                Return a
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
