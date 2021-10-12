Public Class pFrascosDevueltos
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dFrascosDevueltos = CType(o, dFrascosDevueltos)
        Dim sql As String = "INSERT INTO frascosdevueltos (id, fecha, idcliente, rc_compos, agua, sangre, esteriles, otros, observaciones) VALUES (" & obj.ID & ", '" & obj.FECHA & "', " & obj.IDCLIENTE & ", " & obj.RC_COMPOS & ", " & obj.AGUA & ", " & obj.SANGRE & ", " & obj.ESTERILES & ", " & obj.OTROS & ", '" & obj.OBSERVACIONES & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'frascos_rotos', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dFrascosDevueltos = CType(o, dFrascosDevueltos)
        Dim sql As String = "UPDATE frascosdevueltos SET fecha = '" & obj.FECHA & "', idcliente = " & obj.IDCLIENTE & ", rc_compos = " & obj.RC_COMPOS & ", agua = " & obj.AGUA & ", sangre = " & obj.SANGRE & ", esteriles = " & obj.ESTERILES & ", otros = " & obj.OTROS & ", observaciones = '" & obj.OBSERVACIONES & "' WHERE id = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'frascos_rotos', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dFrascosDevueltos = CType(o, dFrascosDevueltos)
        Dim sql As String = "DELETE FROM frascosdevueltos WHERE id = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'frascos_rotos', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dFrascosDevueltos
        Dim obj As dFrascosDevueltos = CType(o, dFrascosDevueltos)
        Dim f As New dFrascosDevueltos
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, idcliente, rc_compos, agua, sangre, esteriles, otros, observaciones FROM frascosdevueltos WHERE id = " & obj.ID)

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                f.ID = CType(unaFila.Item(0), Long)
                f.FECHA = CType(unaFila.Item(1), String)
                f.IDCLIENTE = CType(unaFila.Item(2), Long)
                f.RC_COMPOS = CType(unaFila.Item(3), Integer)
                f.AGUA = CType(unaFila.Item(4), Integer)
                f.SANGRE = CType(unaFila.Item(5), Integer)
                f.ESTERILES = CType(unaFila.Item(6), Integer)
                f.OTROS = CType(unaFila.Item(7), Integer)
                f.OBSERVACIONES = CType(unaFila.Item(8), String)
                Return f
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, idcliente, rc_compos, agua, sangre, esteriles, otros, observaciones FROM frascosdevueltos order by fecha desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim f As New dFrascosDevueltos
                    f.ID = CType(unaFila.Item(0), Long)
                    f.FECHA = CType(unaFila.Item(1), String)
                    f.IDCLIENTE = CType(unaFila.Item(2), Long)
                    f.RC_COMPOS = CType(unaFila.Item(3), Integer)
                    f.AGUA = CType(unaFila.Item(4), Integer)
                    f.SANGRE = CType(unaFila.Item(5), Integer)
                    f.ESTERILES = CType(unaFila.Item(6), Integer)
                    f.OTROS = CType(unaFila.Item(7), Integer)
                    f.OBSERVACIONES = CType(unaFila.Item(8), String)
                    Lista.Add(f)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
