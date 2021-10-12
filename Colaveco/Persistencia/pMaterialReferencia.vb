Public Class pMaterialReferencia
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMaterialReferencia = CType(o, dMaterialReferencia)
        Dim sql As String = "INSERT INTO material_referencia (id, fecha, operador, equipo, item, lectura, valorref, diferencia, diferenciareal, difmaxpermitida, resultado, pasada) VALUES (" & obj.ID & ", '" & obj.FECHA & "', '" & obj.OPERADOR & "', '" & obj.EQUIPO & "', '" & obj.ITEM & "', " & obj.LECTURA & ", " & obj.VALORREF & ", " & obj.DIFERENCIA & ", " & obj.DIFERENCIAREAL & ", " & obj.DIFMAXPERMITIDA & ", '" & obj.RESULTADO & "', " & obj.PASADA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'materialreferencia', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMaterialReferencia = CType(o, dMaterialReferencia)
        Dim sql As String = "UPDATE material_referencia SET fecha = '" & obj.FECHA & "',operador = '" & obj.OPERADOR & "',equipo = '" & obj.EQUIPO & "',item = '" & obj.ITEM & "',lectura = " & obj.LECTURA & ",valorref = " & obj.VALORREF & ",diferencia = " & obj.DIFERENCIA & ",diferenciareal = " & obj.DIFERENCIAREAL & ",difmaxpermitida = " & obj.DIFMAXPERMITIDA & ",resultado = '" & obj.RESULTADO & "',pasada = " & obj.PASADA & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'materialreferencia', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function guardardiferencia(ByVal o As Object) As Boolean
        Dim obj As dMaterialReferencia = CType(o, dMaterialReferencia)
        Dim sql As String = "UPDATE material_referencia SET diferenciareal = " & obj.DIFERENCIAREAL & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMaterialReferencia = CType(o, dMaterialReferencia)
        Dim sql As String = "DELETE FROM material_referencia WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'materialreferencia', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dMaterialReferencia
        Dim obj As dMaterialReferencia = CType(o, dMaterialReferencia)
        Dim l As New dMaterialReferencia
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, operador, equipo, item, lectura, valorref, diferencia, diferenciareal, difmaxpermitida, resultado, pasada FROM material_referencia WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Integer)
                l.FECHA = CType(unaFila.Item(1), String)
                l.OPERADOR = CType(unaFila.Item(2), String)
                l.EQUIPO = CType(unaFila.Item(3), String)
                l.ITEM = CType(unaFila.Item(4), String)
                l.LECTURA = CType(unaFila.Item(5), Double)
                l.VALORREF = CType(unaFila.Item(6), Double)
                l.DIFERENCIA = CType(unaFila.Item(7), Double)
                l.DIFERENCIAREAL = CType(unaFila.Item(8), Double)
                l.DIFMAXPERMITIDA = CType(unaFila.Item(9), Double)
                l.RESULTADO = CType(unaFila.Item(10), String)
                l.PASADA = CType(unaFila.Item(11), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, operador, equipo, item, lectura, valorref, diferencia, diferenciareal, difmaxpermitida, resultado, pasada FROM material_referencia ORDER BY id ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dMaterialReferencia
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.OPERADOR = CType(unaFila.Item(2), String)
                    l.EQUIPO = CType(unaFila.Item(3), String)
                    l.ITEM = CType(unaFila.Item(4), String)
                    l.LECTURA = CType(unaFila.Item(5), Double)
                    l.VALORREF = CType(unaFila.Item(6), Double)
                    l.DIFERENCIA = CType(unaFila.Item(7), Double)
                    l.DIFERENCIAREAL = CType(unaFila.Item(8), Double)
                    l.DIFMAXPERMITIDA = CType(unaFila.Item(9), Double)
                    l.RESULTADO = CType(unaFila.Item(10), String)
                    l.PASADA = CType(unaFila.Item(11), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxitem(ByVal fechadesde As String, ByVal fechahasta As String, ByVal itemx As String, ByVal equipox As String) As ArrayList
        Dim sql As String = "SELECT id, fecha, operador, equipo, item, lectura, valorref, diferencia, diferenciareal, difmaxpermitida, resultado, pasada FROM material_referencia where fecha BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and item = '" & itemx & "' and equipo= '" & equipox & "' order by fecha asc, id asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(Sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dMaterialReferencia
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.OPERADOR = CType(unaFila.Item(2), String)
                    l.EQUIPO = CType(unaFila.Item(3), String)
                    l.ITEM = CType(unaFila.Item(4), String)
                    l.LECTURA = CType(unaFila.Item(5), Double)
                    l.VALORREF = CType(unaFila.Item(6), Double)
                    l.DIFERENCIA = CType(unaFila.Item(7), Double)
                    l.DIFERENCIAREAL = CType(unaFila.Item(8), Double)
                    l.DIFMAXPERMITIDA = CType(unaFila.Item(9), Double)
                    l.RESULTADO = CType(unaFila.Item(10), String)
                    l.PASADA = CType(unaFila.Item(11), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxitem2(ByVal fechadesde As String, ByVal fechahasta As String, ByVal itemx As String) As ArrayList
        Dim sql As String = "SELECT id, fecha, operador, equipo, item, lectura, valorref, diferencia, diferenciareal, difmaxpermitida, resultado, pasada FROM material_referencia where fecha BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and item = '" & itemx & "' order by fecha asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dMaterialReferencia
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.OPERADOR = CType(unaFila.Item(2), String)
                    l.EQUIPO = CType(unaFila.Item(3), String)
                    l.ITEM = CType(unaFila.Item(4), String)
                    l.LECTURA = CType(unaFila.Item(5), Double)
                    l.VALORREF = CType(unaFila.Item(6), Double)
                    l.DIFERENCIA = CType(unaFila.Item(7), Double)
                    l.DIFERENCIAREAL = CType(unaFila.Item(8), Double)
                    l.DIFMAXPERMITIDA = CType(unaFila.Item(9), Double)
                    l.RESULTADO = CType(unaFila.Item(10), String)
                    l.PASADA = CType(unaFila.Item(11), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
