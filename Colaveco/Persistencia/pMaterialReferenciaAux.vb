Public Class pMaterialReferenciaAux
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object) As Boolean
        Dim obj As dMaterialReferenciaAux = CType(o, dMaterialReferenciaAux)
        Dim sql As String = "INSERT INTO material_referencia_aux (id, fecha, operador, equipo, item, lectura, pasada) VALUES (" & obj.ID & ", '" & obj.FECHA & "', '" & obj.OPERADOR & "', '" & obj.EQUIPO & "', '" & obj.ITEM & "', " & obj.LECTURA & ", " & obj.PASADA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMaterialReferenciaAux = CType(o, dMaterialReferenciaAux)
        Dim sql As String = "UPDATE material_referencia_aux SET fecha = '" & obj.FECHA & "',operador = '" & obj.OPERADOR & "',equipo = '" & obj.EQUIPO & "',item = '" & obj.ITEM & "',lectura = " & obj.LECTURA & ",pasada = " & obj.PASADA & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'materialreferencia', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMaterialReferenciaAux = CType(o, dMaterialReferenciaAux)
        Dim sql As String = "DELETE FROM material_referencia_aux WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'materialreferencia', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function vaciar(ByVal o As Object) As Boolean
        Dim obj As dMaterialReferenciaAux = CType(o, dMaterialReferenciaAux)
        Dim sql As String = "TRUNCATE TABLE material_referencia_aux"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dMaterialReferenciaAux
        Dim obj As dMaterialReferenciaAux = CType(o, dMaterialReferenciaAux)
        Dim l As New dMaterialReferenciaAux
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, operador, equipo, item, lectura, pasada FROM material_referencia_aux WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Integer)
                l.FECHA = CType(unaFila.Item(1), String)
                l.OPERADOR = CType(unaFila.Item(2), String)
                l.EQUIPO = CType(unaFila.Item(3), String)
                l.ITEM = CType(unaFila.Item(4), String)
                l.LECTURA = CType(unaFila.Item(5), Double)
                l.PASADA = CType(unaFila.Item(6), Integer)

                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, operador, equipo, item, lectura, pasada FROM material_referencia_aux ORDER BY fecha ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dMaterialReferenciaAux
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.OPERADOR = CType(unaFila.Item(2), String)
                    l.EQUIPO = CType(unaFila.Item(3), String)
                    l.ITEM = CType(unaFila.Item(4), String)
                    l.LECTURA = CType(unaFila.Item(5), Double)
                    l.PASADA = CType(unaFila.Item(6), Integer)

                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxitem(ByVal fechadesde As String, ByVal fechahasta As String, ByVal itemx As String, ByVal equipox As String) As ArrayList
        Dim sql As String = "SELECT id, fecha, operador, equipo, item, lectura, pasada FROM material_referencia_aux where fecha BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and item = '" & itemx & "' and equipo= '" & equipox & "' order by fecha, id asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(Sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dMaterialReferenciaAux
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.OPERADOR = CType(unaFila.Item(2), String)
                    l.EQUIPO = CType(unaFila.Item(3), String)
                    l.ITEM = CType(unaFila.Item(4), String)
                    l.LECTURA = CType(unaFila.Item(5), Double)
                    l.PASADA = CType(unaFila.Item(6), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxitem2(ByVal fechadesde As String, ByVal fechahasta As String, ByVal itemx As String) As ArrayList
        Dim sql As String = "SELECT id, fecha, operador, equipo, item, lectura, pasada FROM material_referencia_aux where fecha BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and item = '" & itemx & "' order by fecha asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dMaterialReferenciaAux
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.OPERADOR = CType(unaFila.Item(2), String)
                    l.EQUIPO = CType(unaFila.Item(3), String)
                    l.ITEM = CType(unaFila.Item(4), String)
                    l.LECTURA = CType(unaFila.Item(5), Double)
                    l.PASADA = CType(unaFila.Item(6), Integer)

                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
